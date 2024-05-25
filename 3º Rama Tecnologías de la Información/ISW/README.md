# ISW 23-24

Proyecto UPVTube.


## Información

El trabajo ha sido realizado por los alumnos Anass Lambaraa y Enrique Sopeña. 
Éste consistía en diseñar una Aplicación de escritorio similar a la que tiene la UPV, [MediaUPV](https://media.upv.es)

Normalmente los proyectos suelen ser similares a los de otros años pero no igual, por lo que puede haber código reutilizable. 
El proyecto se realiza en el lenguaje `C#`, así que es de gran utilidad, si no habeis tocado nunca el lenguaje, leer un poco él código (además de lo que se trabaja en clase)


## Calificación 

La calificación obtenida en el trabajo es de un **5**. Esto se debe a que hubo un problema con el git de Azure, que no nos guardo las últimas modificaciones de errores solucionados. Y a la hora de enseñarselo al profesor, al no estar las correcciones, no funcionaba perfectamente. 
Este nos dejo 12h de plazo para poder entregarselo, por lo que nos pusimos como locos a mejorar los máximos errores posibles. 
Esta entrega extra, iba a ser penalizada (completamente comprensible) por ser entregado fuera de plazo, en la que según él nos bajó algo más de un punto por entregarse una segunda vez fuera de plazo.
### Errores finales que nos dijo el profesor tras la segunda corrección
Las anotaciones del profesor fueron las siguientes:
> Las ventanas  no son modales. 
> No encuentra para la misma fecha inicial y final.
> Al intentar evaluar un contenido (el único por evaluar) genera una excepción de salida de rango si no está seleccionada la fila del grid
> Buscar contenido no se refresca después de evaluar contenido.


## Herramientas

Como herramientas se utiliza el lenguaje mencionado ya anteriormente, `C#` y el entorno de desarrollo VisualStudio, no VisualStudio Code, cuidado.


### Recomendaciones sobre las herramientas
1. Cuidado con modificar código fuera del archivo `Solution.sln`. Para modificar cualquier parte del código, hay que meterse dentro de VS (VisualStudio), y dentro de la **vista de solucion, NO la de carpeta**, modificar las clases y/o carpetas. 
2. Los paquetes NuGet son muy puñeteros. El archivo que te pueden dar para los test, alguna librería, o código comprimido, hay que tener **MUCHO CUIDADO** en donde se insertan, porque sino a la hora de ejecutar estos test que te suministran, dirá que no se ha instalado el paquete NuGet correspondiente y empezará a ejecutar los test sin ellos. Como resultado saldrá como que está todo bien pero no es así, sale verde porque es el resultado del profesor. **CUIDADO**.
3. Como último aviso asi importante es que os mireis algún tutorial de git por si no lo habeis utilizado nunca (`commit, push, pull, clone y las ramas`) y que vayais haciendo commits y push constantemente, y **comprobar que se hace**, y que así no os pase como a nosotros. Para comprobarlo, basta con entrar en Azure y ver si los cambios se han aplicado. 