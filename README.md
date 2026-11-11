 GUÍA IMPORTANTE: CÓMO ENCONTRAR Y EJECUTAR LAS BASES DE DATOS

PARA VISUALIZAR, CONFIGURAR Y EJECUTAR LOS SCRIPTS DE LAS BASES DE DATOS QUE SE SUBIERON LOCALMENTE AL REPOSITORIO, SIGUE LOS SIGUIENTES PASOS:

UBICA LA CARPETA EN EL REPOSITORIO:
EN LA RAÍZ DE ESTE PROYECTO, BUSCA LA CARPETA LLAMADA EXACTAMENTE:
📂 scripsBaseDeDatos

ARCHIVOS DISPONIBLES ADENTRO:
DENTRO DE DICHA CARPETA ENCONTRARÁS LOS SCRIPTS SQL NECESARIOS PARA CREAR Y POBLAR LAS TRES BASES DE DATOS INDEPENDIENTES:

CatalogoDB (Información comercial de productos, categorías y marcas).

Inventario_T (Gestión de bodegas, existencias, movimientos y reservas).

PedidosDB (Gestión de clientes, órdenes y detalles de compra).

CÓMO EJECUTARLOS EN SQL SERVER MANAGEMENT STUDIO (SSMS):

ABRE SQL SERVER MANAGEMENT STUDIO.

HAZ CLIC EN File > Open > File (Archivo > Abrir > Archivo) Y SELECCIONA LOS SCRIPTS UBICADOS DENTRO DE LA CARPETA scripsBaseDeDatos.

EJECUTA CADA SCRIPT EN TU INSTANCIA LOCAL DE SQL SERVER PARA CREAR LAS BASES DE DATOS CON SUS RESPECTIVOS DATOS REALES DE ECUADOR.

Estructura de la Solución

Catalogo.Api: Microservicio encargado del catálogo comercial (CatalogoDB).

Inventario.ap: Microservicio encargado del control físico y existencias (Inventario_T).

Pedidos.Api: Microservicio encargado de la gestión de órdenes de compra (PedidosDB).
