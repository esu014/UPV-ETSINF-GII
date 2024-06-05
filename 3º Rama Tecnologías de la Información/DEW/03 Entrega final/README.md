# MEMORIA TRABAJO DEW 2324 TI11-G2

# Índice

1. [Introducción](#1-introducción)
2. [Descripción del Problema](#2-descripción-del-problema)
    1. [Hito 1](#21-hito-1)
    2. [Hito 2](#22-hito-2)
    3. [Hito 3](#23-hito-3)
3. [Soluciones del hito 1](#3-soluciones-del-hito-1)
    1. [Servlets LogX.java](#31-servlets-logxjava)
    2. [Script.sh](#32-scriptsh)
    3. [Actas.md](#33-actasmd)
4. [Desarrollo de la Aplicación Web (hitos 2 y 3)](#4-desarrollo-de-la-aplicación-web-hitos-2-y-3)
    1. [Estructura de ficheros del proyecto](#41-estructura-de-ficheros-del-proyecto)
    2. [Estructura del proyecto](#42-estructura-del-proyecto)
    3. [Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)
        1. [Entrada](#431-entrada)
        2. [Alumno](#432-alumno)
            1. [Imprimir](#4231-imprimir)
        3. [Profesor](#433-profesor)
    4. [Desarrollo del código](#44-desarrollo-del-código)
        1. [Estructura de ficheros del proyecto](#41-estructura-de-ficheros-del-proyecto)
        2. [Estructura del proyecto](#42-estructura-del-proyecto)
        3. [Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)
        4. [Desarrollo del código](#44-desarrollo-del-código)
            1. [Bibliotecas](#441-bibliotecas)
            2. [Páginas HTML](#442-páginas-html)
                1. [index.html](#4421-indexhtml)
                2. [login.html](#4422-loginhtml)
                3. [error.html y error2.html](#4423-errorhtml-y-error2html)
                4. [Profesor.html](#4424-profesorhtml)
                5. [Alumno.html](#4425-alumnohtml)
                6. [PlantillaPeticion.html](#4426-plantillapeticionhtml)
        
# 1. Introducción
Este trabajo sobre NotasOnLine, del curso 2023-2024, ha sido realizado por el grupo TI11-G2, cuyos miembros del equipo son Pau Amoros ... (completar)

Como herramientas de trabajo, se ha dispuesto de distintas maquinas virtuales proporcionadas por la asignatura, en las cuales está instalado el entorno de desarrollo en el que se ha realizado el proyecto, ECLIPSE, el servidor Apache Tomcat 9.0 y el código `.jar` correspondiente a la base de datos CentroEducativo.

El proyecto consiste en generar una Aplicación Web, llamada NotasOnLine, en la que tanto alumnos como profesores, que previamente han sido registrados sus datos en la base de datos del sistema (CentroEducativo) son capaces de interactuar entre ellos para consultar y/o modificar las notas. Todo dependerá del rol que tengan (alumno o profesor). Para cada rol hay distintos casos de uso. Por ejemplo los alumnos no pueden modificar notas, solo pueden consultar sus notas y no las de ningún otro alumno. Y los profesores pueden calificar a los alumnos a los que imparte clases, es decir, están matriculados en la/s asignatura/s que imparte ese profesor.

En el presente documento se expone detalladamente el proceso de resolución del escenario inicial planteado por el profesor en el marco de la asignatura Dessarrollo Web. La memoria se divide en dos grandes fases: la primera, que corresponde al [hito 1](#3-soluciones-del-hito-1), es la toma de contacto con la nueva tecnología que se está aprendiendo. Y la segunda, que corresponde más a los casos de uso de los distintos usuarios y lo que eso conlleva (analisis, desarrollo, comprobaciones...). O lo que es equivalente al [desarrollo entero de la aplicación web](#4-desarrollo-de-la-aplicación-web-hitos-2-y-3). 

A lo largo de esta memoria se describirán las etapas y metodologías empleadas para abordar y solucionar dicho problema. Cada sección de este informe proporcionará una visión comprensiva de los enfoques adoptados, las herramientas utilizadas y los resultados obtenidos. Esta estructura permitirá una comprensión clara y concisa de cómo se ha logrado transformar el escenario inicial en una solución efectiva y robusta. 

# 2. Descripción del Problema

Como se ha comentado anteriormente, el escenario a solucionar consistía en diseñar una Aplicación Web en la que usuarios de un centro escolar, pudieran interactuar de manera online; con sus respectivas limitaciones y seguridad; para consultar sus notas, en caso de ser alumno, y además poder modificarlas, en caso solamente, de ser profesor. Para completar la tarea, era obligatorio el uso de algunas herramientas, vistas previamente en teoría; como puede ser la biblioteca `Bootstrap`, para el diseño web o desarrollar interfaces dinámicas; las cuales obligan a utilizar la biblioteca `JQuery` y en caso de requerir datos; que obviamente se necesitan; utilizar `AJAX`.

El escenario de la entrega se ha dividido en distintos hitos, 3 para ser exacto. En cada hito, el nivel de complejidad aumenta. 

## 2.1. Hito 1
El hito 1, consiste básicamente en una toma de contacto con los servlets, con la base de datos, localizada en la maquina host, en el puerto 9090; y con el formato `MD`, para realizar las actas, ya que es algo nuevo también para la mayoria de la clase. 

Como se observa, hay 3 subtareas:
1. **Programar servlet**. Básicamente consiste en crear un primer servlet con la función de iniciar sesion con un usuario; y a partir de este servlet, añadirle características como que se escriba en un fichero los registros de inicio de sesion en el supuesto servidor (aqui todavía no hay nada implementado relacionado con el escenario). 
2. **Script con la herramienta Curl para realizar peticiones a la base de datos**. Esta tarea consiste en generar un script en el que mediante la herramienta Curl, se pruebe a hacer peticiones a la base de datos. De esta manera, se puede entender como funciona la base de datos y se observa como tienen que ser las peticiones que posteriormente realizarán los servlet, tanto a la hora de modificar el estado de la BD como hacer simples consultas. 
3. **Acta en formato MD**. La novedad de esta tarea es realizar las actas en este formato, en vez de en un Word convencional. No se considera como tarea, pero es una nueva tecnología que se tiene que conocer y por tanto implica invertir tiempo en aprender y dominar. 

## 2.2. Hito 2
En cuanto el hito 2, ya "_se entra en materia_", puesto que se avandona la toma de contacto y se empieza a desarrollar la aplicación para que se complan los distintos casos de uso del alumno. En esta etapa del proyecto, empieza a crecer ya la futura solución del escenario inicial. Los casos de uso del alumno, constan de distintas tareas:
1. g
2. h
3. h
4. rellenar
5. h
6. h

Además de éstas, hay que incluir las acciones que pueden hacer ambos tipos de usuarios, que es iniciar sesión en la plataforma online; y por tanto también hay que implementar el login de la aplicación. 

## 2.3. Hito 3
El hito 3, consiste en, además de implementar los casos de uso del profesor, mejorar lo anterior en caso de error o en caso de que no fuera necesario para la entrega anterior pero si un requerimiento para la entrega final. Como por ejemplo, que los alumnos reciban la imagen también en formato `pngb64` (es un requerimiento para la entrega final pero no lo era para el hito 2).
En cuanto a lo nuevo a desarrollar, los casos de uso del profesor; constan de las siguientes opciones:
1. g
2. h
3. h
4. rellenar
5. h
6. h


# 3. Soluciones del hito 1

## 3.1. Servlets LogX.java

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
## 3.2. Script.sh 
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

## 3.3. Actas.md
En cuanto a esta tarea, no se ha considerado una tarea como tal, solo se ha invertido tiempo en aprender los comandos necesarios para poder hacer archivos estructurados y de mejor calidad. No lleva una solución como tal y no influyen en nada en cuanto al desarrollo del proyecto, como podía serlo las tareas previas (que preparan para el desarrollo en si de la aplicación web).

# 4. Desarrollo de la Aplicación Web (hitos 2 y 3)
En esta sección de la memoria se va a explicar con detenimiento como ha sido el desarrollo del proyecto. Se parte de la base de que primero se ha desarrollado el inicio de sesión, posteriormente los casos de uso del alumno y finalmente los del profesor. Este orden ha llevado a que ha habido que rectificar y corregir/mejorar el código que se había escrito inicialmente, ya que nuevas funcionalidades pueden requerir de cambios en cosas que ya estaban asentadas.

## 4.1. Estructura de ficheros del proyecto
Primero de todo, se ha definido la estructura del proyecto, la manera en la que se van a organizar los archivos. Por suerte, esto no fue un "_quebradero de cabeza_" ya que, al utilzar una plantilla para poyectos web de ECLIPSE, este te hace la estructura inicial. Lo único que ha habido que decidir es donde colocar los archivos `HTML` y/o `.css`. El equipo decidió no crear archivos `.css` ya que se prefirió integrarlos en la propia página HTML. Las imágenes de los alumnos y profesores, se ha establecido mediante el web.xml en el directorio `home/user/Escritorio` de la maquina host. 

## 4.2. Estructura del proyecto
La estructura del proyecto en cuanto a funcionamiento es la siguiente:

![Estructura de las peticiones del proyecto](https://personales.alumno.upv.es/esopurb/dew/imgs/estProy.png)

Como se puede observar el proyecto tiene distintos servlets y cumple cada uno una funcion, la cual se desarrollará más adelante. Además, hay uno que no se puede reflejar y es el de seguridad, que impide el acceso a todos aquellas peticiones que no se han realizado con los parametros necesarios. Pero como se ha dicho antes, todo se explicará más adelante.

## 4.3. Funcionamiento de la aplicación

El funcionamiento de la aplicación se puede prever en la imagen anterior, pero en este apartado se explica con detenimiento.  

### 4.3.1. Entrada

Consta de una página principal, en la cual tanto profesores como alumnos pueden iniciar sesión. 

![Interfaz de Entrada](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazEntrada.png)

Una vez el usuario, sea alumno o profesor, clique en su correspondiente formulario de entrada, `Log3.java` pedirá las creedenciales para verificar si existe el usuario y si está accediendo por donde es debido. En caso de no ser así, redirigirá a la página de entrada otra vez.

![Interfaz de Login](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazLogin.png)

### 4.3.2. Alumno
En el caso de que se haya iniciado sesión como alumno, `Log3.java` redigirá la petición al servlet `Alumno.java`, el cual se encarga de construir la página principal del alumno (`alumno.html`) en base a los datos del usuario. Para ello necesita hacer una petición HTTP a CentroEducativo para obtener las asignaturas y notas del alumno en cuestión. 

![Interfaz de Alumno](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazAlumno.png)

Además esta página, hace una petición `AJAX` a un servlet llamado `GestionDinamica.java` para obtener la imagen del usuario registrado en formato `.pngb64`. Se hace de esta manera por motivos de seguridad, ya que si no fuera así, si el usuario fuera conocedor del dni de algún alumno o profesor, podría acceder a la foto del usuario al que corresponde dicho dni. 

### 4.2.3.1. Imprimir
El usuario alumno también tiene que poder imprimir sus notas, como si fuera un boletín. Para ello, se ha creado un servlet, llamado `Imprimir.java`, que se encarga de formatear la página para estructurarla de manera que se pueda imprimir. Para no construir la página desde cero, se sigue le patrón que se emplea en `alumno.html` y `profesor.html`. Es decir, se emplea una plantilla HTML, en este caso, se llama `PlantillaPeticion.html`, y se reescribe mediante el servlet mencionado anteriomente. Para reescribir la página con los datos personalizados, es necesario hacer otra petición a CentroEducativo para obtener la información requerida. 

![Interfaz de Imprimir](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazImprimir.png) (intentar poner lo de la firma)

### 4.3.3. Profesor
En cambio, cuando el usuario que se ha registrado es un profesor, `Log3.java` redigirá al usuario a `Profesor.java`. Este servlet hace lo mismo que `Alumno.java`, pero son diferentes ya que cada uno construye la página de una manera distinta, por lo que el diseño de la interfaz no es igual debido a que tienen funciones distintas (tienen un rol distinto). 

Contruye `profesor.html` con los datos del profesor. También hace una petición HTTP para conseguir esta vez, las asignaturas que imparte, además de los datos necesarios para la personalización de la página (como sucede con alumno).

![Interfaz de profesor](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazProfesor.png)

Además de la petición `AJAX` que se realiza al servlet `GestionDinamica.java` para obtener la imagen del usuario registrado, éste tambien esta programado de manera que segun el párametro que se pasa en la petición hará una cosa u otra. En el caso de alumno, solo devuelve una imagen (la del usuario registrado en ese caso) pero porque en la pagina `alumno.html` no se realiza ninguna petición más, no hace falta. En este caso no es así. En el código de `profesor.html` se vera como hay más de una petición `AJAX`, que se usan para obtener la información de los alumnos (peticion a `GestionDinamica.java`) y de esa manera poder calificarlos (peticion a un nuevo servlet llamado `PublicarNotas.java` que se encarga de enviar las nuevas notas a la base de datos para que actualice los valores mediante el método `PUT`).

## 4.4. Desarrollo del código
En el apartado anterior ([4.3 Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)), se introduce la funcionalidad de la aplicación y por ende, la del código (aunque no se haya entrado en detalle). 

En este apartado se va a hablar de como se ha implementado la lógica de funcionamiento explicada anteriormente. Se ha dividido en los siguientes subapartados:
1. [Bibliotecas](#441-bibliotecas)
2. [Páginas HTML](#442-páginas-html)
3. [Clases Java]()
4. [Archivo web.xml]()

### 4.4.1. Bibliotecas
Para la producción de este proyecto, para el desarrollo de los servlets, se han empleado solamente las bibliotecas que incluye Java, como pueden ser la biblioteca IO, NET o UTIL, las que están en la maquina virtual, `javax.servlet.*`, y la otorgada por el profesor, la biblioteca `json-20240303.jar`. El equipo ha obtado por no utilizar ninguna biblioteca externa, ya que se pensó que si otra hubiera sido realmente un requerimiento, estaría explicada y habría sido facilitada por el profesor en su debido momento. Como esto no es así, no se ha optado por buscar otras bibliotecas, que quizas podrían haber solucionado algún problema de una manera distinta (pudiendo ser, a lo mejor, más optimas/eficientes).

En cuanto a bibliotecas relacionadas con los HTML, y lo que ello implica, JavaScript y CSS se han utilizado las dós bibliotecas que son un requerimiento para el desarrollo de la aplicación web, `Bootstrap` y `JQuery`. **Bootstrap** es una biblioteca de código abierto diseñada para facilitar el desarrollo de sitios web y aplicaciones web receptivas y modernas. Proporciona una colección de herramientas y componentes preconstruidos, como diseños de cuadrícula, botones, formularios, menús de navegación y otros elementos de interfaz de usuario. **JQuery** es una biblioteca de JavaScript rápida, pequeña y rica en características que simplifica la manipulación del HTML y la interacción con el DOM (Document Object Model). Proporciona una sintaxis sencilla y concisa para realizar tareas complejas, como la manipulación de elementos de la página, el manejo de eventos, la animación y la ejecución de solicitudes AJAX. AJAX, es una técnica que permite a las aplicaciones web enviar y recibir datos del servidor de manera asíncrona, sin necesidad de recargar la página completa. JQuery facilita el uso de AJAX mediante métodos simplificados que permiten realizar solicitudes HTTP, recibir datos del servidor y actualizar dinámicamente el contenido de la página web.

### 4.4.2. Páginas HTML
Una vez mencionadas las bibliotecas relacionadas con los archivos HTML (`Bootstrap` y `JQuery`), se puede empezar a describir los distintos HTML que se han desarrollado. Anteriormente se han mencionado unos cuantos, pero como es de esperar, hay más. Los archivos en cuastión son los siguientes:
1. [index.html](#4421-indexhtml)
2. [login.html](#4422-loginhtml)
3. [error.html y error2.html](#4423-errorhtml-y-error2html)
4. [Profesor.html](#4424-profesorhtml)
5. [Alumno.html](#4425-alumnohtml)
6. [PlantillaPeticion.html](#4426-plantillapeticionhtml)

### 4.4.2.1. Index.html
Index.html es la interfaz que aparece cuando en el navegador se introduce la url `http://dew-tulogin-2324.dsicv.upv.es:8080/Nombre_del_proyecto`. En este caso, es la interfaz mostrada en el apartadado [4.3.1 Entrada](#431-entrada). 

En cuanto a código, como se puede intuir al ver la imagen de la interfaz, dispone de 2 formularios, uno dirigido a profesores y otro para alumnos. Cada formulario está dirigido mediante `action` y una petición de tipo `GET`, al servlet correspondiente (ya sea Alumno.java o Profesor.java) //poner indicees de los servlet
```html
<div class="login-container">
    <h2>Alumnos</h2>
    <form action="Alumno" method="get">
        <button type="submit">Entrar</button>
    </form>
</div>
<div class="login-container">
    <h2>Profesores</h2>
    <form action="Profesor" method="get">
        <button type="submit">Entrar</button>
    </form>
</div>
```
Además del código HTML, cuenta también con lenguaje de estilos (CSS) integrado en el archivo, no en hoja aparte. El estilo diseñado va a ser el que marque el resto de la estética del proyecto, para asi manetener la estética de las distintas interfaces, logrando asi que se vea una aplicación homogenea. 

No solo cuenta con CSS, también cuenta con unas breves lineas de código JavaScript. La función del script que hay en el HTML es borrar del navegador la sesión en caso de que se haya quedado guardada, eliminando así la posibilidad de errores por parte del cliente (como podría ser el 408). El error mencionado anteriormente aparecía debido a que al poder volver atrás con el navegador, la sesión no se cerraba, y si se intentaba acceder a otra cuenta, por mucho que las credenciales estuvieran correctas, la aplicación no funcionaba de manera correcta. Esto era así porque entendía que a la sesion anterior, ya le había dado una "_KEY_" en el anterior login y no podía mandar otra (porque al no cerrar sesión, supuestamente el usuario ya tiene una clave activa). Esto, ademas tambien soluciona el problema de utilizar la aplicacion en distintos navegadores, ya que según el navegador el moverte hacia adelante o atrás por el navegador (utilzando las flechas), también generaba este error(408).
```html
<script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
<script type="text/javascript">
    $(document).ready(function() {
        sessionStorage.clear();
    })
</script>
``` 
Para poder utilizar el código anterior, requiere, como se puede observar, la biblioteca ya explicada en el punto anterior (véase [4.4.1. Bibliotecas](#441-bibliotecas)), `JQuery`, y por ello, previamente al script, se ha importado dicha biblioteca.
### 4.4.2.2. Login.html
En cuanto a la página de login.html, esta es aun más sencilla, ya que cuenta con un único formulario para introducir los datos que posteriormente se verificaran mediante "_j__security__check_". Este comprueba en el archivo xml del servidor (`tomcat-users.xml`) si es que está el usuario registrado en el sistema (esto a gran escala sería inviable). A su vez, lleva asociado un filter java (se asocia en el web.xml (Véase [poner punto luego]())), Log3.java (Véase [poner punto luego]()), que verificará si el usuario está accediendo por donde debe. En caso de ser así, creará una sesión y solicitará la clave de paso para que el usuario posteriormente pueda interactuar indirectamente con la BD (no es consciente ni de que existe una clave (key) o que en el propio código de su página hace distintas peticiones). Si no es así, le devuelve a la pagina inicial. 

```html
<div class="login-container">
    <h2>Inicio De Sesión</h2>
    <form action="j_security_check" method="post" id="form">
        <input id="user" type="text" placeholder="DNI" name="j_username" required>
        <input type="password" placeholder="Contraseña" name="j_password" required>
        <button type="submit">Entrar</button>
    </form>
</div>
``` 

En cuanto a estilo, no se refleja ningún cambio respecto a la página mencionada anteriormente. Esta, como se ha mencionado anteriormente (Véase punto), consta del mismo código JavaScript, ya que según en que navegador, en caso de navegar para atrás, hay veces que en vez de redirigir directamente a la pagina principal, pasa otra vez por el login.html. De esta manera, desaparece la posibilidad de que aparezca el error 408. 

### 4.4.2.3. Error.html y error2.html
Para el tratamiento de errores, se han diseñado dos páginas, las cuales varían muy poco la una de la otra. Estás enmascaran dos tipos de errores: el usuario no esta registrado (las credenciales introducidas no están en el fichero `tomcat-users.xml`) y el caso en que el usuario tenga intención de investigar y probar que pasa si introduce según que URL en el navegador, para intentar acceder a un recurso al cual no puede acceso. Este caso tambien se aplica a usuarios no registrados.

El estilo de las páginas de error, se ha querido diseñar de una manera divertida, basandose en "_Memes_" o frases que pueden causar alguna sonrisa en el usuario que intenta acceder a recursos a los cuales no está autorizado. A continuación se muestra el código básico de la página `error.html`, la cual aparece cuando el usuario no esta registrado en el archivo del servidor `tomcat-users.xml`.

```html
<div class="error-message" style="margin-left: 0px; top:20%">
        Venga hombre no me jodas 
</div>
<div style="margin-top:50px">
    <img src="https://cdn.freecodecamp.org/curriculum/cat-photo-app/relaxing-cat.jpg" alt="Un gato relajado" class="cat-image">
</div>
``` 

Además esta cuenta tambien con un breve script de JavaScript para redirigir al usuario a la página en la que estaba anteriormente al cabo de 4 segundos. En este caso, no es necesario el uso de la biblioteca `JQuery`.

```html
<script>
    setTimeout(()=>{
        window.history.back()
    }, 4000)
</script>
``` 

En cuanto a la página de `error2.html`, lo único que varía es la frase escrita en `<div class="error-message" style="margin-left: 0px; top:20%">`, la cual es: "_¿Qué buscas cotilla?_". Esta, también cuenta con el código JavaScript mostrado anteriormente encargado de redirigir al usuario a la página que estaba anteriormente.

### 4.4.2.4. Profesor.html
Tanto profesor como las dos próximas páginas HTML, no están en el mismo directorio que las anteriores mencionadas. Éstas se esconden en la carpeta WEB-INF. De esta manera, se protege los recursos para que no puedan ser accedidos mediante la propia URL del archivo (haciendo imposible su acceso por cualquier usuario). Esto no supone un problema para la aplicación, ya que lo que se encarga de mostrar la página en la aplicación es el servlet que está asociado a cada HTML, en este caso Profesor.java (Véase [poner punto]()). Es decir, el resto de páginas que se van a describir, tienen función de plantilla, más que de interacción como tal. 

Los profesores tienen unos casos de uso específicos (Véase apartado [2.3. Hito 3](#23-hito-3)) y por tanto una plantilla específica. En este archivo, se encuentran distintos marcadores que posteriormente serán reescritos por el servlet. Estos se identifican de la siguiente manera: `{{marcador}}`. 

La página se puede dividir en distintos `<div></div>`, que contendran dentro distintos elementos y marcadores. Inicialmente, dentro de la etiqueta `<body></body>`, se encuentra `<div id="contenedorPrin" class="container mt-5">`, que como se puede intuir, es el contenedor donde dentro van a estar los distintos subcontenedores con sus respectivos subcontenedores y/u objetos. 

Como primer contenedor que está detro del contenedor principal, se encuentra el `<div class="divs">`, cuya funcion es estructurar un saludo hacia el/la profesor/a que acaba de iniciar sesión y el botón que posibilita terminar la sesión. En este código tambien se encuentra el primero de los marcadores, `{{nomalu}}`. Éste se reescribirá posteriormente por el nombre y apellidos del/a profesor/a.

```html
<div id="contenedorPrin" class="container mt-5">
    <div class="divs">
        <div class="divimg">
            <img id="perfil" style="border-radius:50%">
        </div>
        <div class="titulo">
            <h1>Bienvenido, <br>{{nomalu}}</h1>
        </div>
        <div class="finals">
            <form action="FinalizarSesion" method="get">
                <button type="submit" onclick="">Finalizar Sesión</button>
            </form>
        </div>
    </div>
    <!-- Resto de la página, todo lo comentado a continuación está ubicado aqui -->
</div>
```

Siguiendo la estructura de la página, se encuentra el siguiente gran contenedor dentro del contenedor principal, `<div class="borde"></div>`. Contiene dos grandes subcontenedores para estructurar la interfaz: `<div class = "contenedor"></div>` y `<div class="conte"></div>`. Ambos tienen características bastane concretas que merecen ser comentadas. 

```html
    <!-- Segundo gran conteneder -->
    <div class="borde">
        <div class = "contenedor">
            <!-- Código del div -->
        </div>
        <div class="conte">
            <!-- Código del div -->
        </div>
    </div>
```

El div `<div class = "contenedor"></div>` es la zona de la interfaz general, donde el profesor visualiza las asignaturas y sus respectivos alumnos de las mismas. Además tiene el bóton que posibilita la modificación de las notas de los alumnos, según la asignatura seleccionada. Como se puede observar en la sección de código hay otro marcador, en este caso `{{asg}}`. El servlet Profesor.java (Véase [poner punto]()) reescribirá en este punto de la página, un acordeón de asignaturas que tendra tantas filas como asignaturas que imparte. También se puede apreciar lo que es el comienzo de una tabla, con su etiqueta `<thead></thead>` y su respectivas filas y celdas, y el comienzo de un `<tbody></tbody>`, que en la plantilla está vacío. Esto se debe a que esta tabla se va actualizando dinámicamente mediante JavaScript, según se haya seleccionado una asignatura u otra para corregir, o en caso de que se haya deseleccionado, desaparece. Finalmente, se aprecia también el botón mencionado anteriormente que al ser clicado, acciona el método que habilita la posibilidad de modificar las notas de los alumnos de la asignatura seleccionada.

```html
    <div class = "contenedor">
        <h2>Asignaturas</h2>
        <div class="innerContenedor">
            <!-- Accordion de Asignaturas -->
            <div class="accordion" id="accordionExample">
                {{asg}}
            </div>
        </div>
        <div style="margin-top: 10px">
            <table id='miTabla'>
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Calificación</th>
                    </tr>
                </thead>
                <tbody>
                    <!-- aqui van las filas de la tabla -->
                </tbody>
            </table>
        </div>
        <div style="margin-top: 10px">
            <button id="btnMod" onclick="return modificarNotas()">Calificar Alumnos</button>
        </div>
    </div>
```

El otro subcontenedor principal, `<div class="conte"></div>`, contiene la interfaz para la modificación de las notas de los alumnos. Se ha decidido que todo este en la misma página HTML para hacer la interacción del usuario más dinámica y sin redirecciones. Este contenedor cuenta con la siguiente estructura:

```html
    <div class="conte">
        <div class="imgt">
            <img id="imgAlu" class="top-image" src="https://cdn-icons-png.flaticon.com/512/3135/3135768.png" width="185" style="border-radius:50%">
        </div>
        <div class="nombre" style="margin-top:10px">
            <p id="nombre">Alumno</p>
        </div>
        <div class="calif">
            <p id="nota">Sin calificar.</p>
        </div>
        <div class="buttons-input">
            <button type="button" onclick = "return retroceder()" class="btn btn-primary" id="btnIzqda">
                    <i class="bi bi-arrow-left-circle-fill"></i>
            </button>
            <input type="number" id="calificacion" placeholder="Agregar nueva nota">
            <button type="button" onclick="return avanzar()" class="btn btn-primary" id="btnDrcha">
                <i class="bi bi-arrow-right-circle-fill"></i>
            </button>
        </div>   
        <div class="buttons-input">
            <button onclick="return nuevaNota($('#calificacion').val())" id="prov" class="prov">Modificar nota</button>
        </div>
    </div>
```

Como se puede observar, en esta zona de código se le da funcionalidad a la interfaz de modificación de las notas de los alumnos de la asignatura correspondiente con distintos métodos JavaScript.

La página, como se ha ido viendo anteriormente, contiene 4 etiquetas `<script></script>`, 3 de ellas para la importación de bibliotecas:

```html
<!-- Vinculación de Bootstrap JavaScript -->
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>

<!-- Importar biblioteca JQuery -->
<script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
```

Y una para el desarrollo de las distintas funciones y eventos que tiene el archivo en cuestión. Esta etiqueta es bastante extensa, por lo que se va a dividir en secciones para analizar y explicar el código de manera precisa.

Para empezar, en la etiqueta se han declarado una serie de variables para que sean globales. Se ha realizado de esta manera para seguir asi la estructura de un código Java, aunque es sabido que si se declara sin etiqueta la varible, se crea de ámbito global. La página tiene una serie de métodos que se ejecutan cuando se está cargando la página en el navegador. 

```javascript
var datosCargadosEnTabla =false
var alum = [];
var asignatura;
var indice=0;
var nmedia = 0;
$(document).ready(function() {
    //distintos eventos y peticiones AJAX
})
```

Para no saturar la lectura de código, se van a explicar a continuación fragmeto a fragmento con su debida explicación. Todos estos eventos y peticiones se encuentran dentro evento `$(document).ready(function (){...})`.

El primer fragmento de código es una petición AJAX en la que se solicita a un servlet llamado `GestionDinamica.java` (Véase [poner punto]()), el cuál ha sido programado para recibir peticiones relacionadas con la gestión dinámicas de las páginas, tanto profesor.html como en la de alumno e imprimir, que se verá posteriormente (Véase puntos [4.4.2.5. Alumno.html](#4425-alumnohtml) y [PlantillaPeticion.html](#4426-plantillapeticionhtml)). En este caso se realiza una peticion con los parámetros definidos en `data`. Esto es así porque el servlet ha sido programado para que cuando reciba estos parámetros, devuelva la imagen del usuario activo. Además se añade el atributo `headers`, que tiene la función de proteger las peticiones en caso de que se introduzcan desde la URL del navegador, en vez de como es debido. Para proteger este caso, se ha desarrollado un nuevo filtro (además del ya existente), llamado `Authorized.java` (Véase [poner punto]()), que verifica si contiene el atributo header en la petición, y en caso de tenerlo, que coincida con el valor asignado `true`. En cualquier otro caso, no permite el acceso y devuelve _`SC_FORBIDDEN`_, haciendo así que aparezca la página de error2.html ya mencionada anteriormente (Véase [4.4.2.3. Error.html y error2.html](#4423-errorhtml-y-error2html))

```javascript
    //pedir imagen profesor
    $.ajax({
        url: 'GestionDinamica',
        type: 'GET',
        datatype: 'json',
        data:'opt=imagen',
        headers: {
            'Authorization': 'true'
        },
        success: function(data){
            $("#perfil").attr("src", "data:image/png;base64,"+data.img); 
        },
        error: function(jqXHR, textStatus, errorThrown) {
        // Manejar errores de la solicitud
            alert('Error:', textStatus, errorThrown);
        }
    })
```

En caso de que todo haya ido bien, el servlet responderá con un objeto `JSON` a la petición, que contendrá el atributo imagen con su debida infomación en formato `.pngb64`. Una vez recibida, se asigna el valor contenido en el atributo img de la resuesta a la foto con id="perfil". En caso de error, notifica al usuario mediante una alerta de lo que ha sucedido. 

El siguiente fragmento de código está relacionado con la obtención de los alumnos matriculados en la/s distinta/s asignatura/s que imparte el profesor. Como se puede observar, se sigue el mismo procedimiento: se introducen los valores necesarios para realizar la petición: se configura la url, el tipo de petición, el tipo de objeto a recibir, el header y los parámetros, que en este caso es `opt=asignatura`. Con estos parámetros el servlet mencionado anteriormente, devuelve un array de objectos `JSON` en los que están todos los alumnos de todas las asignaturas en las que imparte el profesor. Estos objetos, contienen el dni, la nota, los apellidos, el acrónimo de la asignatura entre otros. Según la respuesta se realiza una cosa u otra.

```javascript
    //pedir asigantura y datos de los alumnos
    $.ajax({
        url: 'GestionDinamica',
        type: 'GET',
        datatype: 'json',
        data:'opt=asignatura',
        headers: {
            'Authorization': 'true'
        },
        success: function(data){//esta el array de alumno y nota y luego tambien esta el del alumno con sus datos
            let j = 0 //variable que mueve el subindice que insertara los alumnos
            let k = 0 //variable que recorre el bucle para ver todos los alumnos
            let h = 0 //variable que maneja el array que diferenciara las asignaturas
            for(let i = 0; i<data.length; i=k)
            {
                if (!alum[h]) {
                    alum[h] = [];
                }
                
                while(k < data.length && data[i].acronimo == data[k].acronimo)
                {
                    if(!alum[h][j]) {
                        alum[h][j] = []
                    }
                    alum[h][j] = data[k]
                    j++ 
                    k++
                }
                j=0
                h++
            }
        },
        error: function(jqXHR, textStatus, errorThrown) {
        // Manejar errores de la solicitud
            alert('Error:', textStatus, errorThrown);
        }
    })
```
En caso de que la petición se ha realizado correctamente correcta, se recorre el array tantas veces como asignaturas distintas haya (variable i). Se comprueba que el array este incializado y de no ser asi se inicializa. Una vez esta todo en la situación ideal, se realiza un segundo bucle en el que se va a dividir estos alumnos en asignaturas, identificandolos por el acrónimo. El valor `data[i].acronimo` fija el valor del acrónimo de la asignatura que se estan guardando en el indice h. Con el valor de `data[k].acronimo` se recorre el array entero (k++). Mientras ambos valores sean iguales, significa que los alumnos son de la misma asignatura. En el momento en el que esto no sea así, se incrementa el valor de h en uno para mover el índice de la asignatura, se posiciona a 0 el valor de j, para empezar en la posicion 0 del subindice e introducir alumnos desde ahi, y se iguala i a k. De esta manera, se salta todas las comprobaciones repetidas. Es decir, si se han metido 3 alumnos, no tiene sentido hacer i++, porque si empieza en 0, y hemos dicho que se han metido 3 alumnos, el alumno en la posicion 1, corresponde a la misma asignatura. De esta manera (i=k) salta directamente al nuevo alumno con una asignatura distinta. Una vez acabado el `for`, la matriz alum queda inicializada con todos los alumnos, siendo la fila, la asignatura a la que corresponden. 

Después de incializar los datos, para que no haya error en la interacción, el equipo ha decidido deshabilitar los botones relacionados con la modificación de las notas de los alumnos. De esta manera, hasta que no sea estrictamente necesario, no se puedan usar, evitando asi, posibles resultados no deseados.

```javascript
    //deshabilitar botones
    $('#calificacion, #prov, #btnMod ,#btnDrcha, #btnIzqda').prop('disabled', true);
```
Luego, para mejorar la interacción natural del usuario se han añadido una serie de métodos manejadores de eventos a algunos objetos/acciones. Estos son:
- Presionar la tecla enter para la confirmación de la modificación de la nota, en vez de darle al botón de "_Modificar Nota_"

```javascript
    $('#calificacion').on('keydown', function(event) {
        if (event.key === 'Enter') { // Simula un clic en un botón
            nuevaNota($('#calificacion').val())
        }
    })
```

- Poner los botones en modo deshabilitado y la foto de usuario por defecto cuando se haya deseleccionado una asignatura o elegido otra y no se le ha dado al boton de calificar. 

```javascript
    //en caso de que vuelva a valer alumno...
    $('#nombre').on('DOMSubtreeModified', function(){
        var textoPred = $('#nombre').text();
        if (textoPred == 'Alumno') {
            $("#imgAlu").attr("src", "https://cdn-icons-png.flaticon.com/512/3135/3135768.png"); 
            $('#calificacion, #btnMod, #prov, #btnDrcha, #btnIzqda').prop('disabled', true); //deshabilita otra vez botones
        }
    })
```
Todo este código se ejecuta cuando el documento se esta cargando, pero no es el único método que tiene la página, tiene bastantes más para hacer del HTML una página dinámica y funcional.
El primer método que se ejecuta es el que agrega las filas a la tabla antes mencionada. Cuando se seleccione una asignatura (haciendo click en el nombre de la misma), activa el siguiente método (descrito en el código a contiunuación), utilizando los parámetros `acronimo` y `num`. Estos dos parámetros corresponden a que de esta manera se puede asociar al acrónimo con un numero y de esta manera se puede recorrer la matriz e seleccionar la asignatura (primer indice). Estos valores vienen escritos desde el servlet de Profesor.java, cuando genera el acordeon. De esta manera coincide el acrónimo, con el número y con la posición en el array de alum (Véase [Poner punto de profesor.java]()).

```javascript
function agregarFila(acronimo, num) {
    var kumala = $('#miTabla tbody');
    var tab = document.getElementById('miTabla');
    var filas = tab.rows
    if(!datosCargadosEnTabla)//revisar estoy por un .hide más que crear la tabla y descrearla (más optimo el hide)
    {
        asignatura = num
        alum[asignatura].forEach(datos => {
            if(datos.acronimo==acronimo){
                tabla(datos);
            }
        });
        datosCargadosEnTabla = true
        let fila = $('<tr></tr>');
        let celdaNombre = $('<td class=notaMed></td>').append(document.createTextNode("Nota Media de los Alumnos"));
        let celdaNota = $('<td class=notaMed></td>').append(document.createTextNode(notamedia() + ""));
        fila.append(celdaNombre);
        fila.append(celdaNota);
        kumala.append(fila);
        $('#btnMod').prop('disabled', false);
    }
    else if(datosCargadosEnTabla && num !=asignatura)
    {
        for(let i = filas.length-1; i > 0;i--){
            tab.deleteRow(i)
        }
        $('#nombre').text("Alumno") //obtiene el texto del p id nombre
        $('#nota').text("Nota") //obtiene el texto de p id nota
        asignatura = num
        alum[asignatura].forEach(datos => {
            if(datos.acronimo==acronimo){
                tabla(datos);
            }
        });
        let fila = $('<tr></tr>');
        let celdaNombre = $('<td class=notaMed></td>').append(document.createTextNode("Nota Media de los Alumnos"));
        let celdaNota = $('<td class=notaMed></td>').append(document.createTextNode(notamedia()));
        fila.append(celdaNombre);
        fila.append(celdaNota);
        kumala.append(fila);
        $('#btnMod').prop('disabled', false);
    }
    else
    {
        for(let i = filas.length-1; i > 0;i--){
            tab.deleteRow(i)
        }	
        datosCargadosEnTabla = false
        $('#nombre').text("Alumno") //obtiene el texto del p id nombre
        $('#nota').text("Nota") //obtiene el texto de p id nota
        $('#btnMod').prop('disabled', true);
    }
    
}
```
Como se puede observar, 3 casos distintos: que los datos no esten cargados en la tabla (`if`), que esten cargados en la tabla pero que se haya seleccionado otra asignatura (`else if`) o que se haya seleccionado otra vez la misma asignatura (`else`). 

- `IF` : Al no estar los datos cargados en la tabla y haberse seleccionado una asignatura, se tienen que mostrar los datos en las distintas filas (una para cada alumno), y habilitar el boton que da la opción a modificar las notas. Para ello, se asigna como índice de asignaturas, la variable num, De esta manera, se puede elegir la asignatura que ha sido clicada. Además, el grupo ha decidido poner la nota media de los alumnos de esa asignatura al final de la tabla y por tanto también hay que agregarla. Para poner los datos en la tabla, se requiere del método `tabla(datos)`, siendo datos el objeto alumno. Y para calcular la nota media, se requiere del método `notamedia()`. Ambos se explicarán más adelante. 
- `ELSE IF` : Los datos están cargados en la tabla pero asignatura es distinto de num. Lo que se quiere decir con esta comparación es que al haber sido modificado el índice de las asignaturas con la variable `num` anteriormente, al llamar al método `agregarFila(acronimo,num)`, con otro número (y evidentemente con otro acrónimo también, van de la mano) significa que el profesor quiere ver los alumnos de otra asignatura y posteriormente a lo mejor modificar sus notas. Para realizar este caso, se borran previamente las filas que había, se llama otra vez a `tabla(datos)` y posteriormente se vuelve a crear la fila de la nota media, con la respectiva nota de los alumnos de esa asignatura.
- `ELSE` : Si no se cumplen ambas condiciones previas, significa que el num es igual a asignatura y por tanto, significa que ha clicado en la última asignatura que previamente había sido desplegada, o lo que es lo mismo, ha pinchado dos veces sobre la misma asignatura. Por tanto, lo que se entiende con este acto, es que el/la profesor/a quiere esconder a los alumnos mostrados. En este caso, tambien hay que poner la interfaz de modificar notas en caso de que haya sido modificada previamente (ha corregido y ha cerrado el desplegable). Y esto lleva a deshabilitar también el boton que habilita la interfaz de modificación de notas. 

Previamente se han mencionado dos métodos: `tabla(datos)` y `notamedia()` y su función en el código. 

`tabla(datos)` se encarga de añadir para cada objeto que se ha pasado como argumento (datos), crear una fila y dos celdas en las que se introduce el nombre y apellidos y en la otra la nota. 

```javascript
function tabla(datos)
{
    const tbody = $('#miTabla tbody');
    let fila = $('<tr class='+datos.acronimo+'></tr>');
    let celdaNombre = $('<td></td>').append(document.createTextNode(datos.nombre +" "+datos.apellidos));
    if(datos.nota ==""){datos.nota = "Sin Calificar"}
    let celdaNota = $('<td class="celdaNota"></td>').append(document.createTextNode(datos.nota));
    fila.append(celdaNombre);
    fila.append(celdaNota);
    tbody.append(fila);
}
``` 

`notamedia()` se encarga de devolver el valor de la media aritmética de las notas de los alumnos. En caso de no estar las notas de todos los alumnos con un valor válido (por decfecto, el valor es "_Sin Calificar_"), devuelve un mensaje indicando que la nota media aun no está disponible (ya que si se respondiera el resultado igualmente, lo que se vería es `NaN`, ya que al ser el valor por defecto, una cadena de texto, no suma valores, concatena cadenas. Y la división de esto, produce un `NaN`).

```javascript
function notamedia()
{
    nmedia = 0;
    for(let i = 0;alum[asignatura].length > i;i++){
        nmedia += parseFloat(alum[asignatura][i].nota)
    }
    nmedia = (nmedia/alum[asignatura].length).toFixed(2);
    if(isNaN(nmedia))
    {
        return "Nota media aún no disponible"
    }
    else
    {
        return nmedia;
    }
}
``` 

Para poder habilitar el modificar las notas de una asignatura, previamente se ha tenido que seleccionar una asignatura, para que asi el botón que habilita la edición de notas este habilitado. Como se ha observado en el funcionamiento de la aplicación (Véase [4.3. Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)), la interfaz de modificar notas, contiene una imagen, nombre del alumno y la nota que tiene actualmente. Accionar el bóton de "_calificar alumnos_", tiene que volcar la información de los alumnos en la interfaz. Para ello, hace lo siguiente: realiza una petición mediante AJAX a `GestionDinamica.java`, como se ha explicado anteriormente al inicio de este punto; pero con otro parámetro (`imagen=`+dni del alumno). En caso de que la petición se haya realizado correctamente, vuelca el valor de los datos necesarios y la foto en la interfaz. Además habilita los botones de interacción en la interfaz, como son los de modificar nota, avanzar o retroceder y poder introducir valores en el recuadro de números.

```javascript
//habilitar el modificar las notas (boton de modificar)
function modificarNotas()
{
    indice=0
    $.ajax({
        url: 'GestionDinamica',
        type: 'GET',
        datatype: 'json',
        data:'imagen='+alum[asignatura][indice].dni,
        headers: {
            'Authorization': 'true'
        },
        success: function(data){
            $("#imgAlu").attr("src", "data:image/png;base64,"+data.img);
        },
        error: function(jqXHR, textStatus, errorThrown) {
        // Manejar errores de la solicitud
            alert('Error:', textStatus, errorThrown);
        }
    })
    $('#nombre').text(alum[asignatura][indice].nombre + " "+alum[asignatura][indice].apellidos) //obtiene el texto del p id nombre
    $('#nota').text(alum[asignatura][indice].nota) //obtiene el texto de p id nota
    $('#calificacion, #prov, #btnDrcha, #btnIzqda').prop('disabled', false); //habilitar botones
}
```

Los botones de avanzar y retroceder, se encargan de mover el array alum para poder seleccionar los distintos alumnos. Además tambien tienen que poner las imagenes y por tanto se requiere de otra petición AJAX. La única diferencia entre ambos métodos es el sentido en el que se mueve el array. 

`//revisar los códigos porque parece residuo las primras lineas de avanzar y retroceder`

```javascript
function avanzar()
{
    if(indice == alum[asignatura].length-1)
    {
        indice = -1
    }
    indice++
    .ajax({
        url: 'GestionDinamica',
        type: 'GET',
        datatype: 'json',
        data:'imagen='+alum[asignatura][indice].dni,
        headers: {
            'Authorization': 'true'
        },
        success: function(data){
            $("#imgAlu").attr("src", "data:image/png;base64,"+data.img);
        },
        error: function(jqXHR, textStatus, errorThrown) {
        // Manejar errores de la solicitud
            alert('Error:', textStatus, errorThrown);
        }
    })
    $('#nombre').text(alum[asignatura][indice].nombre + " "+alum[asignatura][indice].apellidos) //obtiene el texto del p id nombre
    $('#nota').text(alum[asignatura][indice].nota) //obtiene el texto de p id nota
    $('#calificacion').val('')
    $('#calificacion, #prov, #btnDrcha, #btnIzqda').prop('disabled', false); //habilitar botones
}
```

En caso de retroceder, la variación respecto al código de arriba es lo siguiente:

```javascript
    if(indice == 0)
    {
        indice = alum[asignatura].length-1
    }
    indice--
```

Y el último método es la publicación de la nota modificada en la base de datos. Para esta tarea, se ha creado un nuevo servlet, llamado `PublicarNotas.java`, al cuál se pasa la petición y éste, realiza la inserción el la BD. Previamente a realizar la petición, se comprueba que la nota es valida. En caso de no serlo, se le notifica al usuario que debe introducir una nota valida. 

Además de la petición, al haber una nota nueva hay que notificar al/a profesor/a de que se ha cambiado correctamente la nota, actualizar la nota del alumno que aparece en la tabla de alumnos y la nota media ya que la media se ha quedado obsoleta con el nuevo cambio. Y posteriormente, avanzar al siguiente alumno, para que sea aún más dinámico. 

```javascript
//notas introducidas en el input type
function nuevaNota(nota)
{
    nota = parseFloat(nota).toFixed(2)
    //aqui va la petición ajax
    if(nota>=0 && nota<=10 && nota!="")
    {
        $.ajax({
            url: './PublicarNotas', 
            type: 'POST',
            datatype: 'json', 
            async:true,
            headers: {
                'Authorization': 'true'
            },
            data: 'acronimo='+alum[asignatura][indice].acronimo+'&nota='+nota+'&dni='+alum[asignatura][indice].dni,
            success: function(data){
                alert("Nota de "+ alum[asignatura][indice].nombre + " "+alum[asignatura][indice].apellidos+ " publicada con éxito.")
                
                $('#nota').text(nota)
                alum[asignatura][indice].nota = nota
                // Selecciona la celda específica y modifica su contenido
                $('#miTabla tr').eq(indice+1).find('td').eq(1/*columna de notas, es fija*/).html(nota)
                var tab = document.getElementById('miTabla');
                var fila = tab.rows
                var prueba = notamedia()
                $('#miTabla tr').eq(fila.length-1).find('td').eq(1/*columna de notas, es fija*/).html(prueba)
                avanzar()
            },
            error: function(err){
                alert("Error: "+err.responseText)
            }
        })
    }	
    else
    {
        alert("Por favor, introduzca una nota válida")
    }
}    
```

### 4.4.2.5. Alumno.html


### 4.4.2.6. PlantillaPeticion.html
