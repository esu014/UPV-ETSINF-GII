# MEMORIA TRABAJO DEW 2324 TI11-G2

## Índice

1. [Introducción](#1-Introduccion)
2. [Descripción del Problema](#2-Descripción-del-Problema)
    1. [Hito 1](#21-Hito-1)
    2. [Hito 2](#22-Hito-2)
    3. [Hito 3](#23-Hito-3)
3. 

## 1. Introducción
Este trabajo sobre NotasOnLine, del curso 2023-2024, ha sido realizado por el grupo TI11-G2, cuyos miembros del equipo son Pau Amoros ...

El proyecto consiste en generar una Aplicación Web, llamada NotasOnLine, en la que tanto alumnos como profesores, que previamente han sido registrados sus datos en la base de datos del sistema (CentroEducativo) son capaces de interactuar entre ellos para consultar y/o modificar las notas. Todo dependerá del rol que tengan (alumno o profesor). Para cada rol hay distintos casos de uso. Por ejemplo los alumnos no pueden modificar notas, solo pueden consultar sus notas y no las de ningún otro alumno. Y los profesores pueden calificar a los alumnos a los que imparte clases, es decir, están matriculados en la/s asignatura/s que imparte ese profesor.

En el presente documento se expone detalladamente el proceso de resolución del escenario inicial planteado por el profesor en el marco de la asignatura Dessarrollo Web. A lo largo de esta memoria se describirán las etapas y metodologías empleadas para abordar y solucionar dicho problema. Cada sección de este informe proporcionará una visión comprensiva de los enfoques adoptados, las herramientas utilizadas y los resultados obtenidos. Esta estructura permitirá una comprensión clara y concisa de cómo se ha logrado transformar el escenario inicial en una solución efectiva y robusta.

## 2. Descripción del Problema

Como se ha comentado anteriormente, el escenario a solucionar consistía en diseñar una Aplicación Web en la que usuarios de un centro escolar, pudieran interactuar de manera online; con sus respectivas limitaciones y seguridad; para consultar sus notas, en caso de ser alumno, y además poder modificarlas, en caso solamente, de ser profesor. Para completar la tarea, era obligatorio el uso de algunas herramientas, vistas previamente en teoría; como puede ser la biblioteca `Bootstrap`, para el diseño web o desarrollar interfaces dinámicas; las cuales obligan a utilizar la biblioteca `JQuery` y en caso de requerir datos; que obviamente se necesitan; utilizar `AJAX`.

El escenario de la entrega se ha dividido en distintos hitos, 3 para ser exacto. En cada hito, el nivel de complejidad aumenta. 

### 2.1 Hito 1
El hito 1, consiste básicamente en una toma de contacto con los servelts, con la base de datos, localizada en la maquina host, en el puerto 9090; y con el formato `MD`, para realizar las actas, ya que es algo nuevo también para la mayoria de la clase. 

Como se observa, hay 3 subtareas:
1. **Programar servlet**. Básicamente consiste en crear un primer servlet con la función de iniciar sesion con un usuario; y a partir de este servlet, añadirle características como que se escriba en un fichero los registros de inicio de sesion en el supuesto servidor (aqui todavía no hay nada implementado relacionado con el escenario). 
2. **Script con la herramienta Curl para realizar peticiones a la base de datos**. Esta tarea consiste en generar un script en el que mediante la herramienta Curl, se pruebe a hacer peticiones a la base de datos. De esta manera, se puede entender como funciona la base de datos y se observa como tienen que ser las peticiones que posteriormente realizarán los servlet, tanto a la hora de modificar el estado de la BD como hacer simples consultas. 
3. **Acta en formato MD**. 

