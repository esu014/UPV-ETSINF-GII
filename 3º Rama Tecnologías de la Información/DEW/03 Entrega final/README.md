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
            3. [Archivos Java: servlets y Filters](#443-archivos-java-servlet-y-filters)
                1. [Log3.java](#4431-log3java)
                3. [Profesor.java](#4432-profesorjava)
                3. [Alumno.java](#4433-alumnojava)
                4. [Imprimir.java](#4434-imprimirjava) 
                5. [GestionDinamica.java](#4435-gestiondinamicajava) 
                6. [PublicarNotas.java](#4436-publicarnotasjava) 
                7. [FinalizarSesion.java](#4437-finalizarsesionjava) 
                8. [Authorized.java](#4438-authorizedjava) 
            4. [Archivo web.xml](#444-archivo-webxml)
5. [Testing](#5-testing)
6. [Conclusiones y trabajo en grupo](#6-conclusiones-y-trabajo-en-grupo)
    1. [Conclusiones](#61-conclusiones)
    2. [Trabajo en grupo](#62-trabajo-en-grupo)

# 1. Introducción
Este trabajo sobre NotasOnline, del curso 2023-2024, ha sido realizado por el grupo TI11-G2, cuyos miembros del equipo son Pau Amorós Córdoba, Carlos Cebellán Ferriz, Jorge Díez Forcada, Giorgi Dolidze, Segundo Gómez Lillo, Pau Pérez Marco y Enrique Sopeña Urbano.

Como herramientas de trabajo, se ha dispuesto de distintas máquinas virtuales proporcionadas por la asignatura, en las cuales está instalado el entorno de desarrollo en el que se ha realizado el proyecto, Eclipse, el servidor Apache Tomcat 9.0 y el código `.jar` correspondiente a la base de datos CentroEducativo.

El proyecto consiste en generar una Aplicación Web, llamada NotasOnline, en la que tanto alumnos como profesores, que previamente han sido registrados sus datos en la base de datos del sistema (CentroEducativo) son capaces de interactuar entre ellos para consultar y/o modificar las notas. Todo dependerá del rol que tengan (alumno o profesor). Para cada rol hay distintos casos de uso. Por ejemplo, los alumnos no pueden modificar notas, solo pueden consultar sus notas y no las de ningún otro alumno. Y los profesores pueden calificar a los alumnos a los que imparten clases, es decir, están matriculados en la/s asignatura/s que imparte ese profesor.

En el presente documento se expone detalladamente el proceso de resolución del escenario inicial planteado por el profesor en el marco de la asignatura Desarrollo Web. La memoria se divide en dos grandes fases: la primera, que corresponde al [hito 1](#3-soluciones-del-hito-1), es la toma de contacto con la nueva tecnología que se está aprendiendo. Y la segunda, que corresponde más a los casos de uso de los distintos usuarios y lo que eso conlleva (análisis, desarrollo, comprobaciones...). O lo que es equivalente al [desarrollo entero de la aplicación web](#4-desarrollo-de-la-aplicación-web-hitos-2-y-3). 

A lo largo de esta memoria se describirán las etapas y metodologías empleadas para abordar y solucionar dicho problema. Cada sección de este informe proporcionará una visión comprensiva de los enfoques adoptados, las herramientas utilizadas y los resultados obtenidos. Esta estructura permitirá una comprensión clara y concisa de cómo se ha logrado transformar el escenario inicial en una solución efectiva y robusta.


# 2. Descripción del Problema

Como se ha comentado anteriormente, el escenario a solucionar consistía en diseñar una Aplicación Web en la que usuarios de un centro escolar pudieran interactuar de manera online, con sus respectivas limitaciones y seguridad, para consultar sus notas, en caso de ser alumno, y además poder modificarlas en caso de ser profesor. Para completar la tarea, era obligatorio el uso de algunas herramientas vistas previamente en teoría, como puede ser la biblioteca Bootstrap para el diseño web o para desarrollar interfaces dinámicas. Estas, a su vez, obligan a utilizar la biblioteca JQuery y, en caso de requerir datos, utilizar AJAX.

El escenario de la entrega se ha dividido en distintos hitos, tres para ser exacto. En cada hito, el nivel de complejidad aumenta.

## 2.1. Hito 1

El hito 1 consiste básicamente en una toma de contacto con los servlets, con la base de datos, localizada en la máquina host, en el puerto 9090; y con el formato `MD`, para realizar las actas, ya que es algo nuevo también para la mayoría de la clase.

Como se observa, hay 3 subtareas:

1. **Programar servlet**: Básicamente consiste en crear un primer servlet con la función de iniciar sesión con un usuario; y a partir de este servlet, añadirle características como que se escriba en un fichero los registros de inicio de sesión en el supuesto servidor (aquí todavía no hay nada implementado relacionado con el escenario).
2. **Script con la herramienta Curl para realizar peticiones a la base de datos**: Esta tarea consiste en generar un script en el que mediante la herramienta Curl, se pruebe a hacer peticiones a la base de datos. De esta manera, se puede entender cómo funciona la base de datos y se observa cómo tienen que ser las peticiones que posteriormente realizarán los servlet, tanto a la hora de modificar el estado de la BD como hacer simples consultas.
3. **Acta en formato MD**: La novedad de esta tarea es realizar las actas en este formato, en vez de en un Word convencional. No se considera como tarea, pero es una nueva tecnología que se tiene que conocer y por tanto implica invertir tiempo en aprender y dominar.

## 2.2. Hito 2

En cuanto al hito 2, ya "_se entra en materia_", puesto que se abandona la toma de contacto y se empieza a desarrollar la aplicación para que se cumplan los distintos casos de uso del alumno. En esta etapa del proyecto, empieza a crecer ya la futura solución del escenario inicial. Los casos de uso del alumno constan de distintas tareas:

1. Identificarse como un/a alumno/a concreto/a (inicio de sesión).
2. Consultar la lista de asignaturas en las que está matriculado/a.
3. Consultar la nota obtenida en una de las asignaturas en las que está matriculado/a.
4. Operación derivada: crear una página formateada para su impresión, con una relación de asignaturas y calificaciones obtenidas, a modo de certificado, incluyendo en la página la fotografía del alumno/a.
5. Finalizar la sesión.

Además de éstas, hay que incluir las acciones que pueden hacer ambos tipos de usuarios, que es iniciar sesión en la plataforma online; y por tanto también hay que implementar el login de la aplicación.

## 2.3. Hito 3

El hito 3 consiste en, además de implementar los casos de uso del profesor y si fuera necesario, mejorar lo anterior en caso de error, o en su defecto, implementar ciertas cosas que en el hito anterior no eran necesarias pero sí un requisito para la entrega final. Como por ejemplo, que los alumnos reciban la imagen también en formato `pngb64` (es un requerimiento para la entrega final pero no lo era para el hito 2).

En cuanto a lo nuevo a desarrollar, los casos de uso del profesor constan de las siguientes opciones:

1. Identificarse como un profesor concreto (inicio de sesión).
2. Consultar la lista de asignaturas que imparte. Se necesitará recorrer todas las asignaturas y anotar aquéllas en las que este profesor aparezca.
3. Consultar la lista de alumnos en una de las asignaturas que imparte.
4. Consultar o modificar la nota obtenida por uno de los alumnos en una de las asignaturas que imparte.
5. Operación derivada: calcular la nota media de una de las asignaturas que imparte.
6. Operación derivada AJAX: interacción ágil para consultar o modificar la nota obtenida de cada uno de los alumnos en una de las asignaturas que imparte.
    - Debe cargar todos los datos en el navegador, facilitando el recorrido entre los alumnos y volcando las modificaciones (o todas las calificaciones) al servidor.
    - Debe incluir la fotografía del alumno visualizado.
7. Finalizar la sesión.

# 3. Soluciones del hito 1

## 3.1. Servlets LogX.java

Para la resolución de estos hitos, el equipo escribió los siguientes archivos: 3 servlets distintos (solucionando así el caso de los servlets), los cuales se han llamado `log0.java`, `log1.java` y `log2.java`; un script.sh (solucionando la tarea de hacer peticiones/modificaciones sobre la base de datos); y 2 actas en formato MD. Una de ellas es el acta recogida el día de la presentación del equipo y la otra es la explicación detallada y al milímetro de cómo se llegó a la solución de los problemas mencionados hasta ahora.

En cuanto al código de los servlets, para poder interactuar con ellos, se ha realizado un HTML, en el cual, al hacer el evento "submit", se dirige la petición al servlet.

```html
<h1>log0</h1>
<form action="log0" method="GET">
    <p>Name: <input required="required" type="text" name="Name"><br>
    Email: <input required="required" type="email" name="Email"><br>
    Password: <input required="required" type="password" name="Password"><br>
    <input type="submit" value="login">
    </p>
</form>
```

Para que los próximos `log1.java` y `log2.java` funcionen, simplemente necesitas cambiar en el atributo `action` del formulario el nombre del servlet al que debe dirigirse cuando se ejecute el `<input type="submit">`.

Este servlet se basa en la plantilla que crea Eclipse, la cual tiene muchas más predefinidas para proyectos web. Su función principal es básicamente recibir los datos enviados desde el formulario.


```java
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    PrintWriter pw = response.getWriter();
    
    String usuario = request.getParameter("Name");
    String email = request.getParameter("Email");
    String psswd = request.getParameter("Password");
    String preTituloHTML5 = "<!DOCTYPE html>\n<html>\n<head>\n" + "<meta http-equiv=\"Content-type\" content=\"text/html; charset=utf-8\" />";
    String ip = request.getRemoteAddr();
    String method = request.getMethod();
    String date = LocalDateTime.now().toString();
    String uri = request.getRequestURI();
    response.setContentType("text/html");
    
    pw.println(preTituloHTML5);
    pw.println(date + " Nombre: " + usuario + " Email: " + email + " Contraseña: "+ psswd + " " + ip + " " + getServletName() + " " + uri + " " + method +" \n");
}
```

El servlet anterior recibe una serie de modificaciones para cumplir con el `log1.java` propuesto en el enunciado del hito 1. La mejora que se introduce es que registre los datos cuando alguien presione el `<input type="submit">`, estableciendo en una variable la ruta donde debe crear/modificar el fichero de registro.

```java 
    //codigo anterior, exactamente igual que log0.java
    String salida = date + " Nombre: " + usuario + " Email: " + email + " Contraseña: "+ psswd + " " + ip + " " + getServletName() + " " + uri + " " + method +" \n";
    String rutaArchivo = "/home/user/Escritorio/DEWTrabLog1.log";
    try {
        FileWriter fw = new FileWriter(rutaArchivo,true);
        BufferedWriter bw = new BufferedWriter(fw);
        bw.write(salida);
        bw.close();
        fw.close();
    } catch(Exception e) {
        System.out.println("Error");
    }
``` 

Y en el `log2.java` respecto a `log1.java`, en lugar de definir la variable que establece la ruta, ésta debe estar guardada en el archivo `web.xml`. En el código del servlet, simplemente se debe utilizar el nombre del atributo que hace referencia a la ruta previamente guardada en el `web.xml`.

```xml
<!-- Define el nombre del atributo y su respectio directorio -->
<context-param>
    <param-name>rutaArchivo</param-name>
    <param-value>/home/user/Escritorio/NOLG2Access.log</param-value>
</context-param>
```

Y el archivo Java, se cambia la variable `rutaArchivo` por un objeto de la clase File, resultando el código de la siguiente manera:

```java
    // código igual que log1.java
    File file1 = new File(getServletContext().getInitParameter("rutaArchivo"));
    FileWriter pw = new FileWriter(file1,true);
    //código igual que log1.java
```

## 3.2. Script.sh

Para la solución relacionada con la interacción de la base de datos, el equipo ha creado un script en el que se han realizado consultas y modificado el estado inicial, añadiendo una asignatura.

En primera instancia, antes de hacer cualquier consulta, se requiere una clave de acceso que autoriza al usuario a consultar y/o modificar la base de datos. Para ello, se ha consultado la API de Centro Educativo para averiguar cómo se hacen las peticiones/modificaciones, qué parámetros se necesitan, qué instrucciones hay que seguir para obtener la consulta deseada y cómo es el tipo de respuesta.

```sh
KEY=$(curl -s --data '{"dni":"111111111","password":"654321"}' \
-X POST -H "content-type: application/json" http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/login \
-c cookies -b cookies)
```
El usuario `111111111` es el administrador. Se realizan las peticiones con este usuario para obtener cualquier tipo de información sin depender del rol del usuario. La llave se guarda en una variable llamada `KEY` para utilizarla posteriormente en cada petición a CentroEducativo.

Las consultas realizadas son para obtener asignaturas y alumnos.

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

## 3.3. Actas

En cuanto a esta tarea, no se ha considerado como tal, ya que solo se ha invertido tiempo en aprender los comandos necesarios para crear archivos estructurados y de mejor calidad. No se ha llevado a cabo una solución concreta, y no influye en el desarrollo del proyecto, a diferencia de las tareas previas que preparan el desarrollo de la aplicación web.

# 4. Desarrollo de la Aplicación Web (hitos 2 y 3)

En esta sección de la memoria se va a explicar detalladamente cómo ha sido el desarrollo del proyecto. Se parte de la base de que primero se ha desarrollado el inicio de sesión, posteriormente los casos de uso del alumno y finalmente los del profesor. Este orden ha llevado a que haya sido necesario rectificar y corregir/mejorar el código que se había escrito inicialmente, ya que nuevas funcionalidades pueden requerir cambios en cosas que ya estaban asentadas.

## 4.1. Estructura de ficheros del proyecto

Primero, se ha definido la estructura del proyecto y la manera en que se van a organizar los archivos. Por suerte, esto no fue un "quebradero de cabeza", ya que al utilizar una plantilla para proyectos web de Eclipse, esta te crea la estructura inicial. Lo único que ha habido que decidir es dónde colocar los archivos HTML y/o CSS. El equipo decidió no crear archivos CSS, ya que se prefirió integrarlos en la propia página HTML. Las imágenes de los alumnos y profesores se han establecido mediante el archivo `web.xml` en el directorio `home/user/tomcat/webapps/NOL-G2/imgs`. De esta manera, si el proyecto se migra a otra máquina y se instala en la carpeta `tomcat/webapps` para publicar el proyecto en la web, las imágenes estarán siempre disponibles.

## 4.2. Estructura del proyecto

La estructura del proyecto en cuanto a funcionamiento es la siguiente:

![Estructura de las peticiones del proyecto](https://personales.alumno.upv.es/esopurb/dew/imgs/estProy.png)

Como se puede observar, el proyecto tiene distintos servlets y cada uno cumple una función específica, la cual se desarrollará más adelante. Además, hay uno que no se puede reflejar, que es el de seguridad, que impide el acceso a todas aquellas peticiones que no se han realizado con los parámetros necesarios. Pero como se ha mencionado antes, todo se explicará más adelante.

## 4.3. Funcionamiento de la aplicación

El funcionamiento de la aplicación se puede prever en la imagen anterior, pero en este apartado se explicará con detalle.

### 4.3.1. Entrada

Consiste en una página principal en la cual tanto profesores como alumnos pueden iniciar sesión.

![Interfaz de Entrada](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazEntrada.png)

Una vez el usuario, sea alumno o profesor, haga clic en su correspondiente formulario de entrada, `Log3.java` pedirá las credenciales para verificar si existe el usuario y si está accediendo correctamente. En caso de no ser así, redirigirá a la página de entrada nuevamente.

![Interfaz de Login](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazLogin.png)

### 4.3.2. Alumno

Cuando el usuario ha iniciado sesión como alumno, `Log3.java` redirigirá la petición al servlet `Alumno.java`, el cual se encarga de construir la página principal del alumno (`alumno.html`) en base a los datos del usuario. Para ello, necesita hacer una petición HTTP a CentroEducativo para obtener las asignaturas y notas del alumno en cuestión.

![Interfaz de Alumno](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazAlumno.png)

Además, esta página realiza una petición AJAX a un servlet llamado `GestionDinamica.java` para obtener la imagen del usuario registrado en formato `.pngb64`. Se hace de esta manera por motivos de seguridad, ya que si no fuera así, si el usuario conociera el DNI de algún alumno o profesor, podría acceder a la foto del usuario correspondiente a dicho DNI.

#### 4.3.2.1. Imprimir

El usuario alumno también puede imprimir sus notas, como si fuera un boletín. Para ello, se ha creado un servlet llamado `Imprimir.java`, que se encarga de formatear la página para estructurarla de manera que se pueda imprimir. Para no construir la página desde cero, se sigue el patrón que se emplea en `alumno.html` y `profesor.html`. Es decir, se emplea una plantilla HTML, en este caso, se llama `PlantillaPeticion.html`, y se reescribe mediante el servlet mencionado anteriormente. Para reescribir la página con los datos personalizados, es necesario hacer otra petición a CentroEducativo para obtener la información requerida.

![Interfaz de Imprimir](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazImprimir2.png)

### 4.3.3. Profesor

Cuando el usuario ha registrado es un profesor, `Log3.java` redirige al usuario a `Profesor.java`. Este servlet hace lo mismo que `Alumno.java`, pero son diferentes ya que cada uno construye la página de una manera distinta, por lo que el diseño de la interfaz no es igual debido a que tienen funciones distintas.

Construye `profesor.html` con los datos del profesor. También hace una petición HTTP para obtener las asignaturas que imparte, además de los datos necesarios para la personalización de la página (como sucede con alumno).

![Interfaz de profesor](https://personales.alumno.upv.es/esopurb/dew/imgs/interfaces/InterfazProfesor.png)

Además de la petición AJAX que se realiza al servlet `GestionDinamica.java` para obtener la imagen del usuario registrado, este también está programado de manera que según el parámetro que se pasa en la petición haga una cosa u otra. En el caso de alumno, solo devuelve una imagen (la del usuario registrado en ese caso) pero en este caso no es así. En el código de `profesor.html` se ve cómo hay más de una petición AJAX, que se utilizan para obtener la información de los alumnos (petición a `GestionDinamica.java`) y de esa manera poder calificarlos (petición a un nuevo servlet llamado `PublicarNotas.java` que se encarga de enviar las nuevas notas a la base de datos para que actualice


No solo cuenta con CSS, también cuenta con unas breves líneas de código JavaScript. La función del script que hay en el HTML es borrar del navegador la sesión en caso de que se haya quedado guardada, eliminando así la posibilidad de errores por parte del cliente (como podría ser el 408). El error mencionado anteriormente aparecía debido a que al poder volver atrás con el navegador, la sesión no se cerraba, y si se intentaba acceder a otra cuenta, por mucho que las credenciales estuvieran correctas, la aplicación no funcionaba de manera correcta. Esto era así porque entendía que en la sesión anterior, ya le había dado una "_KEY_" en el anterior login y no podía mandar otra (porque al no cerrar sesión, supuestamente el usuario ya tiene una clave activa). Esto, además, también soluciona el problema de utilizar la aplicación en distintos navegadores, ya que según el navegador, al moverte hacia adelante o atrás por el navegador (utilizando las flechas), también generaba este error (408).

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

En cuanto a la página de login.html, esta es aún más sencilla, ya que cuenta con un único formulario para introducir los datos que posteriormente se verificarán mediante "_j_security_check_". Este comprueba en el archivo xml del servidor (`tomcat-users.xml`) si es que está el usuario registrado en el sistema (esto a gran escala sería inviable). A su vez, lleva asociado un filtro Java (se asocia en el web.xml (Véase [4.4.4. Archivo web.xml](#444-archivo-webxml))), Log3.java (Véase [4.4.3.1. Log3.java](#4431-log3java)), que verificará si el usuario está accediendo por donde debe. En caso de ser así, creará una sesión y solicitará la clave de paso para que el usuario posteriormente pueda interactuar indirectamente con la BD (no es consciente ni de que existe una clave (key) o que en el propio código de su página hace distintas peticiones). Si no es así, le devuelve a la página inicial.


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

En cuanto a estilo, no se refleja ningún cambio respecto a la página mencionada anteriormente. Esta, como se ha mencionado anteriormente (Véase [4.4.2.1. Index.html](#4421-indexhtml)), consta del mismo código JavaScript, ya que según en qué navegador, en caso de navegar hacia atrás, hay veces que en vez de redirigir directamente a la página principal, pasa otra vez por el login.html. De esta manera, desaparece la posibilidad de que aparezca el error 408.

### 4.4.2.3. Error.html y error2.html
Para el tratamiento de errores, se han diseñado dos páginas, las cuales varían muy poco una de la otra. Estas enmascaran dos tipos de errores: el usuario no está registrado (las credenciales introducidas no están en el archivo `tomcat-users.xml`) y el caso en que el usuario tenga intención de investigar y probar qué pasa si introduce ciertas URL en el navegador, para intentar acceder a un recurso al cual no tiene acceso. Este caso también se aplica a usuarios no registrados.

El estilo de las páginas de error se ha querido diseñar de una manera divertida, basándose en "memes" o frases que pueden causar alguna sonrisa en el usuario que intenta acceder a recursos a los cuales no está autorizado. A continuación se muestra el código básico de la página `error.html`, la cual aparece cuando el usuario no está registrado en el archivo del servidor `tomcat-users.xml`.

```html
<div class="error-message" style="margin-left: 0px; top:20%">
        Venga hombre no me jodas 
</div>
<div style="margin-top:50px">
    <img src="https://cdn.freecodecamp.org/curriculum/cat-photo-app/relaxing-cat.jpg" alt="Un gato relajado" class="cat-image">
</div>
``` 

Además, esta página también cuenta con un breve script de JavaScript para redirigir al usuario a la página en la que estaba anteriormente después de 4 segundos. En este caso, no es necesario el uso de la biblioteca `JQuery`.

```html
<script>
    setTimeout(()=>{
        window.history.back()
    }, 4000)
</script>
``` 

En cuanto a la página `error2.html`, lo único que varía es la frase escrita en `<div class="error-message" style="margin-left: 0px; top:20%">`, la cual es: "_¿Qué buscas cotilla?_". Esta también cuenta con el código JavaScript mostrado anteriormente encargado de redirigir al usuario a la página que estaba anteriormente.

### 4.4.2.4. Profesor.html
Tanto el profesor como las dos próximas páginas HTML no están en el mismo directorio que las anteriores mencionadas. Estas se encuentran en la carpeta WEB-INF. De esta manera, se protegen los recursos para que no puedan ser accedidos mediante la propia URL del archivo (haciendo imposible su acceso por cualquier usuario). Esto no supone un problema para la aplicación, ya que lo que se encarga de mostrar la página en la aplicación es el servlet que está asociado a cada HTML, en este caso, Profesor.java (Véase [4.4.3.2. Profesor.java](#4432-profesorjava)). Es decir, el resto de páginas que se van a describir tienen función de plantilla, más que de interacción como tal.

Los profesores tienen unos casos de uso específicos (Véase el apartado [2.3. Hito 3](#23-hito-3)) y, por tanto, una plantilla específica. En este archivo, se encuentran distintos marcadores que posteriormente serán reescritos por el servlet. Estos se identifican de la siguiente manera: `{{marcador}}`.

La página se puede dividir en distintos `<div></div>` que contienen diferentes elementos y marcadores. Inicialmente, dentro de la etiqueta `<body></body>`, se encuentra `<div id="contenedorPrin" class="container mt-5">`, que como se puede intuir, es el contenedor donde dentro van a estar los distintos subcontenedores con sus respectivos subcontenedores y/u objetos.

Como primer contenedor que está dentro del contenedor principal, se encuentra el `<div class="divs">`, cuya función es estructurar un saludo hacia el/la profesor/a que acaba de iniciar sesión y el botón que posibilita terminar la sesión. En este código también se encuentra el primero de los marcadores, `{{nomalu}}`. Éste se reescribirá posteriormente por el nombre y apellidos del/de la profesor/a.

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
    <!-- Resto de la página, todo lo que se comenta a continuación está ubicado aqui -->
</div>
```

Siguiendo la estructura de la página, se encuentra el siguiente gran contenedor dentro del contenedor principal, `<div class="borde"></div>`. Contiene dos grandes subcontenedores para estructurar la interfaz: `<div class="contenedor"></div>` y `<div class="conte"></div>`. Ambos tienen características bastante concretas que merecen ser comentadas.


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

El `<div class="contenedor"></div>` es la zona de la interfaz general, donde el profesor visualiza las asignaturas y sus respectivos alumnos de las mismas. Además, tiene el botón que posibilita la modificación de las notas de los alumnos, según la asignatura seleccionada. Como se puede observar en la sección de código, hay otro marcador, en este caso `{{asg}}`. El servlet Profesor.java (Véase [4.4.3.2. Profesor.java](#4432-profesorjava)) reescribirá en este punto de la página un acordeón de asignaturas que tendrá tantas filas como asignaturas que imparte. También se puede apreciar el comienzo de una tabla, con su etiqueta `<thead></thead>` y sus respectivas filas y celdas, y el comienzo de un `<tbody></tbody>`, que en la plantilla está vacío. Esto se debe a que esta tabla se va actualizando dinámicamente mediante JavaScript, según se haya seleccionado una asignatura u otra para corregir; o en caso de que se haya deseleccionado, desaparece. Finalmente, se aprecia también el botón mencionado anteriormente que, al ser clicado, acciona el método que habilita la posibilidad de modificar las notas de los alumnos de la asignatura seleccionada.

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

El otro subcontenedor principal, `<div class="conte"></div>`, contiene la interfaz para la modificación de las notas de los alumnos. Se ha decidido que todo esté en la misma página HTML para hacer la interacción del usuario más dinámica y sin redirecciones. Este contenedor cuenta con la siguiente estructura:

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

Para empezar, en la etiqueta se han declarado una serie de variables para que sean globales. Se ha realizado de esta manera para seguir así la estructura de un código Java, aunque es sabido que si se declara sin etiqueta la variable, se crea de ámbito global. La página tiene una serie de métodos que se ejecutan cuando se está cargando la página en el navegador.


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

Para no saturar la lectura de código, se van a explicar a continuación fragmento a fragmento con su debida explicación. Todos estos eventos y peticiones se encuentran dentro del evento `$(document).ready(function (){...})`.

El primer fragmento de código es una petición AJAX en la que se solicita a un servlet llamado `GestionDinamica.java` (Véase [4.4.3.5. GestionDinamica.java](#4435-gestiondinamicajava)), el cual ha sido programado para recibir peticiones relacionadas con la gestión dinámicas de las páginas, tanto profesor.html como en la de alumno e imprimir, que se verá posteriormente (Véase [4.4.2.5. Alumno.html](#4425-alumnohtml) y [PlantillaPeticion.html](#4426-plantillapeticionhtml)). En este caso se realiza una petición con los parámetros definidos en `data`. Esto es así porque el servlet ha sido programado para que cuando reciba estos parámetros, devuelva la imagen del usuario activo. Además se añade el atributo `headers`, que tiene la función de proteger las peticiones en caso de que se introduzcan desde la URL del navegador, en vez de como es debido. Para proteger este caso, se ha desarrollado un nuevo filtro (además del ya existente), llamado `Authorized.java` (Véase [4.4.3.8.](#4438-authorizedjava)), que verifica si contiene el atributo header en la petición, y en caso de tenerlo, que coincida con el valor asignado `true`. En cualquier otro caso, no permite el acceso y devuelve _`SC_FORBIDDEN`_, haciendo así que aparezca la página de error2.html ya mencionada anteriormente (Véase [4.4.2.3. Error.html y error2.html](#4423-errorhtml-y-error2html)).

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
            alert('Error: ' + err.responseText);
        }
    })
```

En caso de que todo haya ido bien, el servlet responderá con un objeto `JSON` a la petición, que contendrá el atributo imagen con su debida información en formato `.pngb64`. Una vez recibida, se asigna el valor contenido en el atributo img de la respuesta a la foto con id="perfil". En caso de error, notifica al usuario mediante una alerta de lo que ha sucedido.

El siguiente fragmento de código está relacionado con la obtención de los alumnos matriculados en la/s distinta/s asignatura/s que imparte el profesor. Como se puede observar, se sigue el mismo procedimiento: se introducen los valores necesarios para realizar la petición, se configura la URL, el tipo de petición, el tipo de objeto a recibir, el header y los parámetros, que en este caso es `opt=asignatura`. Con estos parámetros el servlet mencionado anteriormente, devuelve un array de objetos `JSON` en los que están todos los alumnos de todas las asignaturas en las que imparte el profesor. Estos objetos contienen el DNI, la nota, los apellidos, el acrónimo de la asignatura, entre otros. Según la respuesta se realiza una cosa u otra.


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
            alert('Error: ' + textStatus +" - " + errorThrown + '\n' + jqXHR.responseText);
        }
    })
```
En caso de que la petición se haya realizado correctamente, se recorre el array tantas veces como asignaturas distintas haya (variable i). Se comprueba que el array esté inicializado y de no ser así se inicializa. Una vez que todo está en la situación ideal, se realiza un segundo bucle en el que se van a dividir estos alumnos en asignaturas, identificándolos por el acrónimo. El valor `data[i].acronimo` fija el valor del acrónimo de la asignatura que se está guardando en el índice h. Con el valor de `data[k].acronimo` se recorre el array entero (k++). Mientras ambos valores sean iguales, significa que los alumnos son de la misma asignatura. En el momento en el que esto no sea así, se incrementa el valor de h en uno para mover el índice de la asignatura, se posiciona a 0 el valor de j, para empezar en la posición 0 del subíndice e introducir alumnos desde ahí, y se iguala i a k. De esta manera, se saltan todas las comprobaciones repetidas. Es decir, si se han metido 3 alumnos, no tiene sentido hacer i++, porque si empieza en 0, y hemos dicho que se han metido 3 alumnos, el alumno en la posición 1 corresponde a la misma asignatura. De esta manera (i=k) salta directamente al nuevo alumno con una asignatura distinta. Una vez acabado el `for`, la matriz alum queda inicializada con todos los alumnos, siendo la fila la asignatura a la que corresponden.

Después de inicializar los datos, para que no haya error en la interacción, el equipo ha decidido deshabilitar los botones relacionados con la modificación de las notas de los alumnos. De esta manera, hasta que no sea estrictamente necesario, no se puedan usar, evitando así posibles resultados no deseados.


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
Todo este código se ejecuta cuando el documento se está cargando, pero no es el único método que tiene la página; tiene bastantes más para hacer del HTML una página dinámica y funcional.

El primer método que se ejecuta es el que agrega las filas a la tabla mencionada anteriormente. Cuando se selecciona una asignatura (haciendo clic en el nombre de la misma), activa el siguiente método (descrito en el código a continuación), utilizando los parámetros `acronimo` y `num`. Estos dos parámetros corresponden a que de esta manera se puede asociar el acrónimo con un número y así se puede recorrer la matriz y seleccionar la asignatura (primer índice). Estos valores vienen escritos desde el servlet de Profesor.java, cuando genera el acordeón. De esta manera coincide el acrónimo con el número y con la posición en el array de alum (Véase [4.4.3.2 Profesor.java](#4432-profesorjava)).

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
Como se puede observar, hay 3 casos distintos: que los datos no estén cargados en la tabla (`if`), que estén cargados en la tabla pero se haya seleccionado otra asignatura (`else if`) o que se haya seleccionado otra vez la misma asignatura (`else`).

- `IF`: Al no estar los datos cargados en la tabla y haberse seleccionado una asignatura, se tienen que mostrar los datos en las distintas filas (una para cada alumno) y habilitar el botón que da la opción de modificar las notas. Para ello, se asigna como índice de asignaturas la variable num. De esta manera, se puede elegir la asignatura que ha sido clicada. Además, el grupo ha decidido poner la nota media de los alumnos de esa asignatura al final de la tabla y, por tanto, también hay que agregarla. Para poner los datos en la tabla, se requiere del método `tabla(datos)`, siendo datos el objeto alumno. Y para calcular la nota media, se requiere del método `notamedia()`. Ambos se explicarán más adelante.
- `ELSE IF`: Los datos están cargados en la tabla pero la asignatura es distinta de num. Lo que se quiere decir con esta comparación es que al haber sido modificado el índice de las asignaturas con la variable `num` anteriormente, al llamar al método `agregarFila(acronimo,num)`, con otro número (y evidentemente con otro acrónimo también, van de la mano), significa que el profesor quiere ver los alumnos de otra asignatura y posteriormente, a lo mejor, modificar sus notas. Para realizar este caso, se borran previamente las filas que había, se llama otra vez a `tabla(datos)` y posteriormente se vuelve a crear la fila de la nota media, con la respectiva nota de los alumnos de esa asignatura.
- `ELSE`: Si no se cumplen ambas condiciones previas, significa que num es igual a asignatura y por tanto, significa que ha hecho clic en la última asignatura que previamente había sido desplegada, o lo que es lo mismo, ha pinchado dos veces sobre la misma asignatura. Por tanto, lo que se entiende con este acto, es que el/la profesor/a quiere ocultar a los alumnos mostrados. En este caso, también hay que poner la interfaz de modificar notas en caso de que haya sido modificada previamente (ha corregido y ha cerrado el desplegable). Y esto lleva a deshabilitar también el botón que habilita la interfaz de modificación de notas.

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

`notamedia()` se encarga de devolver el valor de la media aritmética de las notas de los alumnos. En caso de no estar las notas de todos los alumnos con un valor válido (por defecto, el valor es "_Sin Calificar_"), devuelve un mensaje indicando que la nota media aún no está disponible (ya que si se respondiera con el resultado igualmente, lo que se vería es `NaN`, ya que al ser el valor por defecto una cadena de texto, no suma valores, concatena cadenas. Y la división de esto, produce un `NaN`).


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

Para poder habilitar la modificación de las notas de una asignatura, previamente se debe haber seleccionado una asignatura, de modo que el botón que permite la edición de notas esté habilitado. Como se ha observado en el funcionamiento de la aplicación (Véase [4.3. Funcionamiento de la aplicación](#43-funcionamiento-de-la-aplicación)), la interfaz para modificar notas contiene una imagen, el nombre del alumno y la nota actual. Al activar el botón "_calificar alumnos_", se espera que la información de los alumnos se vuelque en la interfaz. Para lograrlo, se realiza una petición AJAX a `GestionDinamica.java`, como se explicó al inicio de este punto, pero con un parámetro adicional (`imagen=`+dni del alumno). Si la petición se realiza correctamente, se carga la información necesaria y la foto en la interfaz. Además, se habilitan los botones de interacción en la interfaz, como los de modificar nota, avanzar o retroceder, y se permite introducir valores en el campo de calificación.

```javascript
//habilitar el modificar las notas (boton de modificar)
function modificarNotas()
{
    indice=0
    $("#imgAlu").attr("src", "data:image/png;base64,"+alum[asignatura][indice].img);
    $('#nombre').text(alum[asignatura][indice].nombre + " "+alum[asignatura][indice].apellidos) //obtiene el texto del p id nombre
    $('#nota').text(alum[asignatura][indice].nota) //obtiene el texto de p id nota
    $('#calificacion, #prov, #btnDrcha, #btnIzqda').prop('disabled', false); //habilitar botones
}
```

Los botones de avanzar y retroceder, se encargan de mover el array alum para poder seleccionar los distintos alumnos. Además también tienen que poner las imágenes y por tanto se requiere de otra petición AJAX. La única diferencia entre ambos métodos es el sentido en el que se mueve el array. 

`//revisar los códigos porque parece residuo las primras lineas de avanzar y retroceder`

```javascript
function avanzar()
{
    if(indice == alum[asignatura].length-1)
    {
        indice = -1
    }
    indice++
    $("#imgAlu").attr("src", "data:image/png;base64,"+alum[asignatura][indice].img);
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
        indice = alum[asignatura].length
    }
    indice--
```

El último método consiste en publicar la nota modificada en la base de datos. Para esta tarea, se ha creado un nuevo servlet llamado `PublicarNotas.java` (Véase [4.4.3.6. PublicarNotas.java](#4436-publicarnotasjava)), al cual se le envía la petición y realiza la inserción en la base de datos. Antes de realizar la petición, se comprueba que la nota sea válida. En caso contrario, se notifica al usuario que debe introducir una nota válida.

Además de la petición, al haber una nueva nota, es necesario notificar al profesor de que se ha cambiado correctamente la nota, actualizar la nota del alumno que aparece en la tabla de alumnos y la nota media, ya que esta última se ha quedado obsoleta con el nuevo cambio. Posteriormente, se avanza al siguiente alumno para hacer el proceso más dinámico.

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

`Alumno.html` es una versión más simple de `profesor.html`, ya que fue desarrollada antes (puesto que era para el hito 2, véase el apartado [2.2. Hito 2](#22-hito-2)), mientras que `profesor.html` fue para el hito 3. Por lo tanto, no tiene tanta complejidad. Consta de distintos marcadores, al igual que `profesor.html`, para que el servlet `Alumno.java` pueda reescribir la página con los datos personalizados del alumno/a que ha iniciado sesión. Además, se ha incluido la opción de solicitar las imágenes de manera dinámica mediante una petición AJAX, con sus respectivos parámetros y cabeceras. Originalmente, esta funcionalidad no estaba presente, pero por motivos de seguridad se ha optado por esta opción. Si se hubiera mantenido la idea original de insertar archivos `.png`, con solo conocer el DNI de un usuario se podría acceder a su foto. Además, a este protocolo de seguridad se le suma el filtro ya mencionado anteriormente, `Authorized.java`.

En cuanto al estilo CSS, sigue la misma política que se ha mantenido durante todo el proyecto, utilizando los mismos colores y manteniendo el diseño de la página. Todo esto mediante código CSS integrado en el propio HTML.

En el código se encuentran los marcadores, que como se ha explicado antes, sirven para ser reemplazados por código HTML generado por el servlet. En el caso del marcador `{{asg}}`, se reemplazará por un acordeón de asignaturas (las asignaturas en las que el alumno/a está matriculado/a), y `{{nomalu}}` será reemplazado por el nombre y los apellidos del alumno/a que ha iniciado sesión. La estructura del código es la siguiente:

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
    <div class="cajon">
        <h2>Asignaturas</h2>
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
</div>
```
Para la asignación de la imagen del alumno, la página tiene un breve código JavaScript:

```html
<script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
<script>
    $(document).ready(function() {
        //pedir imagen alumno
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
                alert('Error: ' + textStatus +" - " + errorThrown + '\n' + jqXHR.responseText);
            }
        })
    })
</script>
```

### 4.4.2.6. PlantillaPeticion.html
Este archivo HTML es la página de Alumno formateada con estilo de impresión. No tiene muchos cambios respecto a `alumno.html`. La única diferencia entre los dos archivos es que, mientras en uno se genera un acordeón mediante un servlet con las asignaturas en las que está matriculado (con su respectiva nota), el servlet llamado `Imprimir.java`, encargado de la personalización de este archivo HTML, lo convierte en una tabla. Además, también consta de un botón que realiza la misma acción que si se presionara el comando `Ctrl + P` (o el comando `⌘ + P` en caso de MacOS).

```html
<div class="divs">
	<div style="justify-self:start">
		<h1>Certificado sin validez académica</h1>
		<p><b>DEW - Centro Educativo</b> certifica que D/Dª <b>{{nombre}}</b>, con DNI {{dni}}, matriculado/a en el curso 23/24, ha obtenido las calificaciones que se muestran en la siguiente tabla.</p>
	</div>
	<div style="justify-self:end">
		<img id="perfil" style="border-radius:50%">
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
<footer>
	    <div class="firma">
	    	<img src="https://upload.wikimedia.org/wikipedia/commons/thumb/f/fe/Apache_Tomcat_logo.svg/2560px-Apache_Tomcat_logo.svg.png">
	    	<p>Firmado por el secretario</p>
	    	<p>[Tomcat 9.0.41]</p>
	    </div>
    </footer>
<div class="center-button">
    <button id="Boton" onclick="return imprimir()"> Imprimir Boletín</button>
</div>
```

El método que se observa en el botón (`imprimir()`) realiza lo siguiente: en el momento que se pincha, oculta el botón para que, al imprimir la página, no se muestre el botón, y una vez se ha seleccionado `Aceptar` o `Cancelar`, este vuelve a aparecer. Además, como requiere la foto del alumno/a, es necesario hacer otra petición AJAX para solicitar su imagen.

```javascript
$(document).ready(function() {
    //pedir imagen alumno
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
            alert('Error: ' + textStatus +" - " + errorThrown + '\n' + jqXHR.responseText);
        }
    })
})
function imprimir()
{
    $('#Boton').hide();
    setTimeout(function() {
        window.print();
        setTimeout(function() {
            $('#Boton').show();
        }, 10); // Ajusta el tiempo si es necesario
    }, 5);
}
```

### 4.4.3. Archivos Java: Servlet y Filters

El proyecto consta de un total de 8 clases java, 6 servlets y 2 filtros:
1. [Log3.java](#4431-log3java) (Filter)
2. [Profesor.java](#4432-profesorjava) (Servlet)
3. [Alumno.java](#4433-alumnojava) (Servlet)
4. [Imprimir.java](#4434-imprimirjava) (Servlet)
5. [GestionDinamica.java](#4435-gestiondinamicajava) (Servlet)
6. [PublicarNotas.java](#4436-publicarnotasjava) (Servlet)
7. [FinalizarSesion.java](#4437-finalizarsesionjava) (Servlet)
8. [Authorized.java](#4438-authorizedjava) (Filter)

### 4.4.3.1. Log3.java

Es el filtro que se encarga de verificar el inicio de sesión con la BD, con ayuda de un protocolo de seguridad "_j_security_check_". `j_security_check` se encarga de verificar si existen las tuplas de datos (dni, contraseña) en el archivo `tomcat-users.xml`. En caso de existir, facilita el paso al filtro, que se encarga de obtener la clave con la que posteriormente, si el usuario así lo necesita, realizará peticiones a CentroEducativo.

Los usuarios autorizados tienen distintos roles, que tendrán permisos especiales según el rol. Esto también tiene que estar en el archivo `.xml`. El archivo resultante contiene lo siguiente:

```xml
    <role rolename="rolalu"/>
    <role rolename="rolpro"/>
  
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

Para el filter, se ha programado el método `doGet(request, response)`, en el que realiza lo siguiente:

```java 
public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {/*Código a continuación*/
```

- Recupera la sesión que se ha creado cuando se le han introducido los datos en el formulario.   

```java
    HttpServletRequest req = (HttpServletRequest) request;
    HttpSession session = req.getSession(true);
    session.setMaxInactiveInterval(10000);

    URL connection = new URL("http://"+req.getServerName()+":9090/CentroEducativo/login");
    HttpURLConnection con = (HttpURLConnection) connection.openConnection();

    String dni = req.getRemoteUser();
```

- En caso de que el DNI sea distinto de `null`, construye una petición mediante el método `POST` a `/CentroEducativo/login`, para obtener la clave de la sesión con la que posteriormente se realizarán todo tipo de peticiones (y para hacerlas, hace falta la clave, que es la autorización de la BD y con la que se pueden realizar peticiones. Es decir, la clave te autoriza a interactuar con la BD). Además, previamente se tenía un `if` en el que se verificaba si el usuario tenía ya sesión iniciada. Se eliminó esta condición ya que generaba problemas a la hora de moverse con las interacciones del navegador (flecha de retroceso, avanzar, etc). Además, también, en caso de que hubiera una sesión, se quita la clave asociada a esta sesión, puesto que también generaba errores, porque en la BD no entiende como una sesión que tiene una clave, solicite otra (cosa que se hace siempre que entras en el login.html, solicitar una clave. Por eso se ha decidido poner la clave de la sesión a `null`). De esta manera, todo el que haya acabado llegando a la página de login.html, se tiene que autenticar siempre. Esta política mejora la seguridad ya que en caso de que alguien se haya dejado la sesión abierta, se vuelve a solicitar el inicio de sesión (en el caso de acabar en el login.html).

```java
    session.setAttribute("key", "");
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
            
        } catch (Exception e) {}
```
- Se trata la respuesta del servidor. En caso de ser `200 OK`, se lee la respuesta, se generan unas cookies con la BD y se asocian al usuario que se ha iniciado sesión. Se le atribuye a la sesión creada el DNI, la contraseña y la clave devuelta de CentroEducativo. Además, también se registra en un fichero (o en su defecto, si no existe se crea y posteriormente se escribe) datos relacionados con el registro de la nueva sesión.

```java
        if(con.getResponseCode() == 200) {
            List<String> cookies = con.getHeaderFields().get("Set-Cookie"); 
            session.setAttribute("cookies", cookies);
            String resKey = "";
            try {
                BufferedReader buff2 = new BufferedReader(new InputStreamReader(con.getInputStream(), "UTF-8"));
                String resline = null;
                while((resline = buff2.readLine()) != null) {
                    resKey += resline.trim();
                }
                
                session.setAttribute("dni", dni);
                session.setAttribute("password", pass);
                session.setAttribute("key", resKey);
                
                String salida = LocalDateTime.now().toString() +" "+ dni +" "+ req.getRemoteAddr() +" "+ req.getMethod() +"\n";
                
                try {
                    FileWriter pw = new FileWriter(new File(req.getServletContext().getInitParameter("rutaArchivo")),true);
                    BufferedWriter bw = new BufferedWriter(pw);
                    bw.write(salida);
                    bw.close();
                    pw.close();
                } catch(Exception e) {
                    System.out.println("Error");
                }
                
            } catch(Exception e) {}     
        }      
    }	      
    // pass the request along the filter chain
    chain.doFilter(request, response);
}
```

Si el inicio de sesión ha sido correcto, el usuario accede a la página principal que ha solicitado. Si es un alumno, accede a `alumno.java`, y en su defecto, si es profesor, accede a `profesor.java`. Esto es así porque las peticiones de los formularios se realizan a los servlets, que son quienes posteriormente se encargan de generar estas páginas.

### 4.4.3.2. Profesor.java

Esta clase se encarga de personalizar la página del usuario registrado con rol de profesor. Para ello, se ha programado el método `doGet(request, response)`. Antes de realizar cualquier consulta, se verifica que el que está intentando acceder no sea un usuario con un rol distinto de profesor:

```java
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    if(request.isUserInRole("rolalu")) {
        
        response.sendRedirect(request.getContextPath() + "/");
        return;
    }
```

De esta manera, en caso de no tener el rol de profesor, se redirige directamente al usuario al inicio y se realiza un retorno para detener la ejecución del servlet. En caso de ser un profesor, para realizar las peticiones necesarias, primero hay que recuperar los datos de la sesión actual del profesor que está logueado en ese momento.

```java
    //Recuperamos al profesor
    HttpSession session = request.getSession();
    String key = (String) session.getAttribute("key");
    String dni = request.getRemoteUser();
    JSONObject profesor = null;
    JSONArray asignaturas = null;
    List<String> cookies = (List<String>) session.getAttribute("cookies");
```
Una vez se ha establecido la sesión en el servlet, se realiza siguiente petición:

```java
    URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dni+"?key="+key);
    HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
    for (String cookie: cookies) {
        conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
    }
    conusr.setDoOutput(true);
    conusr.setRequestMethod("GET");
    conusr.setRequestProperty("accept", "application/json");
    //ver la respuesta de CentroEducativo
    if(conusr.getResponseCode() == 200) {
        try(BufferedReader br = new BufferedReader(new InputStreamReader(conusr.getInputStream()))) {
                String r = "";
                String resLine = null;
                while ((resLine = br.readLine()) != null) {
                r += resLine.trim();
                }
                profesor = new JSONObject(r);
            }
    } else {response.sendRedirect(request.getContextPath() + "/"); return;}
```

Con esta petición, se obtienen los datos completos del profesor (guardados en un objeto JSON (profesor)), como pueden ser el nombre y los apellidos. Posteriormente, con el dni se solicitan las asignaturas que imparte:

```java
    URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dni+"/asignaturas?key="+key);
    HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
    for (String cookie: cookies) {
            conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
    }
    conasg.setDoOutput(true);
    conasg.setRequestMethod("GET");
    conasg.setRequestProperty("accept", "application/json");
    //respuesta del server
    if(conasg.getResponseCode() == 200) {
        try(BufferedReader br = new BufferedReader(new InputStreamReader(conasg.getInputStream()))) {
                String r = "";
                String resLine = null;
                while ((resLine = br.readLine()) != null) {
                r += resLine.trim();
                }
                asignaturas = new JSONArray(r);
            }
    } else {response.sendRedirect(request.getContextPath() + "/"); return;} 
```

La respuesta de CentroEducativo es un array de objetos JSON que contiene todos los datos de cada asignatura. Esta respuesta se guarda en el objeto denominado `array` (objeto de tipo JSONArray). A partir de aquí, ya se tiene la información relevante para personalizar la página y, por tanto, se lleva a cabo la reescritura de `Profesor.html`, gracias a los marcadores que tiene la página HTML (Véase [4.4.2.4. Profesor.html](#4424-profesorhtml)). El código que realiza la reescritura es el siguiente:

```java
    //construccion de la pagina
    response.setContentType("text/html");
    PrintWriter out = response.getWriter();
    String Profesorhtml = getServletContext().getRealPath("/WEB-INF/Profesor.html");
    String Proftem = new String(Files.readAllBytes(Paths.get(Profesorhtml)), "UTF-8");
    
    String dyn = profesor.getString("nombre") +" "+ profesor.getString("apellidos");
    String finalu = Proftem.replace("{{nomalu}}", dyn);	 
    String dynasg = "";
    for(int i=0;i<asignaturas.length();i++) {
                    //se ha añadido id en el botton de justo despues del h2 
        dynasg += "<div class=\"accordion-item\">\n"
                + "    <h2 class=\"accordion-header\" id=\"heading" + i + "\">\n"
                + "        <button onclick=\"return agregarFila('" + asignaturas.getJSONObject(i).getString("acronimo") + "', " + i + ")\" class=\"accordion-button collapsed\" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#collapse" + i + "\" aria-expanded=\"false\" aria-controls=\"collapse" + i + "\">\n"
                + "            " + asignaturas.getJSONObject(i).get("nombre") + "\n"
                + "        </button>\n"
                + "    </h2>\n"
                + "</div>\n";

    }
    finalu = finalu.replace("{{asg}}", dynasg);
    out.print(finalu); //pagina creada hasta aqui
    out.close();
}
```

PPara construir la página, se lee previamente donde se encuentra la plantilla (`WEB-INF/Profesor.html`) y se convierte a `String`. Posteriormente, se reescribe el primer marcador con el nombre del profesor y se guarda la primera modificación de la página en la variable `finalu`. Seguido de esto, se realiza un bucle en el que se va a generar un contenedor (con su respectivo diseño y elementos internos) al que se le asignará una funcionalidad posteriormente (Véase [4.4.2.4. Profesor.html](#4424-profesorhtml)), por cada asignatura que tiene el/la profesor/a. Esto se va a estar guardando en la variable `dynasg`, que será la que reemplace el marcador `{{asg}}` una vez se acabe el bucle. Por lo que al final, la variable `finalu` se habrá reescrito 2 veces, una por marcador. Una vez se ha reescrito, se escribe la página.

### 4.4.3.3. Alumno.java

Este servlet gestiona la generación dinámica de la página `alumno.html` para mostrar información específica sobre un alumno y sus asignaturas (al igual que profesor.java con profesor.html).

En cuanto a la implementación, es bastante sencilla. Se implementa el método `doGet(request, response)` donde se realiza a su vez una petición a CentroEducativo para obtener los datos de las asignaturas en las que está matriculado ese alumno, con lo que posteriormente generará un desplegable con la biblioteca Bootstrap donde se encuentran las notas y sus respectivas calificaciones.

Para que todo esto funcione, hay que hacer una serie de comprobaciones, como verificar que el usuario es un alumno (verificar su rol). En caso de no ser así, le manda automáticamente a `index.html`. Esto se hace por si un usuario registrado como profesor pone en el buscador `/alumno` e intenta acceder a este sitio. De esta manera, no se le concede el paso.

```java
//cabecera del método
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    if(request.isUserInRole("rolpro")) {
        response.sendRedirect(request.getContextPath() + "/");
        return;
    }
```

Se utiliza `return` para que deje de ejecutar este servlet y no produzca errores futuros.

Una vez pasado este filtro inicial de seguridad, se obtiene la sesión HTTP actual y se extraen dos atributos de la sesión: "key" (una clave posiblemente utilizada para autenticación o autorización) y "cookies" (una lista de cookies almacenadas en la sesión). También se obtiene el nombre de usuario remoto (DNI) del usuario autenticado. Con estos datos, el servlet realiza una petición `GET` a CentroEducativo para obtener información del alumno utilizando el DNI y la clave. Se abre una conexión HTTP, se establecen las propiedades necesarias (como las cookies y el tipo de contenido aceptado), y si la respuesta es `200 OK`, se lee la respuesta JSON del servicio, que se convierte en un objeto JSON para su procesamiento posterior. En caso de una respuesta distinta, se redirige al inicio y se detiene la ejecución de este servlet para evitar errores futuros.

```java
    //Recuperar sesion actual
    HttpSession session = request.getSession();
    String key = (String) session.getAttribute("key");
    String dni = request.getRemoteUser();
    JSONObject alumno = null;
    JSONArray asignaturas = null;
    List<String> cookies = (List<String>) session.getAttribute("cookies");

    //preparar la peticion get a CentroEducativo
    URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dni+"?key="+key);
    HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
    for (String cookie: cookies) {
            conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
    }
    conusr.setDoOutput(true);
    conusr.setRequestMethod("GET");
    conusr.setRequestProperty("accept", "application/json");

    //tratar codigo de respuesta y su posterior lectura
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

Luego, el servlet realiza una segunda petición `GET` a CentroEducativo para obtener una lista de asignaturas asociadas al alumno. Esta solicitud también utiliza el DNI del alumno y la clave de autenticación, y se configura de manera similar a la anterior, incluyendo las cookies necesarias en las propiedades de la solicitud. La respuesta de esta segunda solicitud, que es un JSON Array, se procesa y se convierte en un `JSONArray` que contiene las asignaturas del alumno.

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

Con la información del alumno y sus asignaturas ya obtenida, el servlet procede a construir una página HTML dinámica. La plantilla HTML se lee desde un archivo ubicado en el servidor (`/WEB-INF/Alumno.html`). El nombre completo del alumno (nombre y apellidos) se inserta en la plantilla reemplazando un marcador (`{{nomalu}}`), mediante el método `replace("nombre_marcador_en_el_html", variable_donde_esta_el_dato_a_introducir)`, a la variable donde se ha guardado previamente la página web de Alumno.html (`Alumnohtml`). Este nuevo cambio se almacena en la variable `finalu`; en la que aún falta modificar el marcador `{{asg}}`, que se encarga de generar los acordeones de las asignaturas, y `{{imagen}}` que introduce la imagen del alumno, que está ubicada en el mismo directorio pero dentro de una carpeta llamada *imgs*.

```java
    //CONSTRUCCIÓN PÁGINA HTML ALUMNO (NOMBRE Y ACORDEÓN ASIGNATURAS)
    response.setContentType("text/html");
    PrintWriter out = response.getWriter();
    String Alumnohtml = getServletContext().getRealPath("/WEB-INF/Alumno.html");
    String Alutem = new String(Files.readAllBytes(Paths.get(Alumnohtml)), "UTF-8");
    
    String dyn = alumno.getString("nombre") +" "+ alumno.getString("apellidos");
    String finalu = Alutem.replace("{{nomalu}}", dyn);
```

Una vez que se ha guardado la primera modificación en `finalu`, `dynasg` almacenará el HTML del acordeón de asignaturas del alumno. Luego, entra en un bucle que itera sobre cada asignatura en el `JSONArray asignaturas`. Para cada asignatura, se construye una URL específica que apunta al servicio CentroEducativo del servidor, incluyendo el identificador de la asignatura y una clave de autenticación.

Se abre una conexión HTTP a esta URL y se configuran las propiedades de la solicitud, incluyendo las cookies de autenticación y el método GET, especificando que se espera una respuesta en formato JSON. La respuesta del servidor se lee utilizando un BufferedReader y se procesa para obtener un objeto JSON con los detalles de la asignatura. También se extrae la calificación de la asignatura, asignando "Sin calificar" si está vacía.

Con los datos obtenidos, se construye dinámicamente un segmento HTML para un ítem del acordeón, que incluye el nombre y la calificación de la asignatura. Este HTML se acumula en la cadena `dynasg`. Tras procesar todas las asignaturas, el marcador `{{asg}}` es reemplazado en el HTML ya reescrito antes (`finalu`), nuevamente por el método `replace()`. Acto seguido, se vuelve a utilizar este método para introducir también la imagen del alumno, reemplazando `{{imagen}}` por el string `<img alt=\"fotoalumno\" src=\"./imgs/"+dni+".png\" width=\"92\" height=\"92\" style=\"border-radius:50%\">`.

Finalmente, el HTML completo, con los datos de las asignaturas integrados, se envía al cliente mediante PrintWriter, permitiendo que el navegador del usuario muestre la página personalizada con la información del alumno y sus asignaturas en un formato interactivo.

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
}
```

### 4.4.3.4. Imprimir.java

Este servlet se ha creado para manejar la creación dinámica de una página HTML, PlantillaPeticion.html (Véase [4.4.2.6. PlantillaPeticion.html](#4426-plantillapeticionhtml)). Este servlet se encarga, al igual que Alumno.java (Véase [4.4.3.3. Alumno.java](#4433-alumnojava)), de diseñar la página para que obtenga un estilo parecido a un PDF y pueda imprimirse en caso de ser necesario.

La implementación del código es muy similar a la anterior, ya que ambas se encargan de la creación dinámica de la página web, en este caso, PlantillaPeticion.html. Vuelve a realizar peticiones a CentroEducativo mediante el método GET, pero esta vez genera una tabla con todas las asignaturas, sus respectivas notas y acrónimos, añade la foto del usuario y muestra la fecha del día en que se expidió el boletín de notas.

Toda la parte de las peticiones GET se considera muy similar y, por ende, no se va a hacer hincapié en este apartado, ya que bastaría con mirar el anterior donde se explica cómo se obtienen todos los datos y se cumplen los requisitos de seguridad.

Algo que cabe destacar es la obtención del formato de la fecha, ya que esto es nuevo en el acta. Para conseguir el formato deseado (`$día_del_mes de $nombre_mes de $año`), se ha utilizado el siguiente código:

```java
Date fecha = new Date();
SimpleDateFormat formato = new SimpleDateFormat("d 'de' MMMM 'de' yyyy", new DateFormatSymbols(Locale.forLanguageTag("es")));
String fechaf = formato.format(fecha);
```

Una vez se ha obtenido toda la información necesaria (las notas, la imagen, los nombres y acrónimos de las asignaturas, el nombre y el apellido del usuario, y la fecha del día actual) para poder generar la página con el formato de impresión, es cuando comienzan los cambios, más allá de la propia estructura de la página en sí con la del alumno. Al igual que en el servlet anterior, se reemplazan los marcadores en la plantilla con los datos dinámicos obtenidos anteriormente, como el nombre del alumno, el DNI, las asignaturas y la fecha actual en español.

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

Como se puede observar en el `try`, ahí es donde está la diferencia principal de un servlet a otro; en este se está insertando filas con el contenido requerido a una tabla que previamente ha sido creado las cabeceras de las columnas en la PlantillaPeticion.html.

Una vez la página ha sido creada, si el usuario quisiera imprimírsela, tendría una vista similar a la de un PDF a la hora de seleccionar la opción imprimir boletín.

### 4.4.3.5. GestionDinamica.java

Este servlet es el encargado de gestionar todas las peticiones que se realizan mediante AJAX. Las peticiones AJAX que se realizan en las páginas HTML del proyecto, van todas enviadas a GestionDinamica.java (Véase [4.4.2.4. Profesor.html](#4424-profesorhtml) y [4.4.2.5. Alumno.html](#4425-alumnohtml)), salvo la de publicar las notas modificadas, que por comodidad, la gestiona otro servlet (Véase [4.4.3.6. PublicarNotas.java](#4436-publicarnotasjava)).

El código implementa el método `doGet(request, response)`, que se ha configurado de manera que pueda contestar a distintas peticiones con distintos parámetros. Para atender a las distintas peticiones, se ha programado para que reciba un atributo llamado `opt`. Este atributo se establece a la hora de realizar la petición en el código JavaScript y se comprobará la existencia de este en el servlet. Su valor se guarda en la variable definida como `opt`, de tipo `String`. De esta manera, se puede comparar el valor enviado en la petición y realizar una cosa u otra según el valor recibido (opt=imagen, por ejemplo. Esto significa que el valor de opt establecido en la petición es igual a imagen, y cuando el servlet vea su valor hará una tarea específica).


```java
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    String opt = request.getParameter("opt");
```
Una vez se ha guardado el valor del parámetro enviado, el servlet ha sido programado para que pueda atender solo dos tipos de peticiones, cada una con un valor de `opt` concreto. Para comprobar si cumplen el valor, basta con hacer una comparación en un `if`. En caso de que se cumpla, tiene que realizar la tarea programada para ese valor. La primera opción es enviar la imagen del usuario registrado (esta petición la realizan tanto alumnos como profesores).

```java
    String dni = request.getRemoteUser();
    if(opt.equals("imagen")) {
        JSONObject res = new JSONObject();
        PrintWriter out = response.getWriter();
        response.setContentType("application/json");
        response.setCharacterEncoding("UTF-8");
        String carpeta = getServletContext().getInitParameter("Directorio_imagenes");
        String img =null;
        try(BufferedReader br = new BufferedReader(new FileReader(carpeta+"/"+dni+".pngb64")))
        {
            StringBuilder sb = new StringBuilder();
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }
            img = sb.toString();
            br.close();
            res.put("img", img);
        }catch (IOException e) 
        {
            response.setStatus(HttpServletResponse.SC_NOT_FOUND);
            response.setContentType("application/json");
            response.getWriter().write("{\"error\": \"Imagen no encontrada\"}");
        }
        out.write(res.toString());
        out.close();
    }
```

La segunda petición que se le puede hacer al servlet obtiene los alumnos (con datos completos, nota e imagen) de cada asignatura que imparte el profesor. Por tanto, no tiene que estar al alcance de ambos usuarios, solo para el profesor. Para ello, antes de responder a la petición, se verifica que el usuario no sea un alumno. Aunque realmente, gracias al header `Authorization` de la petición AJAX, si el alumno introdujera la URL correcta, no tendría acceso a realizar esta petición. Sin embargo, se ha implementado esta verificación por si acaso, ya que si un alumno conociera tanto la URL como el header de la petición y ejecutara la petición en la consola, recibiría una respuesta sin problemas (aunque la respuesta sería un array vacío ya que un alumno no imparte clases). Por ello, se ha decidido implementar esta comprobación.

```java
    if(opt.equals("asignatura")){
        //verificar que no es alumno
        if(request.isUserInRole("rolalu")) {
            response.setStatus(HttpServletResponse.SC_FORBIDDEN);
            response.setContentType("application/json");
            response.getWriter().write("{\"error\": \"Acceso denegado\"}");
            return;
        }  
```

Una vez verificado que el usuario es un profesor, se recuperan los datos del profesor y se solicitan las asignaturas que imparte. 

```java
        //Recuperamos al profesor
        HttpSession session = request.getSession();
        String key = (String) session.getAttribute("key");
        JSONArray asignaturas = null;
        JSONArray alumno = new JSONArray();
        JSONArray resA = new JSONArray();
        JSONObject alumnoEnt =new JSONObject();
        JSONArray mensaje = new JSONArray();
        String respuesta;
        List<String> cookies = (List<String>) session.getAttribute("cookies");
        
        PrintWriter out = response.getWriter();
        response.setContentType("application/json");
        response.setCharacterEncoding("UTF-8");
        
        //conseguimos asignatura del profesor
        URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dni+"/asignaturas?key="+key);
        HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
        for (String cookie: cookies) {
                conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
        }
        conasg.setDoOutput(true);
        conasg.setRequestMethod("GET");
        conasg.setRequestProperty("accept", "application/json");
        //respuesta del server
        if(conasg.getResponseCode() == 200) {
            try(BufferedReader br = new BufferedReader(new InputStreamReader(conasg.getInputStream()))) {
                StringBuilder sb = new StringBuilder();
                String line;
                while ((line = br.readLine()) != null) {
                    sb.append(line);
                }
                
                respuesta = sb.toString();
                br.close();
                asignaturas = new JSONArray(respuesta);  
            } 
        }else {response.sendRedirect(request.getContextPath() + "/"); return;}
```
Al obtener todas las asignaturas en las que imparte el profesor, se obtienen los alumnos de cada asignatura. Para obtener los datos completos, primero hay que realizar una consulta a la base de datos sobre los alumnos que están matriculados en esa asignatura y, posteriormente, buscar al alumno por su número de identificación (DNI), también en la base de datos. Para la imagen, basta con buscar en el directorio `/home/user/tomcat/webapps/NOL-G2/imgs` con el DNI del usuario, ya que las imágenes están asociadas al DNI (la imagen se llama `dni_del_usuario.pngb64`). Para guardar la información de cada alumno, se crea un JSONObject llamado `AlumnoEnt`. Este objeto contiene todos los datos del alumno, incluyendo su nota e imagen. Este JSONObject se guarda en el JSONArray `resA`, que posteriormente se enviará como respuesta. El proceso de obtener los datos de todos los alumnos de la asignatura "_X_" se repetirá tantas veces como asignaturas tenga el profesor.

```java
        for(int a = 0; a < asignaturas.length(); a++){
            String acronimo = asignaturas.getJSONObject(a).getString("acronimo");
            //conseguimos alumnos de la asignatura
            URL urlalu = new URL("http://"+request.getServerName()+":9090/CentroEducativo/asignaturas/"+acronimo+"/alumnos?key="+key);
            HttpURLConnection conalu = (HttpURLConnection) urlalu.openConnection();
            for (String cookie: cookies) {
                conalu.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
            }
            conalu.setDoOutput(true);
            conalu.setRequestMethod("GET");
            conalu.setRequestProperty("accept", "application/json");
            //respuesta del servlet
            if(conalu.getResponseCode() == 200) {
                try(BufferedReader br2 = new BufferedReader(new InputStreamReader(conalu.getInputStream()))) {
                    StringBuilder sb2 = new StringBuilder();
                    String line2;
                    while ((line2 = br2.readLine()) != null) {
                        sb2.append(line2);
                    }
                    respuesta = sb2.toString();
                    br2.close();
                    alumno = new JSONArray(respuesta); //datos de los alumnos y nota
                    //out.write(alumno.toString());
                }
            }
            //conseguimos nombre de los alumnos
            for(int i = 0; i < alumno.length(); i++)
            {
                String DNI = alumno.getJSONObject(i).getString("alumno");
                URL nomalu = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+DNI+"?key="+key);
                HttpURLConnection connomalu = (HttpURLConnection) nomalu.openConnection();
                for (String cookie: cookies) {
                    connomalu.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
                }
                connomalu.setDoOutput(true);
                connomalu.setRequestMethod("GET");
                connomalu.setRequestProperty("accept", "application/json");
                
                //respuesta del servlet
                if(connomalu.getResponseCode() == 200) {
                    try(BufferedReader br2 = new BufferedReader(new InputStreamReader(connomalu.getInputStream()))) {
                        StringBuilder sb2 = new StringBuilder();
                        String line2;
                        while ((line2 = br2.readLine()) != null) {
                            sb2.append(line2);
                        }
                        respuesta = sb2.toString();
                        br2.close();
                        alumnoEnt = new JSONObject(respuesta); //datos de los alumnos con nombre
                        for(int j =0; j<alumno.length();j++)
                        {
                            if(alumnoEnt.get("dni").equals(alumno.getJSONObject(j).getString("alumno")))
                            {
                                alumnoEnt.put("nota",alumno.getJSONObject(j).getString("nota"));
                                alumnoEnt.put("acronimo", acronimo);
                                String carpeta = getServletContext().getInitParameter("Directorio_imagenes");
                                String img =null;
                                try(BufferedReader br = new BufferedReader(new FileReader(carpeta+"/"+alumnoEnt.get("dni")+".pngb64")))
                                {
                                    StringBuilder sb = new StringBuilder();
                                    String line;
                                    while ((line = br.readLine()) != null) {
                                        sb.append(line);
                                    }
                                    img = sb.toString();
                                    br.close();
                                    alumnoEnt.put("img", img);
                                }catch (IOException e) 
                                {
                                    System.err.println(e);
                                }
                            }
                        }
                        resA.put(alumnoEnt);
                    }
                }
            }
        }   
```

Finalmente, se envia `resA` para que en la página Profesor.html, sea procesado.

```java
        out.write(resA.toString());
    }
}   
```

### 4.4.3.6. PublicarNotas.java

Como su nombre indica, este servlet se encarga de publicar las notas en la base de datos de CentroEducativo. Recibe una petición AJAX desde `Profesor.html` (ver [4.4.2.4. Profesor.html](#4424-profesorhtml)) que contiene como parámetros la nota a introducir, el DNI del alumno al que se le ha modificado la nota y la asignatura a la que pertenece. Se ha configurado el método `doPost(request, response)` desde el cual se realizará la petición `PUT` a CentroEducativo. Esto se ha realizado así porque implementando el método `doPut` generaba error.

```java
protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
```

Este servlet, al igual que en uno de los casos de `GestionDinamica.java` (ver [4.4.3.5. GestionDinamica.java](#4435-gestiondinamicajava)), no puede ser accedido por alumnos. La diferencia respecto al servlet anterior es que un alumno no puede acceder de ninguna manera a este servlet, a diferencia del otro, que sí tenía acceso para obtener la imagen del alumno. Para lograrlo, en el archivo web.xml se ha añadido una restricción por rol a este servlet (ver [4.4.4. Archivo web.xml](#444-archivo-webxml), _security-constraint_). Además, también se debe verificar si el profesor que está introduciendo la nota en esa asignatura imparte clase en ella, ya que no debe poder modificar notas en las que no es profesor. Para ello se ha realizado lo siguiente:

```java
    //Recuperamos al profesor
    HttpSession session = request.getSession();
    String key = (String) session.getAttribute("key");
    String dniProf = request.getRemoteUser();
    List<String> cookies = (List<String>) session.getAttribute("cookies");

    //coger valores de la peticion
    String dniAlu = request.getParameter("dni");
    String acronimo = request.getParameter("acronimo");
    String notaAlu = request.getParameter("nota");
    String mensaje = "\"" + notaAlu + "\"";
    
    //si el usuario es profesor hay que verificar si da esa asignatura
    if(request.isUserInRole("rolpro")) {
        //conseguir las asignaturas del profe que realiza la petición
        JSONArray asignaturas;
        boolean asigProfe = false;
        URL urlasg = new URL("http://"+request.getServerName()+":9090/CentroEducativo/profesores/"+dniProf+"/asignaturas?key="+key);
        HttpURLConnection conasg = (HttpURLConnection) urlasg.openConnection();
        for (String cookie: cookies) {
                conasg.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
        }
        conasg.setDoOutput(true);
        conasg.setRequestMethod("GET");
        conasg.setRequestProperty("accept", "application/json");
        //respuesta del server
        if(conasg.getResponseCode() == 200) {
            try(BufferedReader br = new BufferedReader(new InputStreamReader(conasg.getInputStream()))) {
                    String r = "";
                    String resLine = null;
                    while ((resLine = br.readLine()) != null) {
                    r += resLine.trim();
                    }
                    asignaturas = new JSONArray(r);
                }
        } else {response.sendRedirect(request.getContextPath() + "/"); return;}
        
        //se mira que el acronimo de la asignatura que se ha pasado corresponde con una asignatura que imparte el profesor
        for(int i = 0; i < asignaturas.length(); i++)
        {
            if(asignaturas.getJSONObject(i).getString("acronimo").equals(acronimo))
            {
                asigProfe = true;
                break;
            }
        }
        
        //si la asignatura enviada no corresponde con ninguna del profe, no puede modificar las notas
        if(!asigProfe) {
            response.setStatus(HttpServletResponse.SC_FORBIDDEN);
            response.setContentType("application/json");
            response.getWriter().write("{\"error\": \"Acceso denegado\"}");
            return;
        }
    }
```

Una vez pasada la verificación se realiza la petición para la inserción de la nueva nota en la BD. Para ello se crea la conexión, se establecen los parámetros del envio y posteriormente se envia la nota nueva a CentroEducativo. Una vez se ha enviado, se trata la respuesta.

```java
    //creamos la conexion
    URL urlusr = new URL("http://"+request.getServerName()+":9090/CentroEducativo/alumnos/"+dniAlu+"/asignaturas/"+acronimo+"?key="+key);
    HttpURLConnection conusr = (HttpURLConnection) urlusr.openConnection();
    for (String cookie: cookies) {
        conusr.addRequestProperty("Cookie", cookie.split(";", 2)[0]);
    }
    conusr.setDoOutput(true);
    conusr.setDoInput(true);
    conusr.setRequestMethod("PUT");
    conusr.setRequestProperty("Content-Type", "application/json");
    conusr.setRequestProperty("accept", "text/plain");
    
    //manda la peticion
    try (OutputStream os = conusr.getOutputStream()) {
        byte[] input = mensaje.getBytes("utf-8");
        os.write(input, 0, input.length);
    } 
    catch (Exception e) {}
    
    if(conusr.getResponseCode()==200)
    {
        response.setStatus(HttpServletResponse.SC_ACCEPTED);
    }
    else
    {
        response.setStatus(HttpServletResponse.SC_BAD_REQUEST);
        response.getWriter().write(conusr.getResponseMessage());
    }
}
```

### 4.4.3.7. FinalizarSesion.java

Este servlet se encarga de finalizar la sesión para ambos tipos de usuarios. Su funcionamiento es sencillo. Cuando se pincha en el botón de "_Finalizar Sesión_" en cualquiera de las interfaces, se hace una petición al método `doGet(request, response)`, que se encarga de recuperar la sesión del usuario, invalidarla y redirigirlo a la página inicial, donde a continuación puede volver a iniciar sesión con el usuario que desee.

```java
protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    HttpSession session = request.getSession();
    session.invalidate();
    response.sendRedirect(request.getContextPath() + "/");
}
```

### 4.4.3.8. Authorized.java

Es el filtro de seguridad mencionado anteriormente en otros puntos de esta memoria (véase [4.4.2.4. Profesor.html](#4424-profesorhtml) y [4.4.3.5. GestionDinamica.java](#4435-gestiondinamicajava)). Se encarga de verificar si las peticiones a distintos servlets están autorizadas. Para ello, a la hora de hacer las distintas peticiones a los servlets, se añade a éstas un `header`, de nombre `Authorization` y de valor igual a `true`. El filtro verifica que esta cabecera existe y contiene ese valor. En caso contrario, muestra una página de error específica, que se ha definido en el archivo `web.xml` (véase [4.4.4. Archivo web.xml](#444-archivo-webxml)). De esta manera, se protege la aplicación de intentos de consultar/modificar sin la debida autorización. Por ejemplo, si un usuario conoce la URL con la que se envían los datos a `PublicarNotas.java`, y cambia los valores de los atributos que se envían (nota, acrónimo y DNI), podría modificar la nota del alumno de la asignatura que se quisiera sin estar autorizado. Este filtro se encarga de que eso no pase.

```java
public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
    // TODO Auto-generated method stub
    HttpServletRequest httpRequest = (HttpServletRequest) request;
    HttpServletResponse httpResponse = (HttpServletResponse) response;

    // Verifica el encabezado que ponemos en la peticion
    String customHeader = httpRequest.getHeader("Authorization");

    // Verifica el rol del usuario 
    boolean isLoggedIn = httpRequest.getRemoteUser()!= null;
    boolean isUserRoleValid = "true".equals(customHeader);

    if (isLoggedIn && isUserRoleValid) {
        chain.doFilter(request, response); // Permitir la solicitud
    } else {
        httpResponse.sendError(HttpServletResponse.SC_FORBIDDEN, "Forbidden");
    }
}
```

### 4.4.4. Archivo web.xml

El archivo `web.xml` sirve como un mapa detallado que define la estructura, la configuración y la seguridad de la aplicación web. Al proporcionar una descripción exhaustiva de los componentes de la aplicación, desde los servlets hasta los filtros de seguridad, el `web.xml` actúa como el núcleo central que dirige y controla el comportamiento de la aplicación. 

Se han configurado los siguientes parámetros:

- **display-name**: Define el nombre que se mostrará para la aplicación web, en este caso, "NOL-G2".
```xml
<display-name>NOL-G2</display-name>
```
- **welcome-file-list**: Enumera los archivos de bienvenida que se utilizarán si no se especifica ningún recurso específico en la URL
```xml
<welcome-file-list>
    <welcome-file>index.html</welcome-file>
    <welcome-file>index.jsp</welcome-file>
    <welcome-file>index.htm</welcome-file>
    <welcome-file>default.html</welcome-file>
    <welcome-file>default.jsp</welcome-file>
    <welcome-file>default.htm</welcome-file>
</welcome-file-list>
```
- **session-config**: Configura el tiempo de espera de la sesión en segundos. En este caso, la sesión expirará después de 900 segundos (15 minutos) de inactividad.
```xml
<session-config>
    <session-timeout>900</session-timeout>
</session-config>
```
- **context-param**: Define parámetros de contexto que pueden ser utilizados por la aplicación. En este caso, se definen dos parámetros de contexto: "rutaArchivo" y "Directorio_imagenes", con sus respectivos valores.
```xml
<context-param>
    <param-name>rutaArchivo</param-name>
    <param-value>/home/user/Escritorio/NOLG2Access.log</param-value>
</context-param>
<context-param>
    <param-name>Directorio_imagenes</param-name>
    <param-value>/home/user/tomcat/webapps/NOL-G2/imgs</param-value>
</context-param>
```
- **security-constraint**: Establece restricciones de seguridad para ciertos recursos web. Define qué roles de usuario tienen acceso a qué recursos y mediante qué métodos HTTP.
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
<security-constraint>
    <web-resource-collection>
      <web-resource-name>GestionDinamica</web-resource-name>
      <url-pattern>/GestionDinamica</url-pattern>
      <http-method>GET</http-method>
    </web-resource-collection>
    <auth-constraint>
      <role-name>rolpro</role-name>
      <role-name>rolalu</role-name>
    </auth-constraint>
</security-constraint>
<security-constraint>
    <web-resource-collection>
      <web-resource-name>AccesoProf</web-resource-name>
      <url-pattern>/Profesor</url-pattern>
      <http-method>GET</http-method>
    </web-resource-collection>
    <auth-constraint>
      <role-name>rolpro</role-name>
      <role-name>rolalu</role-name>
    </auth-constraint>
</security-constraint>
<security-constraint>
    <web-resource-collection>
      <web-resource-name>PublicarNotas</web-resource-name>
      <url-pattern>/PublicarNotas</url-pattern>
      <http-method>POST</http-method>
    </web-resource-collection>
    <auth-constraint>
      <role-name>rolpro</role-name>
    </auth-constraint>
</security-constraint>
```
- **login-config**: Configura el método de autenticación utilizado por la aplicación. En este caso, se utiliza el método "FORM" (formulario), y se especifican las páginas de inicio de sesión y de error.
```xml
<login-config>
    <auth-method>FORM</auth-method>
    <form-login-config>
      <form-login-page>/login.html</form-login-page>
      <form-error-page>/error.html</form-error-page>
    </form-login-config>
</login-config>
```
- **security-role**: Define los roles de seguridad que pueden ser asignados a los usuarios.
```xml
<security-role>
    <role-name>rolalu</role-name>
</security-role>
<security-role>
    <role-name>rolpro</role-name>
</security-role>
```
- **filter**: Define filtros que pueden ser aplicados a las solicitudes entrantes o salientes. En este caso, se define un filtro llamado "Log3" y otro llamado "Authorized".
```xml
<filter>
    <display-name>Log3</display-name>
    <filter-name>Log3</filter-name>
    <filter-class>Log3</filter-class>
</filter>
<filter>
    <display-name>Authorized</display-name>
    <filter-name>Authorized</filter-name>
    <filter-class>Authorized</filter-class>
</filter>
```
- **filter-mapping**: Asocia los filtros definidos anteriormente con patrones de URL específicos, especificando qué solicitudes serán filtradas por cada filtro.
```xml
<filter-mapping>
    <filter-name>Log3</filter-name>
    <url-pattern>/*</url-pattern>
</filter-mapping>
<filter-mapping>
    <filter-name>Authorized</filter-name>
    <url-pattern>/GestionDinamica</url-pattern>
    <url-pattern>/PublicarNotas</url-pattern>
</filter-mapping>
```
- **servlet**: Define servlets que manejan las solicitudes del cliente. Cada servlet tiene un nombre, una clase asociada y posiblemente una descrip
```xml
<servlet>
    <description></description>
    <display-name>Alumno</display-name>
    <servlet-name>Alumno</servlet-name>
    <servlet-class>Alumno</servlet-class>
</servlet>
<servlet>
    <description></description>
    <display-name>Imprimir</display-name>
    <servlet-name>Imprimir</servlet-name>
    <servlet-class>Imprimir</servlet-class>
</servlet>
<servlet>
    <description></description>
    <display-name>Profesor</display-name>
    <servlet-name>Profesor</servlet-name>
    <servlet-class>Profesor</servlet-class>
</servlet>
<servlet>
    <description></description>
    <display-name>GestionDinamica</display-name>
    <servlet-name>GestionDinamica</servlet-name>
    <servlet-class>GestionDinamica</servlet-class>
</servlet>
<servlet>
    <description></description>
    <display-name>PublicarNotas</display-name>
    <servlet-name>PublicarNotas</servlet-name>
    <servlet-class>PublicarNotas</servlet-class>
</servlet>
<servlet>
    <description></description>
    <display-name>FinalizarSesion</display-name>
    <servlet-name>FinalizarSesion</servlet-name>
    <servlet-class>FinalizarSesion</servlet-class>
</servlet>
```
- **servlet-mapping**: Asocia un servlet con un patrón de URL específico, de modo que el servlet maneje las solicitudes dirigidas a esa URL.
```xml
<servlet-mapping>
    <servlet-name>Alumno</servlet-name>
    <url-pattern>/Alumno</url-pattern>
</servlet-mapping>
<servlet-mapping>
    <servlet-name>Imprimir</servlet-name>
    <url-pattern>/Imprimir</url-pattern>
</servlet-mapping>
<servlet-mapping>
    <servlet-name>Profesor</servlet-name>
    <url-pattern>/Profesor</url-pattern>
</servlet-mapping>
<servlet-mapping>
    <servlet-name>GestionDinamica</servlet-name>
    <url-pattern>/GestionDinamica</url-pattern>
</servlet-mapping>
<servlet-mapping>
    <servlet-name>PublicarNotas</servlet-name>
    <url-pattern>/PublicarNotas</url-pattern>
</servlet-mapping>
<servlet-mapping>
    <servlet-name>FinalizarSesion</servlet-name>
    <url-pattern>/FinalizarSesion</url-pattern>
</servlet-mapping>
```
- **error-page**: Define páginas de error para diferentes códigos de error HTTP. Por ejemplo, en caso de un error 403 (Acceso prohibido), el usuario será redirigido a "/error2.html".
```xml
<error-page>
    <error-code>403</error-code>
    <location>/error2.html</location>
</error-page>
```
## 5. Testing
En este apartado se va a mostrar como se ha probado todas las restricciones de seguridad que se han ido exploniendo a lo largo de la memoria, para justificar que funciona todo a la perfección. 

En el caso de que el usuario sea un alumno o profesor:

- Inicio de sesión erroneo.

![Datos introducidos erroneos](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/datosMalinicio.png)

![Error al solicitar entrar habiendo introducido unos datos erroneos](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/errorInicio.png)

En caso de que sea un **alumno**:

1. Alumno que intenta acceder por las url a distintos recursos.

- GestionDinamica.java con los parámetros opt=imagen: no va a poder acceder porque no se introduce la cabecera Authorization a la hora de hacer la peticón por la URL

![Acceder a GestionDinamica.java directamente desde la URL](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla1.png)

![Error al intentar acceder a GestionDinamica.java desde la URL, no esta la cabecera Authorization](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla2.png)

- GestionDinamica.java con los parámetros opt=asignatura: no va a poder acceder porque no se introduce la cabecera Authorization a la hora de hacer la peticón por la URL. Además tampoco está autorizado a acceder a este recurso.

![Acceder a GestionDinamica.java directamente desde la URL](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla5.png)

![Error al intentar acceder a GestionDinamica.java desde la URL, no esta la cabecera Authorization y tampoco esta autorizado para este recuro](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla6.png)

- Acceder al servlet PublicarNotas.java: no va a poder acceder ni realizar cambios porque no se introduce la cabecera Authorization a la hora de hacer la peticón por la URL. Además tampoco está autorizado a acceder a este recurso.

![Llamar al servlet PublicarNotas.java](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla3.png)

![Error al llamar a PublicarNotas, no está autorizado](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnocotilla4.png)

2. Probar a hacer la petición por consola: no va a poder acceder ni realizar cambios porque no está autorizado a acceder a este recurso.

Para realizar la prueba, tanto esta como en el caso de profesor, se ha utilizado el siguiente código JavaScript:

```javascript
$.ajax({
	url: './PublicarNotas', 
	type: 'POST',
	datatype: 'json', 
        async:true,
	headers: {
	         'Authorization': 'true'
	},
    data: 'acronimo=IAP&nota=3&dni=12345678W',
    success: function(data){
            alert("Nota publicada con éxito.")
    },
    error: function(err){
            alert("Error: " + err.readyState)
    }
})
```

![Publicar una nota siendo un alumno](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnoTerminal2.png)

![Error al intentar poner una nota siendo un alumno](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/alumnoTerminal1.png)

En caso de que sea un **profesor**:

1. Acceder a los servlets por url.

- GestionDinamica.java con los parámetros opt=imagen: no va a poder acceder porque no se introduce la cabecera Authorization a la hora de hacer la peticón por la URL

![Acceder a GestionDinamica.java directamente desde la URL](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/urlGestionDinamica.png)

![Error al intentar acceder a GestionDinamica.java desde la URL, no esta la cabecera Authorization](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/errorUrlGestionDinamica.png)

- Acceder al servlet PublicarNotas.java: no va a poder acceder ni realizar cambios porque no se introduce la cabecera Authorization a la hora de hacer la peticón por la URL.

![Acceder a PublicarNotas.java directamente desde la URL](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/urlGestionDinamica2.png)

![Error al intentar acceder a PublicarNotas.java desde la URL, no esta la cabecera Authorization](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/errorGestionDinamica2.png)

2. Probar a hacer una petición por cosola para la modificación de las notas de asignaturas que no imparte: no va a poder acceder ni realizar cambios porque no está autorizado a modificar notas de alumnos de asignaturas que no imparte.

![Petición AJAX por consola a PublicarNotas.java para modificar una nota a un alumno de una asignatura que no imparte](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/consolaProfe.png)

![Error de la petición debido a la seguridad implementada](https://personales.alumno.upv.es/esopurb/dew/imgs/interfacesError/errorConsolaProfe.png)

## 6. Conclusiones y trabajo en grupo

### 6.1. Conclusiones

En el trabajo se refleja el esfuerzo y la dedicación de todos los integrantes del grupo. A lo largo del proyecto, hemos llevado a cabo distintas tareas que han hecho que las habilidades de cada miembro del equipo se desarrollen. La elaboración de actas, esta memoria y la entrega de los distintos hitos han permitido adquirir conocimientos y habilidaddes de desarrollo web. Han sido horas de "_estrujarse el cerebro_" para sacar adelante los problemas que iban surgiendo a la hora de desarrollar el código, pero gracias a las habilidades de cada uno se ha logrado superar esos obstáculos con creces. 

Además, la comunicación fue clave para mantenernos en el buen camino y cumplir con los plazos establecidos. A través de reuniones y canales de comunicación abiertos (como pudo ser Discord, creando el servidor para el grupo) pudimos mantenernos alineados en nuestros objetivos y resolver cualquier problema de manera oportuna.

En resumen, este proyecto no solo ha sido una oportunidad para aplicar nuestros conocimientos teóricos en un entorno práctico, sino también una experiencia de aprendizaje que ha fortalecido nuestras habilidades técnicas, de trabajo en equipo y resolución de problemas. Estamos orgullosos del trabajo que hemos realizado juntos.

### 6.2. Trabajo en grupo

La valoración del trabajo en grupo es altamente positiva. Todos los integrantes demostraron un alto nivel de compromiso y responsabilidad, cumpliendo con sus tareas de manera puntual y eficiente. La colaboración fue fluida, con una excelente disposición para el trabajo en equipo y para apoyar a los compañeros en momentos necesarios. Además, se evidenció una notable capacidad para el análisis crítico y la resolución de problemas, lo que permitió desarrollar soluciones creativas y efectivas. En conjunto, el grupo ha logrado producir un trabajo de calidad que cumple con los estándares académicos y refleja el esfuerzo colectivo.