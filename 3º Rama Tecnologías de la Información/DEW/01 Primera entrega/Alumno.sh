#!/bin/bash
#la clave
KEY=$(curl -s --data '{"dni":"111111111","password":"654321"}' \
-X POST -H "content-type: application/json" http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/login \
-c cookies -b cookies)

#leer alumno y asignaturas
echo "Consulta de alumnos y asignaturas"
curl -s -X GET 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnosyasignaturas?key='$KEY -H "accept: application/json" -b cookies -c cookies
echo
#modificacion alumno
curl -s --data '{"apellidos": "Garcia Lopez", "dni": "33445566X", "nombre": "Juan","password": "123456"}' \
-X POST -H "content-type: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY \
-c cookies -b cookies
echo
#lectura alumno
echo "Consulta de alumno"
curl -s -X GET -H "accept: application/json" 'http://dew-esopurb-2324.dsicv.upv.es:9090/CentroEducativo/alumnos?key='$KEY -b cookies -c cookies