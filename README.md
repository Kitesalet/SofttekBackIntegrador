# Project Title

Trabajo Integrador Academia Softtek TechOil 🌠

![TechOil Logo](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/fe19a6e6-aaa1-4dcf-8190-5f1cb8fceba3)

(Prestar atención al slogan 😉 )

## Description

Un trabajo integrador de la academia de softtek de .NET en progreso, basandose en ciertos requerimientos
especificos para la conformación del mismo. 

Esta basado en la conformación de una WEB API en .Net 6, mediante la utilización del ORM Entity
Framework, siendo code first la metodologia a utilizar para crear las base de datos, y mediante el uso de DataAnnotations para
el setteo de las propiedades de cada campo en las entidades, asi como la utilización de Fluent Api para el seedeo de la data al realizar migrations
a la base de datos, y JWT para la autorización y autenticación de la mayoría de los endpoints de la misma.

La aplicacion se basará el diseño y desarrollo de un sistema de gestión para una empresa
ficticia denominada TechOil, líder en el sector Oil & Gas en latinoamerica, para lograr un correcto ABM de nuevos usuarios con roles especificos, junto con el login
de los mismos, y un ABM para tablas de Servicios, Proyectos, Roles y Trabajos.

Las tablas que compondrá la aplicacion, junto con sus campos, a continuación:

Tabla de Servicios
![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/0b5b0699-5168-42bb-b3d2-263aed1af51a)

Tabla de Proyectos
![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/b7f74db0-1d2c-49fd-a50c-093a03df6bd5)

Tabla de Trabajos
![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/4f62a626-b702-4501-a5fc-71f581ecd061)

Tabla de Usuarios
![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/b55e7617-f665-41b1-9cd7-498c040c2091)




## Getting Started

### Dependencies And Installed Nuget packages

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/5de47e76-d380-46a7-91cd-fab98edce5f2)


### Installing

* Para el uso correcto del programa, se deberá cambiar el connection string en appsettings.json para que
  indique el de su servidor local / algun servidor en la nube el cual usted pueda administrar, de la forma que se
  indica a continuación:
  ![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/358b0235-14c5-482e-aa75-69eb596794af)


### Executing program

Para realizar la migration y posterior creación de una Db en su server con datos seedeados, se deberán 
escribir los siguientes comandos en la Nugget Package Manager Console:

* add-migration nombre_de_migration
* update-database

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/3687c165-a8a8-4753-b87b-de9d10abd3ce)


## Help

Any advise for common problems or issues.
```
command to run if program contains helper info
```

## Authors

Imanol Echazarreta

## Version History

* 0.2
    * Merge errado, versión creada 😅
      
* 0.1
    * Initial Release


## Acknowledgments
______________________________________________
