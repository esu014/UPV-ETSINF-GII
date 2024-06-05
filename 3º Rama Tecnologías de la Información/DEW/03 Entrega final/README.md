# MEMORIA TRABAJO DEW 2324 TI11-G2

## Índice

1. [Introducción](#1-Introduccion)
2. [Descripción del Problema](#2-Descripción-del-Problema)
    1. [Hito 1](#21-Hito-1)
    2. [Hito 2](#22-Hito-2)
    3. [Hito 3](#23-Hito-3)
3. [Soluciones del hito 1](#3-Soluciones-del-hito-1)
    1. [Servlets LogX.java](#31-Servlets-LogX.java)
    2. [Script.sh](#32-Script.sh)
    3. [Actas.md](#33-Actas.md)
4. [Desarrollo de la Aplicación Web (hitos 2 y 3)](#4-desarrollo-de-la-aplicación-web-hitos-2-y-3)
    1. [Estructura de ficheros del proyecto](#41-Estructura-de-ficheros-del-proyecto)
    2. [Estructura del proyecto](#42-estructura-del-proyecto)
    3. [Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)
        1. [Entrada](#431-entrada)
        2. [Alumno](#432-alumno)
            [Imprimir](#4231-imprimir)
        3. [Profesor](#433-profesor)
    4. [Desarrollo del código](#44-desarrollo-del-código)
        
    

## 1. Introducción
Este trabajo sobre NotasOnLine, del curso 2023-2024, ha sido realizado por el grupo TI11-G2, cuyos miembros del equipo son Pau Amoros ... (completar)

Como herramientas de trabajo, se ha dispuesto de distintas maquinas virtuales proporcionadas por la asignatura, en las cuales está instalado el entorno de desarrollo en el que se ha realizado el proyecto, ECLIPSE, el servidor Apache Tomcat 9.0 y el código `.jar` correspondiente a la base de datos CentroEducativo.

El proyecto consiste en generar una Aplicación Web, llamada NotasOnLine, en la que tanto alumnos como profesores, que previamente han sido registrados sus datos en la base de datos del sistema (CentroEducativo) son capaces de interactuar entre ellos para consultar y/o modificar las notas. Todo dependerá del rol que tengan (alumno o profesor). Para cada rol hay distintos casos de uso. Por ejemplo los alumnos no pueden modificar notas, solo pueden consultar sus notas y no las de ningún otro alumno. Y los profesores pueden calificar a los alumnos a los que imparte clases, es decir, están matriculados en la/s asignatura/s que imparte ese profesor.

En el presente documento se expone detalladamente el proceso de resolución del escenario inicial planteado por el profesor en el marco de la asignatura Dessarrollo Web. La memoria se divide en dos grandes fases: la primera, que corresponde al [hito 1](#3-soluciones-del-hito-1), es la toma de contacto con la nueva tecnología que se está aprendiendo. Y la segunda, que corresponde más a los casos de uso de los distintos usuarios y lo que eso conlleva (analisis, desarrollo, comprobaciones...). O lo que es equivalente al [desarrollo entero de la aplicación web](#4-desarrollo-de-la-aplicación-web-hitos-2-y-3). 

A lo largo de esta memoria se describirán las etapas y metodologías empleadas para abordar y solucionar dicho problema. Cada sección de este informe proporcionará una visión comprensiva de los enfoques adoptados, las herramientas utilizadas y los resultados obtenidos. Esta estructura permitirá una comprensión clara y concisa de cómo se ha logrado transformar el escenario inicial en una solución efectiva y robusta. 

## 2. Descripción del Problema

Como se ha comentado anteriormente, el escenario a solucionar consistía en diseñar una Aplicación Web en la que usuarios de un centro escolar, pudieran interactuar de manera online; con sus respectivas limitaciones y seguridad; para consultar sus notas, en caso de ser alumno, y además poder modificarlas, en caso solamente, de ser profesor. Para completar la tarea, era obligatorio el uso de algunas herramientas, vistas previamente en teoría; como puede ser la biblioteca `Bootstrap`, para el diseño web o desarrollar interfaces dinámicas; las cuales obligan a utilizar la biblioteca `JQuery` y en caso de requerir datos; que obviamente se necesitan; utilizar `AJAX`.

El escenario de la entrega se ha dividido en distintos hitos, 3 para ser exacto. En cada hito, el nivel de complejidad aumenta. 

### 2.1. Hito 1
El hito 1, consiste básicamente en una toma de contacto con los servlets, con la base de datos, localizada en la maquina host, en el puerto 9090; y con el formato `MD`, para realizar las actas, ya que es algo nuevo también para la mayoria de la clase. 

Como se observa, hay 3 subtareas:
1. **Programar servlet**. Básicamente consiste en crear un primer servlet con la función de iniciar sesion con un usuario; y a partir de este servlet, añadirle características como que se escriba en un fichero los registros de inicio de sesion en el supuesto servidor (aqui todavía no hay nada implementado relacionado con el escenario). 
2. **Script con la herramienta Curl para realizar peticiones a la base de datos**. Esta tarea consiste en generar un script en el que mediante la herramienta Curl, se pruebe a hacer peticiones a la base de datos. De esta manera, se puede entender como funciona la base de datos y se observa como tienen que ser las peticiones que posteriormente realizarán los servlet, tanto a la hora de modificar el estado de la BD como hacer simples consultas. 
3. **Acta en formato MD**. La novedad de esta tarea es realizar las actas en este formato, en vez de en un Word convencional. No se considera como tarea, pero es una nueva tecnología que se tiene que conocer y por tanto implica invertir tiempo en aprender y dominar. 

### 2.2. Hito 2
En cuanto el hito 2, ya "_se entra en materia_", puesto que se avandona la toma de contacto y se empieza a desarrollar la aplicación para que se complan los distintos casos de uso del alumno. En esta etapa del proyecto, empieza a crecer ya la futura solución del escenario inicial. Los casos de uso del alumno, constan de distintas tareas:
1. g
2. h
3. h
4. rellenar
5. h
6. h

Además de éstas, hay que incluir las acciones que pueden hacer ambos tipos de usuarios, que es iniciar sesión en la plataforma online; y por tanto también hay que implementar el login de la aplicación. 

### 2.3. Hito 3
El hito 3, consiste en, además de implementar los casos de uso del profesor, mejorar lo anterior en caso de error o en caso de que no fuera necesario para la entrega anterior pero si un requerimiento para la entrega final. Como por ejemplo, que los alumnos reciban la imagen también en formato `pngb64` (es un requerimiento para la entrega final pero no lo era para el hito 2).
En cuanto a lo nuevo a desarrollar, los casos de uso del profesor; constan de las siguientes opciones:
1. g
2. h
3. h
4. rellenar
5. h
6. h


## 3. Soluciones del hito 1

### 3.1. Servlets LogX.java

Para la resolución de estos hitos, el equipo escribió los siguientes archivos, 3 servlets distintos (solucionando así el caso de los servlets), los cuales se han llamado `log0.java`, `log1.java` y `log2.java`; un script.sh (solucionando la tarea de hacer peticiones/modificaciones sobre la base de datos) y 2 actas en formato MD, una de ellas es el acta recogida el día de la presentación del equipo y la otra es la explicación detallada y al milimetro de como se llegó la solución de los problemas mencionados hasta ahora. 

En cuanto al código de los servlets, para poder interactuar con ellos, se ha realizado un HTML, en el cual, al hacer el evento "submit", se dirije la petición al servlet. 
```html
<h1>log0</h1>
<form action = "log0" method = "GET">
    <p>Name: <input required = "required" type="text" name = "Name"><br>
    Email: <input required = "required" type="email" name = "Email"><br>
    Password: <input required = "required" type="password" name="Password"><br>
    <input type="submit" value = "login">
    </p>
</form>
```
Para que los próximos log1.java y log2.java funcionen, basta con cambiar en el atributo action del formulario, el nombre del servlet al que tiene que acudir cuando se ejecute el `<input type="submit">`.

Este servlet parte de la plantilla que crea ECLIPSE, el cual tiene muchas más predefinidas para proyectos web. Se encarga basicamente de recibir los datos
```java
//aqui va el log0
```
El servlet anterior, recibe una serie de modificaciones para cumplir con el log1.java propuesto en el enunciado del hito 1. La mejora que se le introduce es que registre los datos cuando alguien presione el `<input type="submit">`, estableciendole en una variable la ruta donde debe crear/modificar el fichero de registro.
```java 
//ruta y escribir el resto no hace falta
``` 
Y el log2.java respecto a log1.java es que en vez de definir la variable que establece la ruta, ésta tiene que estar guardada en el archivo web.xml y en el código del servlet solamente debe poner el nombre del atributo él cual hace referencia a la ruta previamente guardada en el web.xml.
```xml
<!-- Define el nombre del atributo y su respectio directorio -->
<context-param>
    <param-name>rutaArchivo</param-name>
    <param-value>/home/user/Escritorio/NOLG2Access.log</param-value>
</context-param>
```
### 3.2. Script.sh 
Para la solución relacionada con la interacción de la BD, el equipo ha realizado un script en el que se han realizado consultas y modificado el estado inicial, añadiendo una asignatura.

Primero de todo, antes de hacer cualquiero consulta, se requiere una clave de acceso, la cual es la que autoriza al usuario a consultar y/o modificar la BD. Para ello, se ha consultado la API de Centro Educativo, para averiguar de que manera se hacen las peticiones/modificaciones, para observar que parámetros necesita, qué instrucción hay que hacer para obtener la consulta deseada y cómo es el tipo de respuesta. 
```sh
KEY=$(curl -s --data '{"dni":"111111111","password":"654321"}' \
-X POST -H "content-type: application/json" http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/login \
-c cookies -b cookies)
```
El usuario `111111111` es el usuario administrador. Se realizan las peticiones con este usuario para que así se pueda obtener cualquier tipo de información y no se dependa del rol del usuario. La llave se guarda en una variable (KEY), para luego posteriormente, utilizarla en cada petición a CentroEducativo. 

Las consultas realizadas son: conseguir asignaturas y alumno; y conseguir los alumnos.
```sh
#leer alumno y asignaturas
curl -s -X GET 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnosyasignaturas?key='$KEY -H "accept: application/json" -b cookies -c cookies
lectura alumno
#lectura alumno
curl -s -X GET -H "accept: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY -b cookies -c cookies
```
Y la modificación es introducir una nueva asignatura:
```sh
#modificacion alumno
curl -s --data '{"apellidos": "Garcia Lopez", "dni": "33445566X", "nombre": "Juan","password": "123456"}' \
-X POST -H "content-type: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY \
-c cookies -b cookies
```

### 3.3. Actas.md
En cuanto a esta tarea, no se ha considerado una tarea como tal, solo se ha invertido tiempo en aprender los comandos necesarios para poder hacer archivos estructurados y de mejor calidad. No lleva una solución como tal y no influyen en nada en cuanto al desarrollo del proyecto, como podía serlo las tareas previas (que preparan para el desarrollo en si de la aplicación web).

## 4. Desarrollo de la Aplicación Web (hitos 2 y 3)
En esta sección de la memoria se va a explicar con detenimiento como ha sido el desarrollo del proyecto. Se parte de la base de que primero se ha desarrollado el inicio de sesión, posteriormente los casos de uso del alumno y finalmente los del profesor. Este orden ha llevado a que ha habido que rectificar y corregir/mejorar el código que se había escrito inicialmente, ya que nuevas funcionalidades pueden requerir de cambios en cosas que ya estaban asentadas.

### 4.1. Estructura de ficheros del proyecto
Primero de todo, se ha definido la estructura del proyecto, la manera en la que se van a organizar los archivos. Por suerte, esto no fue un "_quebradero de cabeza_" ya que, al utilzar una plantilla para poyectos web de ECLIPSE, este te hace la estructura inicial. Lo único que ha habido que decidir es donde colocar los archivos `HTML` y/o `.css`. El equipo decidió no crear archivos `.css` ya que se prefirió integrarlos en la propia página HTML. Las imágenes de los alumnos y profesores, se ha establecido mediante el web.xml en el directorio `home/user/Escritorio` de la maquina host. 

### 4.2. Estructura del proyecto
La estructura del proyecto en cuanto a funcionamiento es la siguiente:

![Estructura de las peticiones del proyecto](https://personales.alumno.upv.es/esopurb/dew/imgs/estructuraPry.png)

Como se puede observar el proyecto tiene distintos servlets y cumple cada uno una funcion, la cual se desarrollará más adelante. Además, hay uno que no se puede reflejar y es el de seguridad, que impide el acceso a todos aquellas peticiones que no se han realizado con los parametros necesarios. Pero como se ha dicho antes, todo se explicará más adelante.

### 4.3. Funcionamiento de la aplicación

El funcionamiento de la aplicación se puede prever en la imagen anterior. 

### 4.3.1. Entrada

Consta de una página principal, en la cual tanto profesores como alumnos pueden iniciar sesión. 

![Interfaz de Entrada](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/entrada.png)

Una vez el usuario, sea alumno o profesor, clique en su correspondiente formulario de entrada, `Log3.java` pedirá las creedenciales para verificar si existe el usuario y si está accediendo por donde es debido. En caso de no ser así, redirigirá a la página de entrada otra vez.

![Interfaz de Login](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/login.png)

### 4.3.2. Alumno
En el caso de que se haya iniciado sesión como alumno, `Log3.java` redigirá la petición al servlet `Alumno.java`, el cual se encarga de construir la página principal del alumno (`alumno.html`) en base a los datos del usuario. Para ello necesita hacer una petición HTTP a CentroEducativo para obtener las asignaturas y notas del alumno en cuestión. 

![Interfaz de Alumno](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/alumno.png)

Además esta página, hace una petición `AJAX` a un servlet llamado `GestionDinamica.java` para obtener la imagen del usuario registrado en formato `.pngb64`. Se hace de esta manera por motivos de seguridad, ya que si no fuera así, si el usuario fuera conocedor del dni de algún alumno o profesor, podría acceder a la foto del usuario al que corresponde dicho dni. 

### 4.2.3.1. Imprimir
El usuario alumno también tiene que poder imprimir sus notas, como si fuera un boletín. Para ello, se ha creado un servlet, llamado `Imprimir.java`, que se encarga de formatear la página para estructurarla de manera que se pueda imprimir. Para no construir la página desde cero, se sigue le patrón que se emplea en `alumno.html` y `profesor.html`. Es decir, se emplea una plantilla HTML, en este caso, se llama `PlantillaPeticion.html`, y se reescribe mediante el servlet mencionado anteriomente. Para reescribir la página con los datos personalizados, es necesario hacer otra petición a CentroEducativo para obtener la información requerida. 

![Interfaz de Imprimir](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/imprimir.png) (intentar poner lo de la firma)

### 4.3.3. Profesor
En cambio, cuando el usuario que se ha registrado es un profesor, `Log3.java` redigirá al usuario a `Profesor.java`. Este servlet hace lo mismo que `Alumno.java`, pero son diferentes ya que cada uno construye la página de una manera distinta, por lo que el diseño de la interfaz no es igual debido a que tienen funciones distintas (tienen un rol distinto). 

Contruye `profesor.html` con los datos del profesor. También hace una petición HTTP para conseguir esta vez, las asignaturas que imparte, además de los datos necesarios para la personalización de la página (como sucede con alumno).

![Interfaz de profesor](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/profesor.png)

Además de la petición `AJAX` que se realiza al servlet `GestionDinamica.java` para obtener la imagen del usuario registrado, éste tambien esta programado de manera que segun el párametro que se pasa en la petición hará una cosa u otra. En el caso de alumno, solo devuelve una imagen (la del usuario registrado en ese caso) pero porque en la pagina `alumno.html` no se realiza ninguna petición más, no hace falta. En este caso no es así. En el código de `profesor.html` se vera como hay más de una petición `AJAX`, que se usan para obtener la información de los alumnos (peticion a `GestionDinamica.java`) y de esa manera poder calificarlos (peticion a un nuevo servlet llamado `PublicarNotas.java` que se encarga de enviar las nuevas notas a la base de datos para que actualice los valores mediante el método `PUT`).

### 4.4. Desarrollo del código
En el apartado anterior ([4.3 Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)), se introduce la funcionalidad de la aplicación y por ende, la del código (aunque no se haya entrado en detalle ni mucho menos). 

En este apartado se va a hablar de como se ha implementado la lógica de funcionamiento explicada anteriormente. 