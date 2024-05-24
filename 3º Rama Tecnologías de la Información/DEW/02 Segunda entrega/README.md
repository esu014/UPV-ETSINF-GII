# ACTA 3

---

# Reunión 3

---

## 1.  Preámbulo

Fecha: 16/04/2024 de 10:30 a 14:30

Identificador del grupo: 3TI11_G2

Tipo de reunión: presencial

Lista de asistentes:

1. Pau Amorós

2. Carlos Cebellán

3. Jorge Díez

4. Giorgi Dolidze

5. Segundo Gómez

6. Pau Perez

7. Enrique Sopeña

Alumno firmante del documento: Enrique Sopeña

## 2.  Resumen

En esta reunión, el principal objetivo fue establecer una ruta de trabajo para decidir como afrontar el Hito 2. En ella se leyó el enunciado, se hizo un “Brainstorming” para sugerir soluciones y se debatió cuál era la mejor forma de proseguir con el proyecto. Se realizo una investigación y se pusieron conocimientos en común acerca de los filtros. 

Se estableció la máquina principal donde se ejecuta la aplicación web, la del integrante Pau Perez (dew-ppermar5-dsicv.upv.es) y la de backup, la del integrante Enrique Sopeña (dew-ppermar5-dsicv.upv.es). También se asignó la url del servidor donde se hostea la aplicación web. La url del servidor se consigue con las mismas direcciones mencionadas anteriormente, pero añadiéndole `**:8080/TrabajoDEW**` en la barra del navegador (Ejemplo con la maquina principal: `**[http://dew-ppermar5-dsicv.upv.es:8080/TrabajoDEW](http://dew-ppermar5-dsicv.upv.es:8080/TrabajoDEW)**`).  

Y obviamente para que se pueda establecer una comunicación con CentroEducativo, tiene que estar encendido. Para que esto ocurra hay que tener descargado el archivo `**es.upv.etsinf.ti.centroeducativo-0.2.0.jar**`, que ya esta instalado en las maquinas virtuales. En caso de que no este, el archivo está disponible en [PoliFormaT](https://poliformat.upv.es). Una vez descargado y situado el archivo en directorio `**/home/user/**`, se ejecuta el siguiente comando: 

```bash
~$ /usr/lib/jvm/java-8-openjdk-amd64/jre/bin/java -jar es.upv.etsinf.ti.centroeducativo0.2.0.jar
```

Esta orden enciende CentroEduucativo y permite la comunicación entre aplicación web y base de datos donde están los alumnos y los profesores. 

A nivel de código y desarrollo no hemos realizado nada, ha sido mas una reunión informativa. Por tanto en este informe no se va a encontrar ningún apartado relacionado con las piezas mencionadas en la tarea.

**P.D.** En la siguiente reunión, al modificar el nombre del proyecto, también cambia la ruta que establecemos en el navegador para acceder a la aplicación web. La **nueva dirección** es: [`**http://dew-ppermar5-dsicv.upv.es:8080/NOL-G2-1**`](http://dew-ppermar5-dsicv.upv.es:8080/NOL-G2-1). El CentroEducativo no es necesario cambiarlo ya que no influye en la nueva modificación.

# Reunión 4

---

## 1.  Preámbulo

Fecha: 21/04/2024 de 10:30 a 14:30

Identificador del grupo: 3TI11_G2

Tipo de reunión: presencial

Lista de asistentes:

1. Pau Amorós

2. Carlos Cebellán

3. Jorge Díez

4. Giorgi Dolidze

5. Segundo Gómez

6. Pau Perez

7. Enrique Sopeña

Alumno firmante del documento: Enrique Sopeña

## 2.  Resumen

En esta reunión, se empezó a estructurar el proyecto en Eclipse. Se repartió el trabajo para poder aprovechar el tiempo y avanzar más rápido hacia la solución. Los integrantes Segundo Gómez y Carlos Cebellán se encargaron de los *HTML* y CSS con [Bootstrap](https://getbootstrap.com), mientras que el resto estuvieron trabajando sobre el filtro, buscando la manera más optima de que funcione sin fallos, tanto por el camino lógico (la ruta que debería hacer un usuario convencional) como por caminos alternativos (probar a recargar con la sesión ya iniciada, meter otras url, intentar iniciar sesión en otro espacio el cuál no estamos autorizados, …). 

Al final se decidió utilizar el servlet de tipo filter. El usuario realizará una interacción con la pagina inicial (en ella hay dos formularios posibles, uno para profesor y otro para alumno) y si no está registrado el servlet Filter redirigirá a la página de login para autentificarse. En caso de que pinche en un formulario en el que no le corresponda, le devolverá a la pagina inicial para que seleccione la opción correcta. Esto último no se ha implementado en esta reunión, solo se ha realizado las funciones básicas del filtro; las últimas novedades se quedaron planteadas para implementarlas en las siguientes reuniones y los errores también se corregirán en las próximas reuniones. 

En el formulario de inicio de sesión, en el pdf donde hay información de como hacer las cosas, recomienda utilizar como `**login-config**` el tipo `**BASIC**`, pero no nos convencía como funcionaba, así que se optó por informarse un poco más a fondo y utilizar el tipo **`FORM`**, que requiere de variables de tipo `**j_nombrevariable**`, para que se incluya la herramienta `**j_security_check**` que se encarga de mirar los roles.  

Además también se acordó en esta reunión crear un servidor de Discord, para mejorar la comunicación entre el grupo cuando no se esté trabajando de manera presencial; para poder mandar partes de código, recursos de información…; obviamente se creo un canal de comunicación general. Y de esta manera todo queda debidamente organizado y no es caótico. 

## 3.  Desarrollo

### 3.1  HTML

El *HTML* se ha desarrollado en la herramienta [htmledit.squarefree.com](http://htmledit.squarefree.com), donde se puede editar en tiempo real. Se ha elegido esta herramienta porque como no podemos trabajar concurrentemente con el proyecto, se ha decidido hacer los *HTML* aparte y luego compartirlo por el grupo de WhatsApp, para pegarlo en el proyecto, en un *HTML*. 

En esta reunión se ha hecho la pagina que esta relacionada con el login,y la pagina principal del alumno (aunque a esta última aun le falta funcionalidad, como añadir las notas y asignaturas en las que esta matriculado. Pero a modo de idea está terminada). 

Código importante de login.html: 

```html
<form action="j_security_check" method="post">
    <input type="text" placeholder="DNI" name="j_username" required>
    <input type="password" placeholder="Contraseña" name="j_password" required>
    <button type="submit">Entrar</button>
</form>
```

Estructura básica de Alumno.html (pagina principal del alumno):

```html
<body>
	<div class="container mt-5">
	    <h1>Bienvenido @usuario</h1>
	    <h2>Asignaturas</h2>
	    <!-- Acordeon de Asignaturas, manera de estructurar las asignaturas en la web, el css no esta incluido-->
	    <div class="accordion" id="accordionExample">
	        <div class="accordion-item">
	            <h2 class="accordion-header" id="headingOne">
	                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
	                    DCU - Desarrollo Centrado en el Usuario
	                </button>
	            </h2>
	            <div id="collapseOne" class="accordion-collapse collapse" aria-labelledby="headingOne" data-bs-parent="#accordionExample">
	                <div class="accordion-body">
	                    <p>Desarrollo Centrado en el Usuario.</p>
	                    <button class="btn btn-primary mt-3">Ir a DCU</button>
	                </div>
	            </div>
	        </div>
	        <div class="accordion-item">
	            <h2 class="accordion-header" id="headingTwo">
	                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
	                    DEW - Desarrollo Web
	                </button>
	            </h2>
	            <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#accordionExample">
	                <div class="accordion-body">
	                    <p>Desarrollo Web.</p>
	                    <button class="btn btn-primary mt-3">Ir a DEW</button>
	                </div>
	            </div>
	        </div>
	        <div class="accordion-item">
	            <h2 class="accordion-header" id="headingThree">
	                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
	                    IAP - Integración de Aplicaciones
	                </button>
	            </h2>
	            <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#accordionExample">
	                <div class="accordion-body">
	                    <p>Integración de Aplicaciones.</p>
	                    <button class="btn btn-primary mt-3">Ir a IAP</button>
	                </div>
	            </div>
	        </div>
	    </div>
	</div>
	<!-- Vinculación de Bootstrap JavaScript -->
	<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
```

### 3.2.  Java

En cuanto a la parte de Java, se ha desarrollado un prototipo de filtro, llamado Log3.java. 

En un principio, saltaban errores como 408 o 500, pero tras preguntarle a Ramón en la hora de laboratorio, se ha conseguido resolver estos problemas.

El código comienza inicializando la sesión al obtener la solicitud HTTP y creando o recuperando una sesión asociada. Luego, obtiene el nombre de usuario remoto (DNI) que ha realizado la solicitud. A continuación, verifica si la sesión ya tiene una clave (key) almacenada. Si la sesión no tiene clave y el usuario (DNI) existe, crea un objeto con el DNI y una contraseña fija, establece una conexión HTTP a un servicio de autenticación remoto y envía el DNI y la contraseña como una solicitud `**POST**` en formato JSON a CentroEducativo. Además, registra en un archivo de log el JSON enviado. Si la respuesta del servidor es exitosa (código `**200**`), almacena las cookies de la respuesta en la sesión, lee la clave (key) de la respuesta del servidor, y almacena el DNI, la contraseña y la clave en la sesión, registrando también la clave recibida en un archivo de log. Si la sesión ya tiene clave, recupera las cookies almacenadas en la sesión y añade estas cookies a la solicitud para reutilizarlas en la conexión HTTP actual.

Código del filter:

```java
public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
		HttpServletRequest req = (HttpServletRequest) request;
		HttpSession session = req.getSession(true);
		session.setMaxInactiveInterval(10000);
		
		URL connection = new URL("http://dew-ppermar5-2324.dsicv.upv.es:9090/CentroEducativo/login");
		HttpURLConnection con = (HttpURLConnection) connection.openConnection();
		
		String dni = req.getRemoteUser();
		
		if(session.getAttribute("key") == null) {
			if(dni != null) {
				String pass = "123456";
				JSONObject cred = new JSONObject();
				cred.put("dni", dni);
				cred.put("password", pass);
				
				con.setDoOutput(true);
				con.setDoInput(true);
				con.setRequestMethod("POST");
				con.setRequestProperty("Content-Type", "application/json");
				con.setRequestProperty("Accept-Charset", "UTF-8");
				
				try {
					BufferedWriter buff = new BufferedWriter(new OutputStreamWriter(con.getOutputStream(),"UTF-8"));
					buff.write(cred.toString());
					buff.flush();
					buff.close();
				} 
				catch (Exception e) {}
				
				//respuesta de CentroEducativo
				if(con.getResponseCode() == 200) {
					List<String> cookies = con.getHeaderFields().get("Set-Cookie"); 
					session.setAttribute("cookie", cookies);
					String resKey = "";
					try {
						BufferedReader buff2 = new BufferedReader(new InputStreamReader(con.getInputStream(), "utf-8"));
						String resline = null;
						while((resline = buff2.readLine()) != null) {
							resKey += resline.trim();
						}
						session.setAttribute("dni", dni);
						session.setAttribute("password", pass);
						session.setAttribute("key", resKey);
					}
				}			
		} 
		else {
			List<String> cookies = (List<String>) session.getAttribute("cookies");
			if (cookies != null) {
				for (String cookie: cookies) {
					 con.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
					} 
			}	
}
```

### 3.3.  Archivos XML

En cuanto a los archivos XML, se tienen dos: web.xml, que está dentro del proyecto, que se encarga de configurar los servlets; y tomcat-user.xml, que esta en la carpeta “/home/user/tomcat/conf”, que se encarga de añadir roles y los usuarios autorizados, con sus respectivos roles.

Código de tomcat-user.xml:

```xml
<role rolename="rolpro"/>
<role rolename="rolalu"/>

<user username="23456733H" password="123456" roles="rolpro"/>
<user username="10293756L" password="123456" roles="rolpro"/>
<user username="06374291A" password="123456" roles="rolpro"/>
<user username="65748923M" password="123456" roles="rolpro"/>
<user username="12345678W" password="123456" roles="rolalu"/>
<user username="23456387R" password="123456" roles="rolalu"/>
<user username="34567891F" password="123456" roles="rolalu"/>
<user username="93847525G" password="123456" roles="rolalu"/>
<user username="37264096W" password="123456" roles="rolalu"/>
```

En cuanto el web.xml, se han tenido que realizar bastantes modificaciones, para añadir los servlets, las restricciones de seguridad, los roles admitidos etc (revisar esto). Ademas de las configuraciones basicas, que se hacen en todo servlet por defecto, se destaca en el siguiente código lo que se ha cambiado más importante:

```xml
<security-constraint>
  <web-resource-collection>
    <web-resource-name>AccesoAlu</web-resource-name>
    <url-pattern>/Alumno.html</url-pattern>
    <http-method>GET</http-method>
  </web-resource-collection>
  <auth-constraint>
    <role-name>rolalu</role-name>
    <role-name>rolpro</role-name>
  </auth-constraint>
</security-constraint>
```

Este código protege la página **`Alumno.html`** para que solo sea accesible mediante solicitudes GET por usuarios con los roles **`rolalu`** o **`rolpro`**. Esto se logra mediante un **`security-constraint`** que incluye una **`web-resource-collection`** con el patrón de URL **`/Alumno.html`** y el método HTTP GET, y un **`auth-constraint`** que especifica los roles permitidos. Si un usuario no pertenece a estos roles, no podrá acceder a la página.

```xml
<login-config>
  <auth-method>FORM</auth-method>
  <form-login-config>
    <form-login-page>/login.html</form-login-page>
    <form-error-page>/error.html</form-error-page>
  </form-login-config>
</login-config>
```

Esto configura el mecanismo de autenticación de la aplicación web mediante formularios. Específicamente, establece que la autenticación se realizará a través de un formulario (**`auth-method`** es **`FORM`**). Define la página de inicio de sesión como **`login.html`** y la página de error en caso de fallos de autenticación como **`error.html`**, ambas dentro de un elemento **`form-login-config`**. Esto asegura que los usuarios serán redirigidos a estas páginas para gestionar el proceso de inicio de sesión y errores.

```xml
<security-role>
    <role-name>rolalu</role-name>
  </security-role>
  <security-role>
    <role-name>rolpro</role-name>
</security-role>
```

El fragmento define los roles de seguridad utilizados en la aplicación web. Específicamente, declara dos roles: **`rolalu`** y **`rolpro`**, mediante elementos **`security-role`**. Estos roles se utilizan para asignar permisos y controlar el acceso a los recursos protegidos dentro de la aplicación. Además también están en tomcat-user.xml.

El resto de código web.xml, que es lo que se configura por defecto:

```xml
<filter>
	<display-name>Log3</display-name>
	<filter-name>Log3</filter-name>
	<filter-class>Log3</filter-class>
</filter>
	<filter-mapping>
	<filter-name>Log3</filter-name>
	<url-pattern>/*</url-pattern>
</filter-mapping>
```

## 4.  Problemas y comunicación con el profesor

En cuanto a los problemas, como se ha comentado antes, daba errores 408 y 500. 

El `**Error 408**` salta cuando en la barra del navegador, a la url de inicio le añadimos `**/login.html**`, sin hacer una previa solicitud de dirigirte a un recurso; nos registramos. Como el `**j_security_check**` no sabe a donde tiene que enviar la petición de inicio de sesión, al no haberla hecho previamente, genera un timeout (`**Error 408**`).   

En cambio el `**Error 500**`, salta porque se generan posibles bucles de redirección. Esto lo hemos solucionado eliminando estos posibles bucles. Como nos dijo Ramón, utilizar el método `**sendRedirect()**`, normalmente puede generar bucles, por tanto hemos modificado el código (Véase en el apartado 3.2 de Java) para que “permita el paso” hacia el recurso sin utilizar este método. 

Luego, también quedan cosas por hacer, como que el servlet complete la pagina principal con datos como las asignaturas o el nombre en la propia pagina. Y seguro que surgen nuevas modificaciones y errores pero eso se datará en las siguientes reuniones previas a la entrega, e incluso despues del hito 2, para corregir o mejorar esta versión.

# Reunión 5

---

## 1.  Preámbulo

Fecha: 23/04/2024 de 10:00 a 14:30 y de 16:00 a 20:00

Identificador del grupo: 3TI11_G2

Tipo de reunión: presencial

Lista de asistentes:

1. Pau Amorós

2. Carlos Cebellán

3. Jorge Díez

4. Giorgi Dolidze

5. Segundo Gómez

6. Pau Perez

7. Enrique Sopeña

Alumno firmante del documento: Enrique Sopeña

## 2. Resumen

En esta reunión se ha modificados la estructura del proyecto, como se explicará más detalladamente en el punto 3.1, el desarrollo. Se han creado dos servlet nuevos *Imprimir.java* y *Alumno.java* y eliminado los que no estaban relacionados con el proyecto en específico.

Se han creado dos archivos *HTML*:
- *Alumno.html*: Define la estructura de página web inicial, con los distintos valores de los marcadores, que serán sustituidos a posterior por el nuevo servlet *Alumno.java*. Estos marcadores son **`{{nomalu}}, {{dni}}, {{asg}} y {{imagen}}`**. Es decir en `**{{nomalu}}**` será reemplazado con el nombre del alumno, `**{{dni}}**` con el DNI del alumno , `**{{asg}}**` con las filas de la tablas que tienen las asignaturas con las calificaciones respectivas del alumno y **`{{imagen}}`** con la imagen del alumno/a.
- *PlantillaPeticion.html*: Es una pagina muy similar a la de *Alumno.html*, con la clara diferencia de que se le ha dado un formato similar a como si fuera un pdf, a la pagina de alumno de manera que todos los datos sean visibles a la hora de querer imprimir los resultados. Utiliza , además de los marcadores anteriores, uno nuevo marcador (`**{{fecha}}**`) para indicar la fecha en la que se ha generado ese impreso. Todo esto, lo gestiona otro nuevo servlet: *Imprimir.java*. 

Los dos nuevos servlets:
- *Alumno.java*: gestionará la generación dinámica de la página *HTML* mencionada anteriormente *alumno.html* para poder mostrar la información específica sobre un alumno y las asignaturas que está cursando.
- *Imprimir.java*: manejará la creación dinámica de *PlantillaPeticion.html* (también mencionada anteriormente) que se encargará de diseñar la página en un formato similar a PDF para poder imprimir el resultado.

Por último se ha tenido que modificar el archivo *web.xml* estableciendo un tiempo de sesión (60 minutos como máximo) y añadiendo los servlets que se han mencionado anteriormente *Imprimir.java* y *Alumno.java*. En cuanto a la seguridad también hemos modificado para que sea el servlet *Alumno.java* quien gestione las peticiones (proporciona una estructura más coherente y eficiente).

## 3.  Desarrollo

### 3.1.  Estructura del proyecto

![https://personales.alumno.upv.es/esopurb/dew/imgs/image.png](https://personales.alumno.upv.es/esopurb/dew/imgs/image.png)

*Imagen de la estructura del proyecto*

En esta reunión, se ha decidido modificar la estructura del proyecto, cambiando el nombre del proyecto, la ubicación de los archivos *HTML*, tanto de profesor como de alumno y la plantilla para que tenga formato de impresión. Los archivos mencionados se han trasladado a la carpeta `**/WEB-INF**`. De esta manera cuando un usuario pone en el buscador del navegador `**/alumno.html**` o `**/profesor.html**` o `**/plantilla.html**`, no pueda acceder a este recurso. 

Para mejorar la funcionalidad, ademas de lo de las carpetas, se ha decidido crear un nuevo servlet para *alumno.html*, para que la pagina sea controlada mediante el servlet y se trabaje sobre este en vez de al *HTML*. Así se puede modificar alumno.html con los datos del usuario y sus asignaturas. De esta manera cada pagina se personaliza para cada individuo. La descripción y empleabilidad del servlet se explica en el siguiente punto (Véase punto 3.3.1). 

También se ha creado un servlet llamado *Imprimir.java* (Véase punto 3.3.2) para gestionar *PlantillaPeticion.htm*l que genera un formato similar a un PDF y que se pueda imprimir. (Véase punto 3.2.2).

Por último en la estructura, también hemos eliminado todos los servlets que no estaban relacionados con el proyecto en si, como puede ser los logs realizados en la primera entrega (guardados en otro archivo.war), lo que conlleva a su eliminación del archivo *web.xml*.

### 3.2.  HTML

### 3.2.1.  Alumno.html

En Alumno.html se ha modificado la estructura del *HTML* para añadir un formulario, que va redirigido al servlet Imprimir.java (Véase punto 3.3.2), en el que se incluye el botón de imprimir notas, y la opción de la imagen del alumno; y además, también se han modificado los puntos en los que los marcadores `**{{nomalu}}, {{imagen}} y {{asg}}**`tendrán acción en un futuro para reescribir la pagina con el servlet Alumno.java (Véase punto 3.3.1). Estos marcadores los utilizamos para indicar en el servlet donde tiene que reeescribir codigo html.

No es un cambio muy drástico en este apartado, solo se ha añadido el botón y se ha reescrito las zonas en donde se incluirá código más adelante.

La estructura del `<body>` que como resultado asi: 

```html
<body>
	<div class="container mt-5">
		<div class="divs">
			<div style="justify-self:start">
			    <h1>Bienvenido, {{nomalu}}</h1>
			    <h2>Asignaturas</h2>
			</div>
			<div class="divimg" style="justify-self:end">
				{{imagen}}
			</div>
		</div>
		    <!-- Accordion de Asignaturas -->
		    <div class="accordion" id="accordionExample">
		        {{asg}}
		    </div>
		    <form action="Imprimir">
			    <div class="center-button">
			        <button class="Boton" type="submit" >Imprimir Certificado Alumno</button>
			    </div>
		    </form>
	</div>
	<!-- Vinculación de Bootstrap JavaScript -->
	<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
</body>
```

### 3.2.2.  PlantillaPeticion.html

La plantilla ha sido creada después de haber terminado la implementación total del servlet *Alumno.java* y su respectiva página web, por lo que ha sido bastante más fácil solucionar el problema de cómo generar una pagina formateada a estilo de impresión. Además para hacer la pagina algo más estética, se ha utilizado como herramienta la librería Bootstrap, tanto en esta como en la pagina *Alumno.html.*

Para ello se ha recurrido a una idea de diseño, y a partir de ahÍ se han introducido variables como las que se añaden en *Alumno.html* (En este caso, en la plantilla son:`**{{nombre}}, {{imagen}}, {{dni}}, {{asg}} y {{fecha}}**`). Quedando como resultado el `<body>` de la plantilla con la siguiente estructura html: 

```html
<body>
	<div class="divs">
		<div style="justify-self:start">
			<h1>Certificado sin validez académica</h1>
			<p><b>DEW - Centro Educativo</b> certifica que D/Dª <b>{{nombre}}</b>, con DNI {{dni}}, matriculado/a en el curso 23/24, ha obtenido las calificaciones que se muestran en la siguiente tabla.</p>
		</div>
		<div style="justify-self:end">
			{{imagen}}
		</div>
	</div>
  <h3>Resumen de notas:</h3>
  <table>
      <thead>
          <tr>
              <th>Acrónimo</th>
              <th>Asignatura</th>
              <th>Calificación</th>
          </tr>
      </thead>
      <tbody>
              {{asg}}
      </tbody>
  </table>
  <p class=bolivia>{{fecha}}</p>
</body>
```

### 3.3.  Los Servlets

### 3.3.1.  Alumno.java

El nuevo servlet *Alumno.java*. Este servlet gestiona la generación dinámica de una página *HTML* (alumno.html) para mostrar información específica sobre un alumno y sus asignaturas. Para profesor se realizara en la próxima reunión, ya que es una idea necesaria y derivada de la gestión de *Alumno.html*; ya que no es un requerimiento para esta entrega. 

En cuanto a la implementación del servlet, es bastante sencillo en si. Es un servlet que realiza un `**doGet()**` para pedirle a CentroEducativo los datos de las asignaturas en las que esta matriculado ese alumno, para posteriormente generar un desplegable con la librería Bootstrap donde se encuentran las notas y sus respectivas calificaciones. 

Para que todo esto funcione, hay que hacer una serie de comprobaciones, como verificar que el usuario es un alumno (verificar su rol). En caso de no ser así, le manda automáticamente a **`index.html`**. Esto se hace por si un usuario registrado como profesor pone en el buscador **`/alumno`** e intenta acceder a este sitio; de esta manera, no está autorizado.

```java
if(request.isUserInRole("rolpro")) {
		response.sendRedirect(request.getContextPath() + "/");
		return;
}
```

Se usa return para que deje de ejecutar este servlet y no produzca errores futuros. 

Una vez pasado este filtro inicial de seguridad, se obtiene la sesión HTTP actual y se extraen dos atributos de la sesión: "key" (una clave posiblemente utilizada para autenticación o autorización) y "cookies" (una lista de cookies almacenadas en la sesión). También se obtiene el nombre de usuario remoto (DNI) del usuario autenticado. Con estos datos, el servlet realiza una petición `**GET**` a CentroEducativo para obtener información del alumno utilizando el DNI y la clave. Se abre una conexión HTTP, se establecen las propiedades necesarias (como las cookies y el tipo de contenido aceptado), y si la respuesta es `**200_OK**` se lee la respuesta JSON del servicio, que se convierte en un objeto JSON para su procesamiento posterior. En caso de una respuesta distinta, se redirige al inicio y se detiene la ejecución de este servlet para evitar errores futuros. 

```java
//Recuperar sesion actual
HttpSession session = request.getSession();
String key = (String) session.getAttribute("key");
String dni = request.getRemoteUser();
JSONObject alumno = null;
JSONArray asignaturas = null;
List<String> cookies = (List<String>) session.getAttribute("cookies");

//preparar la peticion get
URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dni+"?key="+key);
HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
for (String cookie: cookies) {
		conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
}
conusr.setDoOutput(true);
conusr.setRequestMethod("GET");
conusr.setRequestProperty("accept", "application/json");

//lectura del alumno 
//tratar codigo
if(200==conasg.getResponseCode()){
		try(BufferedReader br = new BufferedReader(new InputStreamReader(conusr.getInputStream()))) {
				String r = "";
				String resLine = null;
				while ((resLine = br.readLine()) != null) {
						r += resLine.trim();
				}
				alumno = new JSONObject(r);
		}
}else{response.sendRedirect(request.getContextPath()+"/"); return;}
```

Luego, el servlet realiza una segunda petición `**GET**` a CentroEducativo para obtener una lista de asignaturas asociadas al alumno. Esta solicitud también utiliza el DNI del alumno y la clave de autenticación, y se configura de manera similar a la anterior, incluyendo las cookies necesarias en las propiedades de la solicitud. La respuesta de esta segunda solicitud, que es un JSON Array, se procesa y se convierte en un **`JSONArray`** que contiene las asignaturas del alumno.

```java
//CONSEGUIR ASIGNATURAS POR DNI
URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dni+"/asignaturas?key="+key);
HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
for (String cookie: cookies) {
		conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
}
conasg.setDoOutput(true);
conasg.setRequestMethod("GET");
conasg.setRequestProperty("accept", "application/json");

//tratar respuesta
if(200==conasg.getResponseCode()){
		try(BufferedReader br = new BufferedReader(new InputStreamReader(conasg.getInputStream()))) {
				String r = "";
				String resLine = null;
				while ((resLine = br.readLine()) != null) {
						r += resLine.trim();
				}
				asignaturas = new JSONArray(r);
		}
}else{response.sendRedirect(request.getContextPath()+"/"); return;}
```

Con la información del alumno y sus asignaturas ya obtenida, el servlet procede a construir una página *HTML* dinámica. La plantilla HTML se lee desde un archivo ubicado en el servidor (**`/WEB-INF/Alumno.html`**). El nombre completo del alumno (nombre y apellidos) se inserta en la plantilla reemplazando un marcador (**`{{nomalu}}`**), mediante el método **`replace(”nombre_marcador_en_el_html”, variable_donde_esta_el_dato_a_introducir)`**, a la variable donde se ha guardado previamente la pagina web de *Alumno.html* (`**Alumnohtml**`). Este nuevo cambio se almacena en la variable `**finalu**`; en la que aun falta modificar el marcador **`{{asg}}`**, que se encarga de generar los acordeones de las asignaturas, y **`{{imagen}}`** que introduce la imagen del alumno, que esta ubicada en el mismo directorio pero dentro de una carpeta llamada *imgs*.

```java
		//CONSTRUCCIÓN PÁGINA HTML ALUMNO (NOMBRE Y ACORDEÓN ASIGNATURAS)
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		String Alumnohtml = getServletContext().getRealPath("/WEB-INF/Alumno.html");
		String Alutem = new String(Files.readAllBytes(Paths.get(Alumnohtml)), "UTF-8");
		
		String dyn = alumno.getString("nombre") +" "+ alumno.getString("apellidos");
		String finalu = Alutem.replace("{{nomalu}}", dyn);
```

Una vez que se ha guardado la primera modificación en `**finalu**`;  **`dynasg`**  almacenará el HTML del acordeón de asignaturas del alumno. Luego, entra en un bucle que itera sobre cada asignatura en el **`JSONArray`** **`asignaturas`**. Para cada asignatura, se construye una URL específica que apunta al servicio **`CentroEducativo`** del servidor, incluyendo el identificador de la asignatura y una clave de autenticación. 

Se abre una conexión HTTP a esta URL y se configuran las propiedades de la solicitud, incluyendo las cookies de autenticación y el método **`GET`**, especificando que se espera una respuesta en formato JSON. La respuesta del servidor se lee utilizando un **`BufferedReader`** y se procesa para obtener un objeto JSON con los detalles de la asignatura. También se extrae la calificación de la asignatura, asignando "Sin calificar" si está vacía.

Con los datos obtenidos, se construye dinámicamente un segmento HTML para un ítem del acordeón, que incluye el nombre y la calificación de la asignatura. Este *HTML* se acumula en la cadena **`dynasg`**. Tras procesar todas las asignaturas, el marcador **`{{asg}}`** es remplazado en el html ya reescrito antes (`**finalu**`), otra vez por el método replace(). Acto seguido, se vuelve a utilizar este método para introducir también la imagen del alumno, reescribiendo **`{{imagen}}`**)por el string `**<img alt=\"fotoalumno\" src=\"./imgs/"+dni+".png\" width=\"92\" height=\"92\" style=\"border-radius:50%\">**`. 

Finalmente, el *HTML* completo, con los datos de las asignaturas integrados, se envía al cliente mediante **`PrintWriter`**, permitiendo que el navegador del usuario renderice la página personalizada con la información del alumno y sus asignaturas en un formato interactivo.

```java
String dynasg = "";
for(int i=0;i<asignaturas.length();i++) {
		JSONObject asg=null;
		URL urlnomasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/asignaturas/"+asignaturas.getJSONObject(i).getString("asignatura")+"?key="+key);
	  HttpURLConnection connomasg = (HttpURLConnection) urlnomasg.openConnection();
		
	  for (String cookie: cookies) {
			  connomasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
		} 
	  connomasg.setDoOutput(true);
		connomasg.setRequestMethod("GET");
		connomasg.setRequestProperty("accept", "application/json");
		if(connomasg.getResponseCode()==200){
				try(BufferedReader br = new BufferedReader(new InputStreamReader(connomasg.getInputStream()))) {
				String r = "";
				String resLine = null;
				while ((resLine = br.readLine()) != null) {
						r += resLine.trim();
				}
				String nota = asignaturas.getJSONObject(i).getString("nota");
				if(nota == "") nota = "Sin calificar";
				asg = new JSONObject(r);
				dynasg += "<div class=\"accordion-item\">\n"
					 	+ "            <h2 class=\"accordion-header\" id=\"heading"+i+"\">\n"
				 		+ "                <button class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse"+i+"\" aria-expanded=\"false\" aria-controls=\"collapse"+i+"\">\n"
				 		+ ""+asignaturas.getJSONObject(i).get("asignatura") +" - "+ asg.getString("nombre")+"\n"
				 		+ "                </button>\n"
				 		+ "            </h2>\n"
				 		+ "            <div id=\"collapse"+i+"\" class=\"accordion-collapse collapse\" aria-labelledby=\"heading"+i+"\" data-bs-parent=\"#accordionExample\">\n"
				 		+ "                <div class=\"accordion-body\">\n"
				 		+ "                    <p>Calificación de la asignatura: "+nota+"</p>\n"
				 		+ "                </div>\n"
				 		+ "            </div>\n"
				 		+ " </div>\n";
				}
		}else{response.sendRedirect(request.getContextPath()+"/"); return;}
}
finalu = finalu.replace("{{asg}}", dynasg);
finalu = finalu.replace("{{imagen}}", "<img alt=\"fotoalumno\" src=\"./imgs/"+dni+".png\" width=\"92\" height=\"92\" style=\"border-radius:50%\">");
out.print(finalu);
```

Por tanto como se puede apreciar, el código inicial de `**Alumno.html**` ha sido modificado, introduciendo las variables **`{{asg}}, {{imagen}} y {{nomalu}}`** en puntos del html donde queremos que se introduzca el código. 

Estos lugares son:

En el titulo, para cambiar el `**@usuario**` por el nombre del alumno en cuestión y añadir su imagen:

```html
<div class="container mt-5">
	<div class="divs">
		<div style="justify-self:start">
	    <h1>Bienvenido, {{nomalu}}</h1>
	    <h2>Asignaturas</h2>
	</div>
	<div class="divimg" style="justify-self:end">
			{{imagen}}
	</div>
</div>
```

Y el contenedor donde se van a generar los acordeones:

```html
<div class="accordion" id="accordionExample">
		{{asg}}	        
</div>
```

### 3.3.2.  Imprimir.java

Este servlet se ha creado para manejar la creación dinámica de una pagina html, PlantillaPeticion.html (Véase punto 3.2.2). Este servlet se encarga, al igual que Alumno.java en diseñar la pagina para que obtenga un estilo parecido a como si fuera un pdf y que se pueda imprimir en caso de ser necesario. 

La implementación del código es muy similar a la anterior, ya que ambas se encargan de la creación dinámica de la pagina web, en este caso PlantillaPeticion.html. Vuelve a hacer peticiones a CentroEducativo mediante el método GET pero esta vez, genera una tabla con todas las asignaturas; con sus debidas notas y acrónimos, añade la foto del usuario y pone la fecha del día que ha sido expedido el boletín de las notas.

Toda la parte de las peticiones GET, se considera que es muy similar y por ende no se va a hacer hincapié en este apartado, ya que bastaría con mirar el anterior donde se explica como se cogen todos los datos y si cumple con los requisitos de seguridad. 

Algo que se considera que cabe destacar es la obtención del formato de la fecha, ya que esto es nuevo en el acta. Para conseguir el formato deseado (`**$dic_del_mes de $nombre_mes de $año**`) se ha utilizado el siguiente codigo:

```java
Date fecha = new Date();
SimpleDateFormat formato = new SimpleDateFormat("d 'de' MMMM 'de' yyyy", new DateFormatSymbols(Locale.forLanguageTag("es")));
String fechaf = formato.format(fecha);
```

Una vez se ha obtenido toda la información necesaria (las notas, la imagen, los nombres y acrónimos de las asignaturas, el nombre y el apellido del usuario, y la fecha del día actual) para poder generar la pagina con el formato de impresión, es cuando empiezan los cambios, más allá de la propia estructura de la pagina en si con la de alumno. Al igual que en el anterior servlet, se reemplazan los marcadores en la plantilla con los datos dinámicos obtenidos anteriormente, como el nombre del alumno, el DNI, las asignaturas y la fecha actual en español.

```java
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		/*
		más codigo aqui
		*/
		String finalu = Plantillatem.replace("{{nombre}}", dyn);
		/*
		más codigo aqui
		*/
		finalu = finalu.replace("{{dni}}", request.getRemoteUser());
		/*
		más codigo aqui
		*/
		//aqui si la ultima peticion ha respondido bien (ha contestado 200 OK), empieza a rellenar la TABLA
		if(connomasg.getResponseCode()==200){
				try(BufferedReader br = new BufferedReader(new InputStreamReader(connomasg.getInputStream()))) {
						String r = "";
						String resLine = null;
						while ((resLine = br.readLine()) != null) {
								r += resLine.trim();
						}
						String nota = asignaturas.getJSONObject(i).getString("nota");
						if(nota == "") nota = "Sin calificar";
						asg = new JSONObject(r);
						dynasg += "<tr><td>"+asignaturas.getJSONObject(i).getString("asignatura")+"</td><td>"+asg.getString("nombre")+"</td><td>"+nota+"</td></tr>\n";
				}
		}else{response.sendRedirect(request.getContextPath()+"/"); return;}
		finalu = finalu.replace("{{asg}}", dynasg);
		/*
		Obtencion de fechaf (sección de codigo anterior)
		*/
		finalu = finalu.replace("{{fecha}}", fechaf);
		finalu = finalu.replace("{{imagen}}", "<img alt=\"fotoalumno\" src=\"./imgs/"+dni+".png\" width=\"92\" height=\"92\" style=\"border:2px solid black\">");
		out.print(finalu);
}
```

Como se puede observar en el `**try**`, ahí es donde esta la diferencia principal de un servlet a otro, en este se está insertando filas con el contenido requerido a una tabla que previamente ha sido creado las cabeceras de las columnas en la PlantillaPeticion.html. 

Una vez la página ha sido creada, si el usuario quisiera imprimírsela, tendría una vista similar a la de un pdf a la hora de seleccionar la opción guardar del navegador. 

### 3.4.  Modificación del web.xml

En cuanto al archivo web.xml, se han realizado varias modificaciones, una de ellas ya mencionadas anteriormente (Véase punto 3.1). 

En él se han añadido los siguientes fragmentos:

```xml
<session-config>
    <session-timeout>60</session-timeout>
</session-config>
```

Este fragmento configura el tiempo de espera de las sesiones en una aplicación web Java, estableciendo que cualquier sesión inactiva será invalidada automáticamente después de 60 minutos. Esto ayuda a gestionar los recursos del servidor y de manera indirecta se ha mejorado la seguridad al reducir el riesgo de exposición a ciertos tipos de ataques, aunque esto no es el principal objetivo.

```xml
<context-param>
    <param-name>rutaArchivo</param-name>
    <param-value>/home/user/Escritorio/NOLG2Access.log</param-value>
</context-param>
```

Este parámetro se utiliza en la aplicación web para predefinir donde tiene que escribir los inicios de sesión registrados por el servlet *Log3.java*. Cuando *Log3.java* quiera registrar un nuevo inicio de sesión, buscará en la ruta, el archivo llamado `**NOLG2Access.log**`. Hay varias maneras de hacer esto pero se cree que es la más optima. Sin ir más lejos, esta opción es la máxima evolución de los logs presentados en la anterior entrega (*Log2.java*), ya que versiones establecen la ruta en el propio servlet (*Log1.java*) en vez de hacerlo de esta manera. Este es el bloque de código dentro del *Log3.java* (el filter) que se encarga de escribir los nuevps inicios de sesión:

```java
try {
		FileWriter pw = new FileWriter(new File(req.getServletContext().getInitParameter("rutaArchivo")),true);
		BufferedWriter bw = new BufferedWriter(pw);
		bw.write(salida);
		bw.close();
		pw.close();
} catch(Exception e) {
		System.out.println("Error");
}
```

Como se han añadido dos nuevos servlets, *Alumno.java* e *Imprimir.java*, hay que añadirlos al *web.xml*, para asignar el recurso que manejan. Esto se ha realizado con las siguientes ordenes en el archivo:

```xml
<servlet>
    <description></description>
    <display-name>Alumno</display-name>
    <servlet-name>Alumno</servlet-name>
	  <servlet-class>Alumno</servlet-class>
</servlet>
		<servlet-mapping>
		<servlet-name>Alumno</servlet-name>
		<url-pattern>/Alumno</url-pattern>
</servlet-mapping>
<servlet>
		<description></description>
		<display-name>Imprimir</display-name>
		<servlet-name>Imprimir</servlet-name>
		<servlet-class>Imprimir</servlet-class>
</servlet>
<servlet-mapping>
		<servlet-name>Imprimir</servlet-name>
		<url-pattern>/Imprimir</url-pattern>
</servlet-mapping>
```

Y por último, también se ha modificado a sección de `**security-constraint**`que se encarga de alumno (para la versión previa véase el punto 3.3 de la reunión nº4, en este mismo acta):

```xml
<security-constraint>
	  <web-resource-collection>
	    <web-resource-name>AccesoAlu</web-resource-name>
	    <url-pattern>/Alumno</url-pattern>
	    <http-method>GET</http-method>
	  </web-resource-collection>
	  <auth-constraint>
	    <role-name>rolalu</role-name>
	    <role-name>rolpro</role-name>
	  </auth-constraint>
</security-constraint>
```

Se ha cambiado `**url-pattern**` de `**/Alumno.html**` a `**/Alumno**`. Esto es así porque se ha creado el nuevo servlet *Alumno.java*, que gestiona la página *HTML* y por tanto debe ser la encargada de recibir las peticiones ya que el contenido de *Alumno.htm*l depende de *Alumno.java*, ya que este último la modifica (como ya se ha repetido varias veces). 

## 4.  Problemas

Como problemas que han ido surgiendo, podemos destacar unos cuantos. Para empezar tuvimos problemas a la hora de escribir en el fichero `**NOLG2Access.log**`,  ya que por mucho que se modificaba el archivo web.xml y se probaban distintos comandos, tanto en el web.xml (en el apartado de “*context-param*”), cómo en el archivo *Log3.java*, no había manera. Al final el error se solucionó cambiando la variable que se había puesto en un inicio por la que hay actualmente. Esto se debía a que se habia realizado un “*copy-paste*“ con uno de los Logs anteriores y no se había cambiado el nombre de la variable. Puede parecer sencillo pero se le dedico a resolución más tiempo del esperado. 

Otro error que se considera destacar es la manera de modificar/reescribir la pagina *Alumno.html*. Esto se debía a que en clase se había visto como escribir una pagina desde cero, con distintas variables (o la misma si se iba reescribiendo sobre ella) las cosas que tenía que escribir el servlet, pero no como modificar una pagina ya existente y meter donde se quisiera el nuevo código, o al menos ningun integrante del grupo recordaba la manera de hacerlo. Sucedia también que si se hacía esto, la plantilla se reescribía, cosa que tampoco era lo que se buscaba. La intención era que donde había contenido personalizado (séase el nombre del alumno o las asignaturas en la que el mismo está matriculado), se pudiera escribir estos datos obtenidos previamente mediante una petición web. Se pensó en una posible solución, utilizar JavaScript para hacer una petición y que utilizando los métodos aprendidos en clase como *innerHTML* rmodificar el contenido de la página, pero se descartó porque se requería información de CentroEducativo y ya estaba el servlet de *Alumno.java* funcionando (solo faltaba que se escribiera en el sitio que queríamos). Además se consideró que hacer la petición a CentroEducativo por el servlet en vez de un script de JavaScript sería más óptimo. Por tanto al final se propuso la idea de utilizar los marcadores (Véase punto 3.2), informarse sobre los métodos como `**replace()**` de la clase String de Java y realizar las modificaciones correspondientes en la página mediante el servlet. Una vez se solucionó, la pagina *PlantillaPetición.html* e *Imprimir.java* se desarrolló muy fácil, ya que era basarse en *Alumno.java* y *Alumno.html*; con sus respectivas modificaciones obviamente.

Y por último, se ha descubierto un error a la hora de ejecutar la aplicación en distintos navegadores. Este error consiste en que cuando el usuario ha iniciado sesión y este vuelve atrás con la flecha del navegador, en la mayoría de navegadores (como pueden ser Opera, Mozilla, Chrome o Edge) guarda la sesión y de hecho no deja acceder al login, directamente manda a la pagina principal (donde eliges que usuario eres para acceder) y facilita la entrada si vuelve a seleccionar el tipo de usuario con el que había iniciado sesión previamente. En caso de elegir la otra opción, simplemente no deja al usuario, es como si el botón estuviera deshabilitado (aunque visualmente no lo parece). Bien, todo esto comentado anteriormente, con el navegador Safari esto no sucede, requiere otra vez que el usuario inicie sesión. Por tanto al haber creado una sesión previa y solicitar otra vez la clave (key), el mecanismo j_security_check no es capaz de entenderlo y salta `**Error 404**`. Se tiene la sospecha de que es política y configuración del navegador, pero a día de hoy el equipo no sabe todavía a que puede deberse este error.

En cuanto al trabajo de los integrantes del equipo, todos han trabajado en el desarrollo de este segundo hito. Es cierto que a lo mejor algún o algunos alumnos han trabajado algo más que los demás, pero estos entienden que cada uno tiene una disponibilidad distinta, y por ello no están molestos, ni tampoco consideran que el trabajo extra que han desempeñado en el proyecto sea tan considerable como para hacer una propia mención en este apartado. Al final somos un equipo y cada uno aporta lo que sabe, a lo mejor un integrante sabe mucho de frontend (cómo el desarrollo visible de las páginas), otros pueden dominar los conceptos de la asignatura mejor y por ende ser capaces de hacer un código completamente funcional más refinado, otros pueden tener más capacidad de liderazgo y ordenar las piezas del equipo (que se encargue de “tirar del carro”) y asi mil tipos de roles. Por eso estos alumnos que han podido desempeñar más horas en el proyecto, no consideran que el/los que menos haya/n trabajado merezcan una mención, porque simplemente lo desarrollado en este hito es lo que mejor se les daba. Además, también es cierto que los integrantes que no han podido acudir al principio o durante o al final, siempre han pedido un informe de como va el trabajo, que decisiones se han tomado o en que podían ayudar de manera extraoficial (fuera de las reuniones, por su cuenta)y por tanto, no se desentendían en ningún momento; cosa que también han valorado los que han podido trabajar algo más.