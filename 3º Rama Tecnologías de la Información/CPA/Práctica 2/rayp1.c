/*
   Program derived from the basic raytracer example from scratchapixel (migrated
   to C language).
 */
/*
   A very basic raytracer example.
   Copyright (C) 2012  www.scratchapixel.com

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.

   - changes 02/04/13: fixed flag in ofstream causing a bug under Windows,
   added default values for M_PI and INFINITY
   - changes 24/05/13: small change to way we compute the refraction direction
   vector (eta=ior if we are inside and 1/ior if we are outside the sphere)

   Compile with the following command: c++ -o raytracer -O3 -Wall raytracer.cpp

 */

#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include <limits.h>
#include <omp.h> 



#ifdef __linux__
// "Compiled for Linux
#else
// Windows doesn't define these values by default, Linux does
#define M_PI 3.141592653589793
#define INFINITY 1e8
#endif

typedef double Real;
typedef struct { Real x, y, z; } Vec3;

void Vec3_new0( Vec3 *v )
{
  v->x = v->y = v->z = 0.0;
}
void Vec3_new1( Vec3 *v, Real xx )
{
  v->x = v->y = v->z = xx;
}
void Vec3_new( Vec3 *v, Real xx, Real yy, Real zz )
{
  v->x = xx;
  v->y = yy;
  v->z = zz;
}
Real Vec3_length2( Vec3 *v ) { return v->x * v->x + v->y * v->y + v->z * v->z; }
void Vec3_normalize( Vec3 *v )
{ Real nor2 = Vec3_length2( v );
  if (nor2 > 0) {
    Real invNor = 1 / sqrt(nor2);
    v->x *= invNor, v->y *= invNor, v->z *= invNor;
  }
}
void Vec3_prod( Vec3 *v, const Vec3 *v1, const Vec3 *v2 )
{
  v->x = v1->x * v2->x;
  v->y = v1->y * v2->y;
  v->z = v1->z * v2->z;
}
void Vec3_scale( Vec3 *v, const Real f )
{
  v->x *= f; v->y *= f; v->z *= f;
}
Real Vec3_dot( const Vec3 *v1, const Vec3 *v2 )
{
  return v1->x * v2->x + v1->y * v2->y + v1->z * v2->z;
}
void Vec3_subs( Vec3 *v, const Vec3 *v1, const Vec3 *v2 )
{
  v->x = v1->x - v2->x;
  v->y = v1->y - v2->y;
  v->z = v1->z - v2->z;
}
void Vec3_add( Vec3 *v, const Vec3 *v1, const Vec3 *v2 )
{
  v->x = v1->x + v2->x;
  v->y = v1->y + v2->y;
  v->z = v1->z + v2->z;
}
void Vec3_axpy( Vec3 *v, const Real a, const Vec3 *x, const Vec3 *y )
{
  v->x = a*x->x + y->x;
  v->y = a*x->y + y->y;
  v->z = a*x->z + y->z;
}
void Vec3_minus( Vec3 *v )
{
  v->x = -v->x;
  v->y = -v->y;
  v->z = -v->z;
}
Real Vec3_length( Vec3 *v ) { return sqrt(Vec3_length2(v)); }
void Vec3_printf( Vec3 *v )
{
  printf("[%g %g %g]",v->x,v->y,v->z);
}

typedef struct {
  Vec3 center;                         /// position of the sphere
  Real radius, radius2;                /// sphere radius and radius^2
  Vec3 surfaceColor, emissionColor;    /// surface color and emission (light)
  Real transparency, reflection;       /// surface transparency and reflectivity
} Sphere;
void Sphere_new(Sphere *e,
    const Vec3 *c, const Real r, const Vec3 *sc, 
    const Real refl, const Real transp, const Vec3 *ec)
{
  e->center = *c;
  e->radius = r;
  e->radius2 = r * r;
  e->surfaceColor = *sc;
  e->emissionColor = *ec;
  e->transparency = transp;
  e->reflection = refl;
}
void Sphere_new0(Sphere *e,
    const Vec3 *c, const Real r, const Vec3 *sc,
    const Real refl, const Real transp)
{
  e->center = *c;
  e->radius = r;
  e->radius2 = r * r;
  e->surfaceColor = *sc;
  Vec3_new0(&e->emissionColor);
  e->transparency = transp;
  e->reflection = refl;
}
typedef enum { false = 0, true } bool;
// compute a ray-sphere intersection using the geometric solution
bool Sphere_intersect(const Sphere *e,const Vec3 *rayorig, const Vec3 *raydir, Real *t0, Real *t1)
{ Vec3 l;
  Real tca, d2, thc;
  Vec3_subs(&l,&e->center,rayorig);
  tca = Vec3_dot(&l,raydir);
  if (tca < 0) return false;
  d2 = Vec3_dot(&l,&l) - tca * tca;
  if (d2 > e->radius2) return false;
  thc = sqrt(e->radius2 - d2);
  if (t0 != NULL && t1 != NULL) {
    *t0 = tca - thc;
    *t1 = tca + thc;
  }

  return true;
}

#define MAX_RAY_DEPTH 5

Real mix(const Real a, const Real b, const Real mix)
{
  return b * mix + a * (1.0 - mix);
}

#define MAX(a,b) ( (a) >= (b) ? (a) : (b) )
#define MIN(a,b) ( (a) <= (b) ? (a) : (b) )
Real max(Real a, Real b) { return MAX(a,b); }
Real min(Real a, Real b) { return MIN(a,b); }

/* -------------------------------------------------------------------------- */
/* Histogram */

#define HIST_N_INTV 7        // Number of intervals
#define HIST_MIN_VALUE 1.0
#define HIST_INCREMENT 1.5

void init_histogram(int histo[HIST_N_INTV]) {
  int i;
  for (i=0; i<HIST_N_INTV; i++)
    histo[i]=0;
}

void update_histogram(int histo[HIST_N_INTV], float value) {
  int intv=0;
  /* Find interval where value lies */
  while (intv<HIST_N_INTV && value>=HIST_MIN_VALUE+(intv+1)*HIST_INCREMENT)
    intv++;
  histo[intv]++;
}

void print_histogram(int histo[HIST_N_INTV]) {
  int i, j, max;
  double from;

  max = 0;
  for (i=0; i<HIST_N_INTV; i++) {
    if (histo[i]>max)
      max = histo[i];
  }

  printf("\nComplexity histogram:\n");
  printf(" Calls/pixel    |  Number of lines\n");
  printf(" ------------------------------------------------------------------------\n");
  for (i=0; i<HIST_N_INTV; i++) {
    from = HIST_MIN_VALUE+i*HIST_INCREMENT;
    if (i<HIST_N_INTV-1)
      printf(" [%4.1f -- %4.1f[ | %4d ", from, from+HIST_INCREMENT, histo[i]);
    else
      printf(" [%4.1f -- +inf[ | %4d ", from, histo[i]);
    for (j=0; j<(int) (histo[i]*50.0/max+0.5); j++)
      printf("*");
    printf("\n");
  }
  printf("\n");
}

/* -------------------------------------------------------------------------- */

// This is the main trace function. It takes a ray as argument (defined by its origin
// rayorig and direction raydir) and computes v, the color for the ray.
// It returns the number of calls to trace invoked in the process (remember this is
// a recursive function)
// We test if this ray intersects any of the geometry in the scene.
// If the ray intersects an object, we compute the intersection point, the normal
// at the intersection point, and shade this point using this information.
// Shading depends on the surface property (is it transparent, reflective, diffuse).
// If the ray intersects an object, the color for the ray is the color of the object
// at the intersection point, otherwise it is the background color.
int trace(Vec3 *v,const Vec3 *rayorig, const Vec3 *raydir, 
    const unsigned size, const Sphere *spheres, const int depth)
{
  //if (raydir.length() != 1) std::cerr << "Error " << raydir << std::endl;
  Real tnear = INFINITY;
  const Sphere *sphere = NULL;
  unsigned i, j;
  Vec3 surfaceColor, phit, nhit, aux;
  Real bias;
  bool inside;
  int ncalls=1;
  // find intersection of this ray with the sphere in the scene
  for (i = 0; i < size; ++i) {
    Real t0 = INFINITY, t1 = INFINITY;
    if (Sphere_intersect(&spheres[i], rayorig, raydir, &t0, &t1)) {
      if (t0 < 0) t0 = t1;
      if (t0 < tnear) {
        tnear = t0;
        sphere = &spheres[i];
      }
    }
  }
  // if there's no intersection return black or background color
  if (!sphere) {
    Vec3_new1(v,2);
    return ncalls;
  }
  Vec3_new0(&surfaceColor); // color of the ray/surfaceof the object intersected by the ray
                            // phit = rayorig + raydir * tnear; // point of intersection
  Vec3_axpy(&phit,tnear,raydir,rayorig);
  Vec3_subs(&nhit, &phit, &sphere->center); // normal at the intersection point
  Vec3_normalize(&nhit); // normalize normal direction
                         // If the normal and the view direction are not opposite to each other 
                         // reverse the normal direction. That also means we are inside the sphere so set
                         // the inside bool to true. Finally reverse the sign of IdotN which we want
                         // positive.
  bias = 1e-4; // add some bias to the point from which we will be tracing
  inside = false;
  if (Vec3_dot(raydir,&nhit) > 0) Vec3_minus(&nhit), inside = true;
  if ((sphere->transparency > 0 || sphere->reflection > 0) && depth < MAX_RAY_DEPTH) {
    Real facingratio = -Vec3_dot(raydir,&nhit);
    // change the mix value to tweak the effect
    Real fresneleffect = mix(pow(1 - facingratio, 3), 1, 0.1); 
    // compute reflection direction (not need to normalize because all vectors
    // are already normalized)
    Vec3 refldir, reflection, refraction;
    // refldir = raydir - nhit * 2 * raydir.dot(nhit);
    Vec3_axpy(&refldir, -2 * Vec3_dot(raydir, &nhit), &nhit, raydir);
    Vec3_normalize(&refldir);
    Vec3_axpy(&aux, bias, &nhit, &phit);
    ncalls += trace( &reflection, &aux, &refldir, size, spheres, depth + 1);
    Vec3_new0(&refraction);
    // if the sphere is also transparent compute refraction ray (transmission)
    if (sphere->transparency) {
      Real ior = 1.1, eta = (inside) ? ior : 1 / ior; // are we inside or outside the surface?
      Real cosi = -Vec3_dot(&nhit,raydir);
      Real k = 1 - eta * eta * (1 - cosi * cosi);
      Vec3 refrdir;
      // refrdir = raydir * eta + nhit * (eta *  cosi - sqrt(k));
      refrdir = nhit; Vec3_scale(&refrdir, eta *  cosi - sqrt(k));
      Vec3_axpy(&refrdir, eta, raydir, &refrdir);
      Vec3_normalize(&refrdir);
      Vec3_axpy(&aux, -bias, &nhit, &phit);
      ncalls += trace(&refraction, &aux, &refrdir, size, spheres, depth + 1);
    }
    // the result is a mix of reflection and refraction (if the sphere is transparent)
    //surfaceColor = (reflection * fresneleffect + 
    //  refraction * (1 - fresneleffect) * sphere->transparency) * sphere->surfaceColor;
    surfaceColor = refraction;
    Vec3_scale(&surfaceColor, (1 - fresneleffect) * sphere->transparency);
    Vec3_axpy(&surfaceColor, fresneleffect, &reflection, &surfaceColor);
    Vec3_prod(&surfaceColor, &surfaceColor, &sphere->surfaceColor);
  }
  else {
    // it's a diffuse object, no need to raytrace any further
    for (i = 0; i < size; ++i) {
      if (spheres[i].emissionColor.x > 0) {
        // this is a light
        Vec3 transmission, lightDirection;
        Vec3_new1(&transmission, 1);
        Vec3_subs(&lightDirection, &spheres[i].center, &phit);
        Vec3_normalize(&lightDirection);
        for (j = 0; j < size; ++j) {
          if (i != j) {
            Real t0, t1;
            Vec3_axpy(&aux, bias, &nhit, &phit);
            if (Sphere_intersect(&spheres[j], &aux, &lightDirection, &t0, &t1)) {
              // Shadow smoothing 
              if (spheres[j].transparency == 0.0) {
                Vec3_new0(&transmission);
                break;
              } else {
                Vec3_scale(&transmission, spheres[j].transparency);
                Vec3_prod(&transmission, &transmission, &spheres[j].surfaceColor);
              }
            }
          }
        }
        //surfaceColor += sphere->surfaceColor * transmission * 
        //  std::max(T(0), nhit.dot(lightDirection)) * spheres[i]->emissionColor;
        Vec3_prod(&aux, &sphere->surfaceColor, &transmission);
        Vec3_prod(&aux, &aux, &spheres[i].emissionColor);
        Vec3_axpy(&surfaceColor, max(0.0, Vec3_dot(&nhit, &lightDirection)), &aux, &surfaceColor);
      }
    }
  }

  Vec3_add(v, &surfaceColor, &sphere->emissionColor);
  return ncalls;
}
//double res = 0;
// Main rendering function. We compute a camera ray for each pixel of the image
// trace it and get a color. If the ray hits a sphere, we get the color of the
// sphere at the intersection point, else we get the background color.
void render(const unsigned size, const Sphere spheres[size])
{
  //  unsigned width = 640, height = 480;
  unsigned width = 1024, height = 768;
  Vec3 *image, *pixel, origin, raydir;
  Real invWidth = 1 / (Real)width, invHeight = 1 / (Real)height;
  Real fov = 30, aspectratio = width / (Real)height;
  Real xx, yy, angle = tan(M_PI * 0.5 * fov / 180.0);
  unsigned x, y, i;
  int ncalls;
  double ncalls_line, max_ncalls_line, min_ncalls_line;
  int histo[HIST_N_INTV];
  FILE *F;

  image = malloc(width * height * sizeof(*image));
  Vec3_new0(&origin);
  init_histogram(histo);
  max_ncalls_line = 0;
  min_ncalls_line = INFINITY;

  // Trace rays
  double t1 = omp_get_wtime();
  for (y = 0; y < height; ++y) {
    ncalls_line = 0;
    #pragma omp parallel for private (pixel, raydir) reduction(+:xx,yy,ncalls_line, ncalls)
      for (x = 0; x < width; ++x) 
      {
        pixel = &image[y*width+x];
        xx = (2 * ((x + 0.5) * invWidth) - 1) * angle * aspectratio;
        yy = (1 - 2 * ((y + 0.5) * invHeight)) * angle;
        Vec3_new(&raydir, xx, yy, -1);
        Vec3_normalize(&raydir);
        ncalls = trace(pixel, &origin, &raydir, size, spheres, 0);
        ncalls_line += ncalls;
      }
    ncalls_line = ncalls_line/width;
    if (ncalls_line < min_ncalls_line)
      min_ncalls_line = ncalls_line;
    if (ncalls_line > max_ncalls_line)
      max_ncalls_line = ncalls_line;
    update_histogram(histo, ncalls_line);
  }
  double t2 = omp_get_wtime();
  double time = t2-t1;
  print_histogram(histo);
  printf("Least complex line had %6.3f calls to trace per pixel.\n", min_ncalls_line);
  printf("Most  complex line had %6.3f calls to trace per pixel.\n", max_ncalls_line);
  printf("Tiempo: %f\n", time);
  // Save result to a PPM image (keep these flags if you compile under Windows)
  F = fopen("./untitled.ppm", "wb");
  fprintf(F, "P6\n%u %u\n255\n", width, height);
  for (i = 0; i < width * height; ++i) {
    fprintf(F, "%c%c%c",
        (unsigned char)(min(1.0, image[i].x) * 255),
        (unsigned char)(min(1.0, image[i].y) * 255),
        (unsigned char)(min(1.0, image[i].z) * 255));
  }
  fclose(F);
  free(image);
}

#define N 6

Sphere *create_spheres(int n) {
  Sphere *spheres;
  Vec3 p,c,e;

  spheres = malloc(n*sizeof(*spheres));
  // position, radius, surface color, reflectivity, transparency, emission color
  Vec3_new(&p, 0, -10004, -20);
  Vec3_new1(&c, 0.2);
  Sphere_new0(&spheres[0], &p, 10000, &c, 0, 0.0);
  Vec3_new(&p, 0, 0, -20);
  Vec3_new(&c, 1.00, 0.32, 0.36);
  Sphere_new0(&spheres[1], &p, 4, &c, 1, 0.5);
  Vec3_new(&p, 5, -1, -15);
  Vec3_new(&c, 0.90, 0.76, 0.46);
  Sphere_new0(&spheres[2], &p, 2, &c, 1, 0.0);
  Vec3_new(&p, 5, 0, -25);
  Vec3_new(&c, 0.65, 0.77, 0.97);
  Sphere_new0(&spheres[3], &p, 3, &c, 1, 0.0);
  Vec3_new(&p, -5.5, 0, -15);
  Vec3_new(&c, 0.90, 0.90, 0.90);
  Sphere_new0(&spheres[4], &p, 3, &c, 1, 0.0);
  // light
  Vec3_new(&p, 0, 20, -30);
  Vec3_new0(&c);
  Vec3_new1(&e, 3);
  Sphere_new(&spheres[5], &p, 3, &c, 0, 0, &e);
  if(n>N){ int i,j,k; Real r,d; Vec3 v;
    srand48(13);
    for(i=N;i<n;i++){
      k=0;
      do{
        Vec3_new(&p, 12*drand48()-6,9*drand48()-4,-35*drand48()-15);
        r = 0.1 + drand48();
        for(j=0;j<i && r>=0.1;j++){
          Vec3_subs(&v,&spheres[j].center,&p);
          d=Vec3_length(&v)-spheres[j].radius;
          if(d<r)r=d;
        }
      }while(r<0.1 && ++k<1000);
      if(r>=0.1){
        Vec3_new(&c, rand()%4/3.0,rand()%4/3.0,rand()%4/3.0);
        Sphere_new0(&spheres[i], &p, r, &c,
            drand48()<0.8?0:1, drand48()<0.8?0:0.8);
      }else printf("#");
    }
  }
  return spheres;
}

int main(int argc, char **argv)
{
  Sphere *spheres;
  int n;

  n = argc>1 ? atoi(argv[1]) : N;
  if(n<N)n=100;

  spheres = create_spheres(n);
  printf("Computing...\n");
  render(n, spheres);
  free(spheres);
  return 0;
}
