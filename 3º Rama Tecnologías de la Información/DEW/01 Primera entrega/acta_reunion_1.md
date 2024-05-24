# ACTA 2: Reunión 1 
##### Grupo 3TI11_G2: Pau Amorós, Carlos Cebellan, Jorge Díez, Giorgi Dolidze, Segundo Gómez, Pau Perez y Enrique Sopeña
------------------
## Reunión 1
### 1. Preámbulo 
Fecha: 11/05/2024 de 10:30-16:30  
Identificador del grupo: 3TI11_G2  
Tipo de reunión: presencial  
Lista de asistentes:
1. Pau Amorós
2. Carlos Cebellan
3. Jorge Díez
4. Giorgi Dolidze
5. Segundo Gómez
6. Pau Perez
7. Enrique Sopeña  

Alumno firmante del documento: Giorgi Dolidze

### 2. Resumen
En esta reunión tenemos como objetivo realizar las anotaciones (logs) sobre accesos para desarrollar un filtro de entrada que anote en un fichero persistente los accesos y momentos de los diferentes servlets. 

A partir de ahora vamos a trabajar en la maquina virtual de Pau Perez, puesto que las reuniones siempre serán presenciales hemos considerado que lo mejor es trabajar todos desde una misma máquina virtual. En caso de querer de trabajar desde casa en algún momento, nuestro compañero inciará su maquina virtual y asi podremos conectarnos sin problema.

### 3.Desarrollo
Creamos un proyecto en Eclipse llamado *trabajoDEW* con las especificaciones que se explicaron anteriormente.
#### 0. Log0
Esta versión devolverá texto con informaciones relevantes. Vamos a realizar un formulario HTML mediante el cual se llamará a los logs para su ejecución.  

Creamos un servlet log0 que es el que se utilizará en index.html. Crearemos un formulario para cada log por comodidad de uso. En este caso utilizaremos el servlet log0 y tanto para GET como POST haremos tres inputs: el nombre, contraseña y el botón de envío.
```html
 <h1>log0</h1>
  <form action = "log0" method = "GET">
 	<p>Name: <input required = "required" type="text" name = "Name"><br>
 	Email: <input required = "required" type="email" name = "Email"><br>
 	Password: <input required = "required" type="password" name="Password"><br>
 	<input type="submit" value = "login">
 	</p>
 </form>
</body>
</html>
```
  

En log0.java modificaremos el método doGet con el objetivo de que cuando se reciba una solicitud GET, el servlet extraerá los parámetros de la solictud (nombre, email y contraseña) utilizando 'getQueryString' sobre 'httprequest'. Luego genera una respuesta HTML con esos parámetros junto a información adicional como la fecha y hora de la solicitud, el método, la URI y detalles del cliente. Con 'HttpServletResponse' se envía la respuesta HTML al cliente.

```java
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
```	
	

También modificaremos doPost() que llamará a doGet():
```java
        protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
                doGet(request, response);
        }
```

#### 1. Log1
En index.html añadimos el formulario correspondiente a este log.
```html
<h1>log1</h1>
  <form action = "log0" method = "GET">
 	<p>Name: <input required = "required" type="text" name = "Name"><br>
 	Email: <input required = "required" type="email" name = "Email"><br>
 	Password: <input required = "required" type="password" name="Password"><br>
 	<input type="submit" value = "login">
 	</p>
 </form>
</body>
</html>
```


  Creamos un nuevo servlet log1.java que será igual a log1.java, pero en vez de guardarlo en una página web, lo guardamos en un archivo. Para ello, modificamos el código en log1.java de esta forma:
    ```java
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

#### 2. Log2
En index.html añadimos el formulario correspondiente a este log.
```html
<h1>log2</h1>
  <form action = "log0" method = "GET">
 	<p>Name: <input required = "required" type="text" name = "Name"><br>
 	Email: <input required = "required" type="email" name = "Email"><br>
 	Password: <input required = "required" type="password" name="Password"><br>
 	<input type="submit" value = "login">
 	</p>
 </form>
</body>
</html>
```

Creamos el servlet log2, con el mismo código que log2. 
En el web.xml añadimos un <context-param> con param-name y param-value como atributos, de esta forma especificamos la ruta para dicho log2.
```code
    <context-param>
        <param-name>rutaArchivo</param-name>
        <param-value>/home/user/Escritorio/DEWTrabLog2.log</param-value>
    </context-param>
```
Añadimos en el log2.java dos líneas de código para crear un archivo asociado a la ruta que hemos creado anteriormente en el web.xml.
```java
    File file1 = new File(getServletContext().getInitParameter("rutaArchivo"));
    FileWriter pw2 = new FileWriter(file1,true);
```

### Interacciones con CentroEducativo mediante *curl*
Lo primero que vamos a hacer es instalar *es.upv.etsinf.ti.centroeducativo-0.2.0.jar* ya que actualmente no está sincronizado con *Java*, así que usaremo s *Java 8*.

Crearemos un script llamado *shell.sh*, el cual vamos a utilizar para realizar todos los cambios de *CentroEducativo*.

Desclararemos variables de entorno para que el desarrollo del ejercicio sea más cómodo:  
- CentroEducativo
- key: contendrá la clabe para iniciar sesión

```sh
CentroEducativo="http://dew-ccebfer-2324.dsic.cloud:9090/CentroEducativo"
KEY=$(curl -s --data '{"dni":"23456733H","password":"654321"}' -X POST -H "content-type: application/json" ${CentroEducativo}/login -H "accept: /" -c cookies -b cookies)
```


Ahora vamos a realizar algunas consultas para probar el funcionamiento de *curl* en *CentroeEducativo*. Queremos obtener los *json* de las asignaturas existentes, para más tarde modificarlo añadiendo alguna asignatura no existente anteriormente. Fianalmente realizaremos otra lectura para comprobar que la operación se ha realizado correctamente.

#### 1. Leer alumnos y asignaturas
```sh
#leer alumno y asignaturas
echo "Consulta de alumnos y asignaturas"
curl -s -X GET 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnosyasignaturas?key='$KEY -H "accept: application/json" -b cookies -c cookies
```
Con *-X GET* especificamos el método HTTP que utilizaremos en la solicitud, y como estamos solicitando datos del servidor utilizamos *GET*.

El *-H "accept: application/json"* especifica al encabezado HTTP "Accept" que indica al servidor que queremos recibir la respuesta en formato *JSON*, un formato de datos ligero que se utiliza para intercambiar datos entre un servidor y un cliente en aplicaciones web. 

Finalmente utilizamos *b cookies -c cookies* indicamos a *curl* que use un archivo para enviar/recibir cookies del servidor, con el fin de mantener la sesión activa.

La salida de la orden es la siguiente:
![alt text](image-1.png)

#### 2. Modificar alumno
```shell
#modificacion alumno
curl -s --data '{"apellidos": "Garcia Lopez", "dni": "33445566X", "nombre": "Juan","password": "123456"}' \
-X POST -H "content-type: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY \-c cookies -b cookies
```

La opción *-s* indica a cul que debe ser silencioso, NO mostrará la barra de progreso ni los mensajes de error.

Estos datos (en formato JSON) *--data '{"apellidos": "Garcia Lopez", "dni": "33445566X", "nombre": "Juan","password": "123456"}'* se enviarán a través de la solicitud HTTP.

*-X POST* indica que se realiza una solicitud HTTP POST y *-H "content-type: application/json"* indica al servidor que el cuerpo de la solicitud está en formato JSON. La solicitud se enviará por *http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key=*

En la salida nos devuelve OK para confirmar que todo ha ido bien y que no ha habido ningún error.


#### 3. Lectura alumno
```shell
#lectura alumno
echo "Consulta de alumno"
curl -s -X GET -H "accept: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY -b cookies -c cookies
```
Volvemos a realizar una consulta de lectura de alumnos para comprobar que se ha modificado, es decir, que se ha añadido el alumno del paso 2.

![alt text](image-2.png)


### 4. Problemas y contacto con el profesor
En este caso, hemos necesitado preguntar al profesor porque en el *pdf* se explica que se debe cambiar *java* por *JAVA* en el archivo *web.xml* pero al hacerlo da error (Cannot find the declaration of element "web-app"). Como no hemos podido realizar el cambio, hemos decidido dejarlo como estaba inicialmente en *java*.