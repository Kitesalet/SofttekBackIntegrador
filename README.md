# Trabajo Integrador Academia Softtek TechOil 🌠


![TechOil Logo](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/fe19a6e6-aaa1-4dcf-8190-5f1cb8fceba3)

(Prestar atención al slogan 😉 )

## Descripción

Un trabajo integrador de la academia de softtek de .NET en progreso, basandose en ciertos requerimientos
especificos para la conformación del mismo. 

Esta basado en la conformación de una WEB API en .Net 6, mediante la utilización del ORM Entity
Framework, siendo code first la metodología a utilizar para crear las base de datos, y mediante el uso de DataAnnotations para
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


## **Arquitecture Specifications**
​
### **Controller Layer**
Es el punto de entrada a la API. Tenemos 5 controllers en la aplicación, uno por cada entidad de la misma ( User,Service,Project y Work ), asi como
también un controller que será utilizado para realizar los logins en la aplicación, dandonos un token que hará de sesión de usuario para que se puedan
utilizar los enpoints en los demas controllers.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/e315ddb6-4b4d-43b6-881e-2dc268731d2f)

​
### **DataAccess Layer**
Es la capa donde tendrémos la conexión o el nexo entre nuestra aplicación y la base de datos, mediante la creación de una clase denominada
AppDbContext, que hereda de DbContext, utilizando sus metodos justamente para lograr este cometido, en varios repositorios, uno por cada entidad
mencionadas anteriormente. También utilizará el patrón de diseño de Repositorio Genérico y el patron de diseño de UnitOfWork para poder tener
todos los metodos de manera mas centralizada y manejar todos los repositorios con el mismo contexto. Sumado a todo esto, en esta capa también
se tendran las clases pertinentes a lo que sería el seedeado de datos que se realizará en cada ciclo de migrations/updates a la base de dato
establecida en el appsettings.json.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/3e7d494a-89aa-47aa-943d-d8230b082db3)

​
### **Model Layer**
En este nivel de la arquitectura se definen todas las entidades de la base de datos, asi como también vamos a definir todas las interfases,
y clases comunes que se utilizan en la totalidad de la aplicación. En esta capa también se detallan la lista de los DTOs utilizados por cada entidad
y/o endpoint en los controllers y services, enumeradores, diccionarios, asi como también clases que estan asociadas a la capa Helpers.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/73e7f27e-9c1a-4a0b-8b9b-917177f5bdd0)
​

### **Service Layer**
Este nivel se encarga de lo que es la lógica de la aplicación. A este nivel de la aplicación se realiza al conexión entre la capa de controller y la capa de datos (DAL),
asi también como el mappeo de entidades a DTOs y el mapeo de DTOs a entidades mediante la utilización de la librería Nugget llamada Automapper.
Se tiene un service por cada entidad / controller para lograr este cometido, como se muestra a continuación:

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/58669982-e783-4dca-922d-6bd85153f806)

### **Helper Layer**
​
Este nivel, teniendo tres clases helpers diferentes, se encarga de lo que sería la lógica de la creación del JWT utilizado por la aplicación como metodo de
autenticación y validación de roles, asi también como la lógica de los mappeos realizados con la librería Automapper, y se encarga de lo que es la encriptación
de las passwords requerida al registrar usuarios, tanto asi como en el login de los mismos.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/1c3ac119-a129-405f-8463-edc5693e4eee)


### **Validation Layer**

Este nivel genera una abstracción en base a la validación de los datos ingresados por el usuario de la aplicación, siendo una capa fuertemente asociada al input
del usuario en los controllers, para separar la lógica de validación de los services y de los controllers, y generar una capa aparte con ese cometido.
Se tienen 4 clases implementadas, una clase por controller, para intentar lograr el cometido de verificar que los datos ingresados sean siempre validos.

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/8561d4f0-a5ee-47a9-be5b-8a786742697a)



## Other Details

### Dependencies And Installed Nuget packages

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/5de47e76-d380-46a7-91cd-fab98edce5f2)


### Installing

* Para el uso correcto del programa, se deberá cambiar el connection string en appsettings.example.json para que
  indique el de su servidor local / algun servidor en la nube el cual usted pueda administrar, asi como la configuracion del Jwt, en donde se indica a continuacion:


![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/24bd3999-dbfe-4a7b-ab9a-765c5e780499)

Como ultima instancia, se deberá eliminar el .example del appsettings.json para que el programa pueda funcionar de manera correcta.


### Executing program

Para realizar la migration y posterior creación de una Db en su server con datos seedeados, se deberán 
escribir los siguientes comandos en la Nugget Package Manager Console:

* add-migration nombre_de_migration ( Por si acaso )
* update-database

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/3687c165-a8a8-4753-b87b-de9d10abd3ce)

Cabe destacar que el programa contiene la data seedeada de dos usuarios, uno con el rol de Administrador y uno con el rol de Consultor,
cuyo token es requerido.
El mismo token se podrá conseguir desde el controller de Login, en el endpoint de Login, al realizar un login con las credenciales correctas de usuario.

Para poder probar cada endpoint, se tendrá que obtener el Token del request del siguiente endpoint, como muestra a continuación, con las credenciales
de usuario que se pueden ver en la próxima imagen:

![image](https://github.com/Kitesalet/ProyectoIntegradorSofttekImanol/assets/104630744/28c5010a-1fa6-41ec-8f5b-0b13276b6f48)

codUsuario:1
password:random




## Help

Ante cualquier consulta o problema, comunicarse via email conmigo a : kitesalett@gmail.com

## Authors

Imanol Echazarreta

## Version History

* 0.2
    * Merge errado, versión creada 😅
      
* 0.1
    * Initial Release


## Acknowledgments

* Al equipo de SoftTek por la oportunidad de participar en la academia de .Net 2023
  
______________________________________________
