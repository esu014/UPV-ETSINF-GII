############################
#                          #
# TRABAJO REALIZADO POR:   #
#  ANASS LAMBARAA,         #
#  PABLO RAGA              #
#  ENRIQUE SOPEÑA          #
#                          #
############################





function Set-Inheritance ([String]$path, [boolean]$inherit) {

    <#
        .SYNOPSIS
        Establece la herencia en la carpeta ‘path’.
        La habilita si ‘inherit’ es $true o la deshabilita si ‘inherit’ es $false 
    #>

    $acl = Get-ACL "$path" 
    $acl.SetAccessRuleProtection((-not $inherit), $false)
    Set-ACL "$Path" $acl
}


function Add-Ace ([String]$path, [String]$group, [String]$permission) {
    
    <#
        .SYNOPSIS
        En la carpeta ‘path’, concede al grupo especificado un cierto permiso.
        Los permisos pueden ser, entre otros: “FullControl”, “Modify”, “Write” y “ReadAndExecute”
    #>
    
    $acl = Get-ACL "$Path"
    $sid = (Get-ADGroup -filter { name -eq $group }).sid

    $rights = [System.Security.AccessControl.FileSystemRights]$permission 
    $inheritanceFlag = [System.Security.AccessControl.InheritanceFlags]'ContainerInherit, ObjectInherit'
    $propagationFlag = [System.Security.AccessControl.PropagationFlags]'None'
    $type = [System.Security.AccessControl.AccessControlType]'Allow'

    $ace = New-Object System.Security.AccessControl.FileSystemAccessRule `
    ($sid, $rights, $inheritanceFlag, $propagationFlag, $type) 

    $acl.AddAccessRule($ace)
    Set-ACL "$Path" $acl
}

Write-Host "" 
Write-Host "Trabajo realizado por:" -ForegroundColor Yellow
Write-Host "   Anass Lambaraa, Pablo Raga, Enrique Sopeña" -ForegroundColor Yellow
Write-Host "   Del grupo XM01" -ForegroundColor Yellow
Write-Host "" 

########
# RETO 1
########


$carpeta = "c:\Temp-Diseños"

$res = Test-Path -Path $carpeta -PathType Container

if ($res) {

  Remove-Item -Path $carpeta -Recurse -confirm:$false
}

New-Item -Path $carpeta -ItemType "Directory"


$nombre_unidad = "Temp-UO"
$dn_contenedor  = "dc=admon,dc=lab"
$dn_unidad = "ou=Temp-UO,dc=admon,dc=lab"

# crea la UO $nombre_unidad en el contenedor $dn_contenedor,
# sin protección ante borrado accidental
# eliminándola previamente en caso de que exista


$unidad = Get-ADOrganizationalUnit -Filter {Name -eq $nombre_unidad} -SearchBase $dn_contenedor -SearchScope OneLevel

if ($unidad -ne $null) {
   Remove-ADOrganizationalUnit -Identity $dn_unidad -Recursive -confirm:$false
}

New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Diseño"
$dn_contenedor  = "ou=Temp-UO,dc=admon,dc=lab"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Usuarios"
$dn_contenedor  = "ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Roles"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false

$nombre_unidad = "Recursos"
New-ADOrganizationalUnit -Name $nombre_unidad -Path $dn_contenedor -ProtectedFromAccidentalDeletion $false


Write-Host ""
Write-Host "Reto 1 acabado" -ForegroundColor Green
Write-Host ""

########
# RETO 2
########

$CSV = ".\plantilla-1.csv"

$dn_contenedor = "ou=Usuarios,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"

import-csv -path $CSV  | ForEach-Object { 
    [string]$persona = $_.persona

    Write-Host "Procesando la fila persona = $persona"

    $linea_correcta = $true
    $usuario = Get-ADUser -Filter {Name -eq $persona}

    if ($usuario -ne $null) {
        Write-Host "El usuario $persona ya existe" -ForegroundColor Magenta
        $linea_correcta = $false
    }

    if ($linea_correcta) {

        $contraseña = "Admon.lab.1"
        $hash = Convertto-SecureString -AsPlainText $contraseña -Force

        New-ADUser -Name $persona -AccountPassword $hash -ChangePasswordAtLogon $false -Enabled $true -Path $dn_contenedor
    }          

}

Write-Host ""
Write-Host "Reto 2 acabado" -ForegroundColor Green
Write-Host ""

########
# RETO 3
########

$dn_contenedor = "ou=Recursos,ou=Diseño,ou=Temp-UO,dc=admon,dc=lab"
$CSV = ".\proy-niveles.csv"
import-csv -path $csv | ForEach-Object{
    [string]$proyecto = $_.proyecto
    [string] $niveles = $_.niveles
    Write-Host $proyecto
    $lista_niveles = $niveles -split "/"
    $linea_correcta = $true
    $ruta_a_carpeta = "$carpeta\$proyecto"
     if($proyecto -eq "" -or $niveles -eq ""){
        $linea_correcta = $false
        Write-Host "Faltan valores" -ForegroundColor Magenta
    }
    elseif(Test-Path -Path $ruta_a_carpeta -PathType Container){
        $linea_correcta = $false
        Write-Host "Carpeta ya existe" -ForegroundColor Magenta
    }
    $NIVELES_ASOCIADOS = @("gestion","supervision","trabajo","lectura")
    foreach ($nivel in $lista_niveles){
        if ( $nivel -notin $NIVELES_ASOCIADOS){
            $linea_correcta = $false
            Write-Host "Nivel no valido" -ForegroundColor Magenta
            break
        }
    }
   
    if($linea_correcta -eq $true){
        New-Item -Path $ruta_a_carpeta -ItemType Directory
        Write-Host "Carpeta creada en : $ruta_a_carpeta"
        foreach ($nivel in $lista_niveles){
            $ngrp = "ACL-$proyecto-$nivel"
            New-ADGroup -Name $ngrp -GroupScope "DomainLocal" -Path $dn_contenedor
            switch($nivel){
                "gestion" {
                    Add-ACE -Path $ruta_a_carpeta -group $ngrp -permission "FullControl"
                    break
                }
                "spervision" {
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
}

Write-Host ""
Write-Host "Reto 3 acabado" -ForegroundColor Green
Write-Host ""

########
# RETO 4
########

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
    if($linea_correcta -eq $true){
        foreach ($roles in $lista_roles){
            $nrol = "$proyecto-$roles"
            $ngroup = "ACL-$proyecto-$niveles"
            New-ADGroup -Name $nrol -GroupScope "Global" -Path $dn_contenedor
            Add-ADGroupMember -Identity $ngroup -Members $nrol

        }
    }
}

Write-Host ""
Write-Host "Reto 4 acabado" -ForegroundColor Green
Write-Host ""

########
# RETO 5
########

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

    #si no ha habido fallos...
    if($linea_correcta -eq $true){
        foreach($usuarios in $lista_usuarios){
            Add-ADGroupMember -Identity $grupo -Members $usuarios
        }
    }
}

    