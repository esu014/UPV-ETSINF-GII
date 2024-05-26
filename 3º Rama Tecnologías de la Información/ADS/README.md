# PRÁCTICA 6 ADS

## Introducción sobre el código en a6.ps1

El código que se facilita en github está realizado por los alumnos Anass Lambaraa, Pablo Raga y Enrique Sopeña, en el curso 2023-2024.

En el archivo solo están los retos obligatorios. El reto 6 (opcional), no lo hemos llegado a hacer.

## Calificación obtenida

A día de hoy aun no sabemos la nota, pero se actualizará el README.md con la calificación en cuanto se haya obtenido. 

## Explicación del código 

Al principio los profesores te dan parte de los retos de la práctica resueltos, estos son el reto 1 y el reto 2. A partir del reto 3 es donde se ha modificado el código para poder llegar a cada una de las soluciones para los retos propuestos. 

### Reto 1

En el reto 1 se pide crear una estructura inicial de unidades organizativas y carpetas para ubicar los objetos de Active Directory (AD) relacionados con nuevos empleados y proyectos. Para no interferir con el funcionamiento normal del dominio durante el desarrollo y validación, ambas estructuras se deben crear en ubicaciones temporales. Las indicaciones son las siguientes:
-  Unidades Organizativas (UO): La estructura se creará a partir de la unidad "Temp-UO", que debe ubicarse bajo el contenedor raíz del dominio "admon.lab". Dentro de "Temp-UO", se creará la unidad "Diseño" y, dentro de esta, tres subunidades: "Usuarios", "Roles" y "Recursos". Estas subunidades albergarán objetos relacionados con empleados, roles y niveles de acceso de los proyectos.
- Carpetas: La estructura de carpetas se creará a partir de la carpeta C:\Temp-Diseños\ en el sistema SW2. Dentro de esta carpeta se crearán las carpetas específicas para cada proyecto.
- **IMPORTANTE**: Cada vez que se ejecute, el script debe primero eliminar ambas estructuras (junto con todo su contenido) y volver a crearlas antes de proceder con el procesamiento de los ficheros de entrada.

### Solución
Definir la ruta de la carpeta temporal:
```powershell
$carpeta = "c:\Temp-Diseños"
```
Comprobar si la carpeta ya existe:
```powershell
$res = Test-Path -Path $carpeta -PathType Container
```
Eliminar la carpeta si existe:
```powershell
if ($res) {
    Remove-Item -Path $carpeta -Recurse -confirm:$false
}
```
Crear la carpeta nuevamente:
```powershell
New-Item -Path $carpeta -ItemType "Directory"
```
Definir los nombres y rutas de las unidades organizativas (UO):
```powershell
$nombre_unidad = "Temp-UO"
$dn_contenedor  = "dc=admon,dc=lab"
$dn_unidad = "ou=Temp-UO,dc=admon,dc=lab"
```
Eliminar la UO si ya existe:
```powershell
$unidad = Get-ADOrganizationalUnit -Filter {Name -eq $nombre_unidad} -SearchBase $dn_contenedor -SearchScope OneLevel
if ($unidad -ne $null) {
    Remove-ADOrganizationalUnit -Identity $dn_unidad -Recursive -confirm:$false
}
```
Crear la UO "Temp-UO":
```powershell
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false
```
Crear la subunidad "Diseño" dentro de "Temp-UO":
```powershell
$nombre_unidad = "Diseño"
$dn_contenedor  = "ou=Temp-UO,dc=admon,dc=lab"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false
```
Crear las subunidades "Usuarios", "Roles" y "Recursos" dentro de "Diseño":
```powershell
$nombre_unidad = "Usuarios"
$dn_contenedor  = "ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Roles"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Recursos"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false
```
### Reto 2
En el reto 2 se pide procesar un fichero de entrada y realizar las siguientes tareas:

- Crear nuevos usuarios: Para cada persona detectada en el fichero, se debe crear un nuevo usuario en la unidad temporal "Usuarios", con una contraseña sin cifrar "Admon.lab.1". La cuenta del usuario debe permitir iniciar sesión con dicha contraseña en los miembros del dominio.

- Gestión de errores: Ante cualquier línea incorrecta en el fichero, el script no debe crear el usuario, sino imprimir un mensaje de error en pantalla, detallando claramente el motivo del error y el valor del atributo que lo produjo. No es necesario indicar el número ni los valores de líneas anteriores que puedan estar relacionadas con el error.

### Solución
Se especifica la ruta del fichero CSV que contiene los datos de los usuarios a crear:
```powershell
$CSV = ".\plantilla-1.csv"
```
Se define la ruta de la UO "Usuarios" dentro de la estructura temporal del dominio.
```powershell
$dn_contenedor = "ou=Usuarios,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
```
Se importa el fichero CSV y se itera sobre cada fila para procesar los datos de los usuarios:
```powershell
import-csv -path $CSV | ForEach-Object { 
```
Se extrae el nombre de la persona de la fila actual y se muestra en pantalla:
```powershell
[string]$persona = $_.persona
Write-Host "Procesando la fila persona = $persona"
```
Inicializar una variable para verificar si la línea es correcta
```powershell
$linea_correcta = $true
```
Se busca si ya existe un usuario con el mismo nombre en AD. Si existe, se muestra un mensaje en pantalla y se marca la línea como incorrecta:
```powershell
$usuario = Get-ADUser -Filter {Name -eq $persona}

if ($usuario -ne $null) {
    Write-Host "El usuario $persona ya existe" -ForegroundColor Magenta
    $linea_correcta = $false
}
```
Si la línea es correcta:

- Se define una contraseña por defecto ("Admon.lab.1").
- Se convierte la contraseña en un SecureString.
- Se crea el nuevo usuario en la UO especificada con la contraseña definida, configurado para no requerir el cambio de contraseña al iniciar sesión por primera vez y habilitado para su uso inmediato.
```powershell
if ($linea_correcta) {
    $contraseña = "Admon.lab.1"
    $hash = Convertto-SecureString -AsPlainText $contraseña -Force
    New-ADUser -Name $persona -AccountPassword $hash -ChangePasswordAtLogon $false -Enabled $true -Path $dn_contenedor
}  
```

### Reto 3
En el reto 3 se pide procesar un fichero de entrada y realizar las siguientes tareas:

- Crear infraestructura para cada proyecto:

    - Crear carpeta del proyecto: Crear la carpeta del proyecto en C:\Temp-Diseños\ de SW2 si no existe.
    - Crear grupo ACL: Crear un grupo de ámbito de dominio local ("grupo ACL") en la unidad temporal "Recursos". Este grupo debe nombrarse como "ACL-proyecto-nivel" (por ejemplo, "ACL-Peli2001-gestion").
    - Asignar permisos: Asignar al grupo ACL el permiso correspondiente al nivel de acceso en la carpeta del proyecto, utilizando el permiso estándar de menor rango que permita las operaciones asociadas a ese nivel.
- Gestión de errores: Ante cualquier línea incorrecta en el fichero, el script no debe realizar las tareas anteriores, sino imprimir un mensaje de error en pantalla, detallando claramente el motivo del error y el valor del atributo que lo produjo.

### Solución 
Obtener los datos iniciales del fichero y guradarlos en variables para luego operar con ellos:
```powershell
$dn_contenedor = "ou=Recursos,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
$CSV = ".\proy-niveles.csv"
import-csv -path $csv | ForEach-Object{
    [string]$proyecto = $_.proyecto
    [string] $niveles = $_.niveles
    Write-Host $proyecto
    $lista_niveles = $niveles -split "/"
    $linea_correcta = $true
    $ruta_a_carpeta = "$carpeta\$proyecto"
```
Comprobar los distintos casos en los que puede dar error a la hora de crear los recursos:
```powershell
    # Verifica si el proyecto o los niveles están vacíos
    if($proyecto -eq "" -or $niveles -eq ""){
        $linea_correcta = $false
        Write-Host "Faltan valores" -ForegroundColor Magenta
    }
    # Verifica si la carpeta del proyecto ya existe
    elseif(Test-Path -Path $ruta_a_carpeta -PathType Container){
        $linea_correcta = $false
        Write-Host "Carpeta ya existe" -ForegroundColor Magenta
    }
    $NIVELES_ASOCIADOS = @("gestion","supervision","trabajo","lectura")
    foreach ($nivel in $lista_niveles){
        # Verifica si el nivel es válido
        if ( $nivel -notin $NIVELES_ASOCIADOS){
            $linea_correcta = $false
            Write-Host "Nivel no valido" -ForegroundColor Magenta
            break
        }
    }
```
Si la línea es correcta, crea la carpeta del proyecto y muestra un mensaje de confirmación y para cada nivel válido, crea un grupo ACL y asigna los permisos correspondientes a la carpeta del proyecto utilizando la función Add-ACE para configurar los permisos de acceso.
```powershell
    if($linea_correcta -eq $true){
        # Crea la carpeta del proyecto
        New-Item -Path $ruta_a_carpeta -ItemType Directory
        Write-Host "Carpeta creada en : $ruta_a_carpeta"

        foreach ($nivel in $lista_niveles){
            # Genera el nombre del grupo ACL
            $ngrp = "ACL-$proyecto-$nivel"
            # Crea el grupo ACL en AD
            New-ADGroup -Name $ngrp -GroupScope "DomainLocal" -Path $dn_contenedor

            # Asigna permisos a la carpeta del proyecto según el nivel
            switch($nivel){
                "gestion" {
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "FullControl"
                    break
                }
                "supervision" {
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "ReadAndExecute"
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "Write"
                    break
                }
                "trabajo" {
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "Modify"
                    break
                }
                "lectura" {
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "ReadAndExecute"
                    break
                }
            }
        }
    }
}#llave del ForEach inicial
```
### Reto 4
En el reto 4 se pide procesar un fichero de entrada y realizar las siguientes tareas: crear los grupos de ámbito global necesarios para representar en el dominio los roles relacionados con el proyecto que aparecen en la línea, en la unidad temporal "Roles", y asignar a dichos grupos como miembros del "grupo ACL" que representa el nivel de acceso que aparece en la línea. 
Ante cualquier línea incorrecta, el script debe imprimir un mensaje de error en pantalla, detallando claramente el motivo del error y, en su caso, el valor del atributo que produce dicho error. 

### Solución:
Obtener los datos iniciales del fichero y guradarlos en variables para luego operar con ellos:
```powershell
$dn_contenedor = "ou=Roles,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
$CSV = ".\proy-roles.csv"
import-csv -path $csv | ForEach-Object{
    [string] $proyecto = $_.proyecto
    [string] $niveles = $_.nivel
    [string] $roles = $_.roles
    $lista_roles = $roles -split "/"
    $linea_correcta = $true
    $ruta_a_carpeta = "$carpeta\$proyecto"
    Write-Host $ruta_a_carpeta
```
Comprobar los distintos casos en los que puede dar error a la hora de crear los recursos:
```powershell
    #comprobar si existe la carpeta
    if( -not (Test-Path -Path $ruta_a_carpeta -PathType Container)){
        $linea_correcta = $false
        Write-Host "Error: no existe $proyecto" -ForegroundColor Magenta
    }
    #comprobar si los roles están en los que debe
    $ROLES_ASOCIADOS = @("director","publicista","web","diseñador","ilustrador")
    foreach ($roles in $lista_roles){
        if ( $roles -notin $ROLES_ASOCIADOS){
            $linea_correcta = $false
            Write-Host "Error: Rol no valido" -ForegroundColor Magenta
            break
        }
    }
    #comprobar si alguno de los elementos de la lista estran vacios
    if($proyecto -eq ""){
        $linea_correcta = $false
        Write-Host "Error: Proyecto vacio." -ForegroundColor Magenta
    }
    if($niveles -eq ""){
        $linea_correcta = $false
        Write-Host "Error: Nivel vacio." -ForegroundColor Magenta
    }
    $grupo = "ACL-$proyecto-$niveles"
    [string] $nombre = Get-ADGroup -Filter {Name -eq $grupo}
    if($nombre -eq ""){
         $linea_correcta = $false
        Write-Host "Error: $nivel no valido para este proyecto." -ForegroundColor Magenta
    }
    if($roles -eq ""){
        $linea_correcta = $false
        Write-Host "Error: Rol vacio." -ForegroundColor Magenta
    }
```
Si está todo correcto, crea los grupos de ámbito global necesarios para representar los roles relacionados con el proyecto y asignarlos como miembros del grupo ACL correspondiente, pero solo si la línea del archivo CSV es válida:
```powershell
    if($linea_correcta -eq $true){
        foreach ($roles in $lista_roles){
            $nrol = "$proyecto-$roles"
            $ngroup = "ACL-$proyecto-$niveles"
            New-ADGroup -Name $nrol -GroupScope "Global" -Path $dn_contenedor
            Add-ADGroupMember -Identity $ngroup -Members $nrol
        }
    }
}#llave del ForEach inicial
```
### Reto 5
En el reto 5, a partir de un fichero de entrada, el script debe añadir al usuario o usuarios de la lista de empleados de cada línea al grupo de rol indicado en dicha línea. No es necesario comprobar si algún usuario ya formaba parte de ese grupo de rol, ya que volver a añadirlos no afecta a la composición definitiva del grupo.
Ante cualquier línea incorrecta, el script no debe realizar las tareas anteriores, sino que debe imprimir un mensaje de error en pantalla, detallando claramente el motivo y, en su caso, el valor del atributo que produce dicho error.
### Solución
Como en los retos anteriores hay que obtener los datos iniciales del fichero y guradarlos en variables para luego operar con ellos:
```powershell
$dn_contenedor = "ou=Usuarios,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
$CSV = ".\proy-personas.csv"
import-csv -path $csv | ForEach-Object{
    [string] $proyecto = $_.proyecto
    [string] $usuarios = $_.usuarios
    [string] $rol = $_.rol
    $lista_usuarios = $usuarios -split "/"
    $linea_correcta = $true
    $ruta_a_carpeta = "$carpeta\$proyecto"
    Write-Host $ruta_a_carpeta
```
Después hay que comprobar los distintos casos en los que puede dar error a la hora de crear los recursos: 
```powershell
    #comprobar si existe el usuario
    foreach($usuarios in $lista_usuarios){
        #caso en el que este vacio, que no haya un usuario
        if($usuarios -eq ""){
            Write-Host "Error: El usuario está vacio" -ForegroundColor Magenta
            $linea_correcta = $false
            break
        }else{
            #caso en el que haya un usuario pero no exista
            [string] $persona = Get-ADUser -Filter {Name -eq $usuarios}
            if ($persona -eq "") {
                Write-Host "Error: El usuario $usuarios no existe" -ForegroundColor Magenta
                $linea_correcta = $false
                break
            }
        }
    }
    #comprobar si existe el grupo de rol
    $grupo = "$proyecto-$rol"
    [string] $nombre = Get-ADGroup -Filter {Name -eq $grupo}
    if($nombre -eq ""){
        Write-Host "Error: El grupo $grupo no existe para ese proyecto" -ForegroundColor Magenta
        $linea_correcta = $false            
    }
    #Comprobar si tienen valores tanto rol como proyecto, usuario esta arriba
    if($proyecto -eq ""){
        $linea_correcta = $false
        Write-Host "Error: Proyecto vacio." -ForegroundColor Magenta
    }
    if($rol -eq ""){
        $linea_correcta = $false
        Write-Host "Error: Rol vacio." -ForegroundColor Magenta
    }
```
Y finalmente si todo está correcto, se añaden los usuarios a un grupo de Active Directory, siempre y cuando la línea de datos que se está procesando sea correcta
```powershell
    if($linea_correcta -eq $true){
        foreach($usuarios in $lista_usuarios){
            Add-ADGroupMember -Identity $grupo -Members $usuarios
        }
    }
}#llave del ForEach inicial
```
