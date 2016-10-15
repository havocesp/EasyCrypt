# EasyCrypt 
===========
#### Autor: Daniel J. Umpiérrez
***
## Contenido
============
1. [Novedades](novedades)
2. [TODO](todo)
3. [Objetivo](objetivo)
4. [Algunas características](caracteristicas)
5. [Datós técnicos](datos)
6. [Colaboración](colaborar)
7. [Donaciones](donaciones)
8. [Screenshots](imagenes)

<a name="novedades" />
## Novedades (15/10/2016)
Añadida TODO list con lo que se pretende lleva a cabo.

<a name="todo" />
### TODO
Los nuevos objetivos van enfocados a darle mas funcionalidades al software de manera que sea polivalente, el lista TODO de momento queda así:
* Permitir respaldo de los datos de una forma muy sencilla.
* Opción de cifrar todos los ficheros del soporte de almacenamiento.
* Ejecución en segundo plano de forma que de forma silenciosa cifre todo lo que se copie al la unidad.
* Mas algoritmos de cifrado incluidos los asimétricos.
* Permitir el borrado seguro no solo tras el cifrado sino como una acción más.
* Ventana de configuración que permita establecer opciones como el no cifrar o borrar de forma segura ficheros cuyo tamaño exceda de cierta cantidad de Mb o Kb.
* Implementar un botón de pánico o similar que permita el borrado seguro de los datos de forma remota en caso de perdidad o extravío del soporte de almacenamiento.
* Mejora de rendimiento implementando las tareas mas pesadas en lenguajes más rápidos como C o C++.

<a name="objetivo" />
## Objetivo
Desarrollar una aplicación que permita el cifrado / descifrado de los datos personales del usuario de una manera simple y que además pueda ser usada en varios sistemas operativos y desde un dispositivo USB sin necesidad de instalación alguna.

Se pretende que a largo plazo esta aplicación debería ser la "navaja suiza" en cuanto al cuidado de los datos personales de los usuarios, dotandola de posibilidad de backup, botón del pánico, etc.

<a name="caracteristicas" />
## Algunas características
* Fácil de usar, sólo tienes que arrastrar los ficheros a cifrar / descifrar a una ventana, teclear la clave y hacer clic en un botón.
* Esta desarrollada con la idea de ser potable, así que, puedes llevarla siempre en tu disco duro o memoria USB.
* El único requisito para que funcione es tener instalado .NET Framework en Windows y MonoDevelop en Linux
* Es libre y gratuito.

<a name="datos" />
## Datos técnicos
* Desarrollada .NET C# 
* Algoritmo de cifrado AES-256 
* Contraseñas "salteadas" y "hasheadas" en SHA
* Permite borrado seguro de los ficheros una vez han sido cifrados.

<a name="colaborar" />
## Colaboración
Si deseas colaborar con este proyecto ponte en contacto conmigo en contacto@danielumpierrez.es.

<a name="donaciones" />
## Donaciones
Se aceptan y se agradecen donaciones en cualquiera de los siguientes sistemas de pago:
![Bitcoin](http://i0.wp.com/danielumpierrez.es/wp-content/uploads/2016/10/Btc-Electrum-EasyCrypt.png)
* Bitcoin: (bitcoin:13xJFGt3hHzZbwcGSewJjqevWLHP4v4E6o)
* Paypal: mediante envíos a danielumpierrezdelrio@gmail.com
* Skrill: mediante envíos a danielumpierrezdelrio@gmail.com

<a name="imagenes" />
## Screenshots
![Sreenshot 01](http://i1.wp.com/danielumpierrez.es/wp-content/uploads/2016/04/EasyCrypt.png)
