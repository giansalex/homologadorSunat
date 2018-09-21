# Homologador - Facturación Electrónica - SUNAT
[![AppVeyor](https://ci.appveyor.com/api/projects/status/ha6hpsh9075xbseh?svg=true)](https://ci.appveyor.com/project/giansalex/homologadorsunat)   
Herramienta para la homologación de Emisores y Proveedores de servicios electrónicos en Facturación Electrónica - PERU

![Alt text](/Third/formulario.png?raw=true "Pagina Principal de Homologador")

## Build
Clonar el repositorio y dentro de la carpeta, abrir powershell y ejecutar los situientes comandos
```
.paket/paket.exe install
.\build.ps1
```

## Grupo de Casos de pruebas soportados ##


GRUPO                | TIPO DE DOCUMENTO    | SERIE | Descripcion
-------------------- | -------------------- | ----- | -------------
1  :heavy_check_mark:| Facturas y Notas     | FF11  | Ventas Gravadas IGV
2  :heavy_check_mark:| Facturas y Notas     | FF12  | Ventas inafectas y/o exoneradas
3  :heavy_check_mark:| Facturas y Notas     | FF13  | Ventas gratuitas
4  :heavy_check_mark:| Facturas y Notas     | FF14  | Ventas con descuento global
5  :heavy_check_mark:| Facturas y Notas     | FF30  | Operaciones gravadas con ISC
6  :heavy_check_mark:| Facturas y Notas     | FF40  | Operaciones con percepción
7  :heavy_check_mark:| Facturas y Notas     | FF50  | Operaciones con otro tipo de moneda
8  :heavy_check_mark:| Boletas y Notas      | BB11  | Ventas Gravadas IGV
9  :heavy_check_mark:| Boletas y Notas      | BB12  | Ventas inafectas y/o exoneradas
10 :heavy_check_mark:| Boletas y Notas      | BB13  | Ventas Gratuitas
11 :heavy_check_mark:| Boletas y Notas      | BB14  | Ventas con descuento global
12 :heavy_check_mark:| Boletas y Notas      | BB50  | Operaciones con otro tipo de moneda
13 :heavy_check_mark:| Resúmenes Diarios    |   -   | Resumen diario de Boletas
14 :heavy_check_mark:| Comunicación de Baja |   -   | Comunicación de Baja
15 :heavy_check_mark:| Facturas y Notas     | FF60  | Facturas sujetas a detracción 
16 :heavy_check_mark:| Facturas y Notas     | FF70  | Facturas con operaciones de comercio exterior 
17 :heavy_check_mark:| Facturas y Notas     | FF80  | Factura – Guía
18 :heavy_check_mark:| Facturas y Notas     | FF90  | Facturas con datos no tributarios
19 :heavy_check_mark:| Facturas y Notas     | F100  | Facturas por pagos anticipados
19 :heavy_check_mark:| Facturas y Notas     | F110  | Facturas con regularización de anticipos
21 :heavy_check_mark:| Boletas y Notas      | BB40  | Boletas de venta gravadas con ISC
22 :heavy_check_mark:| Boletas y Notas      | BB50  | Boletas de Venta sujetas a Percepción
23 :heavy_check_mark:| Boletas y Notas      | BB90  | Boletas de venta con datos no tributarios
24 :heavy_check_mark:| Boletas y Notas      | B100  | Boletas de venta – emisor itineranteón

## Nota
Para los contribuyentes que quieren convertirse en emisores electronicos, SUNAT segun la resolución de superintendencia [n° 287-2017](http://www.sunat.gob.pe/legislacion/superin/2017/287-2017.pdf) elimina la presentación de la solicitud de autorización así como el procedimiento de homologación. 

## Video Demostrativo ##
[![Alt text](/Third/demostracion-video-homologador.png?raw=true "Youtube Homologador")](https://youtu.be/x1zJROi-qvM)
