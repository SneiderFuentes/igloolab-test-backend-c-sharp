# Igloobal Test Backend (C#)
Este repositorio corresponde a una API REST implementada con **ASP.NET Core (net8.0)**, **Entity Framework Core** y **PostgreSQL**, enfocada en la gestión de productos farmacéuticos. Su propósito es ilustrar una arquitectura básica para exponer y consumir datos relacionados con productos a través de endpoints HTTP.

## Requisitos Previos
1.  **.NET 8.0**
Se recomienda descargar e instalar el SDK de .NET desde:
https://dotnet.microsoft.com/en-us/download
Para confirmar la instalación, se sugiere ejecutar:

```bash
dotnet --version
```
2. **PostgreSQL**
Es necesario contar con un servidor PostgreSQL en ejecución. Se recomienda descargarlo desde:
https://www.postgresql.org/download/
El usuario deberá verificar que la base de datos esté creada y que disponga de credenciales válidas.

3. **Editor o IDE**
Puede emplearse Visual Studio, Rider, Visual Studio Code u otro editor compatible con proyectos .NET.

## Configuración del Proyecto
1.  **Clonar** este repositorio o descargar el contenido en formato ZIP:

```bash
git clone https://github.com/SneiderFuentes/igloobal-test-backend-c-sharp.git
cd igloobal-test-backend-c-sharp
```

2.  **Examinar el archivo de proyecto (.csproj)**
Este archivo incluye las referencias necesarias para Entity Framework Core y el proveedor de PostgreSQL (Npgsql). Asimismo, se configura la versión de .NET (net8.0).

3.  **Modificar appsettings.json**
El archivo appsettings.json contiene la cadena de conexión a PostgreSQL. A modo de ejemplo:

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=igloolab_test_db;Username=postgres;Password=postgres"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```
El usuario deberá ajustar Host, Port, Database, Username y Password de acuerdo con su entorno.

## Migraciones y Base de Datos
1.  **Creación de la base de datos**
Si se prefiere crear la base de datos de forma manual, puede emplearse:

```bash
CREATE DATABASE igloolab_test_db;
```
También puede utilizarse pgAdmin u otra herramienta de administración para tal fin.

2. **Migraciones**
Si ya existe una migración inicial, es posible actualizar la base de datos ejecutando:

```bash
dotnet ef database update
```
En caso de requerir la creación de una nueva migración:

```bash
dotnet ef migrations add NombreDeLaMigracion
dotnet ef database update
```
De esta manera, Entity Framework Core generará o actualizará las tablas correspondientes.

## Ejecución de la Aplicación
1.  **Compilación y ejecución en modo desarrollo**
Se sugiere abrir una terminal en la carpeta raíz del proyecto y ejecutar:

```bash
dotnet run
```
De manera predeterminada, la aplicación se publicará en http://localhost:5000 o https://localhost:5001, según la configuración especificada.

2. **Consumo de endpoints**
Se recomienda el uso de herramientas como Postman, cURL o Insomnia para probar los endpoints.

GET /api/product para obtener la lista de productos.
POST /api/product para crear un nuevo producto.
DELETE /api/product/{id} para eliminar un producto por su identificador.

## Estructura de Carpetas (Ejemplo)
```bash
igloolab-test-backend-CSharp
├── Controllers       # Controladores con endpoints (API REST)
├── Data             # Contexto EF Core y configuración de BD
├── Migrations       # Archivos de migración generados por EF Core
├── Models           # Entidades (p. ej. Product.cs)
├── appsettings.json # Configuración de la cadena de conexión
├── Igloolab-test-backend-CSharp.csproj
├── Program.cs       # Punto de entrada de la aplicación
└── README.md
```
## Ejemplo de Uso
1.  **GET** http://localhost:5000/api/product
Devuelve la colección de productos almacenados.

2.  **POST** http://localhost:5000/api/product
Requiere un cuerpo JSON con la estructura:

```bash
{
  "name": "Amoxicilina 500mg",
  "description": "Antibiótico para infecciones bacterianas",
  "price": 14.99
}
```
3.  **DELETE** http://localhost:5000/api/product/{id}
Elimina el producto asociado al identificador proporcionado.
