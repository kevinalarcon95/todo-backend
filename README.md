# ✅ Todo App Backend - .NET Core API

Este proyecto es una API RESTful desarrollada con **ASP.NET Core 8** que gestiona tareas (To-Do List) conectándose a una base de datos SQL en **Azure**. La aplicación permite crear, leer, actualizar y eliminar tareas.

## 🚀 Características principales
- API REST para CRUD de tareas
- Conexión a **Azure SQL Database** (configurable mediante variables de entorno).
- Despliegue en **Azure App Service**
- CORS habilitado para integración con frontend
- Soporte para Entity Framework Core
- Log de consultas y debugging

## 📂 Estructura del proyecto

- **Controllers/**  
  Contiene los controladores del API (por ejemplo, `TaskApiController.cs`).

- **Models/**  
  Define las clases del dominio, como la entidad `Task`.

- **Data/**  
  Incluye el `DbContext` (por ejemplo, `TaskContext.cs`), que configura la conexión y mapeo a la base de datos.

- **Migrations/**  
  Carpeta generada por EF Core para el versionado del esquema de la base de datos.

- **appsettings.json / appsettings.Development.json**  
  Archivos de configuración para las cadenas de conexión y otros parámetros.

## 📥 Endpoints principales
| Método | Endpoint               | Descripción                         |
|------- |------------------------|-------------------------------------|
| GET    | /api/TaskApi           | Obtener todas las tareas            |
| GET    | /api/TaskApi/{id}      | Obtener una tarea por ID            |
| POST   | /api/TaskApi           | Crear una nueva tarea               |
| PUT    | /api/TaskApi/{id}      | Actualizar una tarea existente      |
| DELETE | /api/TaskApi/{id}      | Eliminar una tarea                  |

## 🔧 Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de contar con:
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Git]([https://git-scm.com/downloads](https://github.com/kevinalarcon95/todo-backend.git)
- Una instancia de **SQL Server** (local o en Azure)
- Opcional: [SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms) para administrar la base de datos

---

## ⚙ Configuración de la base de datos
La API utiliza una base de datos SQL configurada a través de variables de entorno en **Azure App Service**:

### Ejemplo de cadena de conexión:
```markdown
Server=tcp:<server>.database.windows.net,1433; Initial Catalog=<database>; Persist Security Info=False; User ID=<user>; Password=<password>; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;
```

En Azure debe configurarse como:
Nombre: DefaultConnection Valor: (cadena completa de conexión) en la sección de variables de entorno


## 🖥 Cómo ejecutar en local
1. Clonar el proyecto [Git]([https://git-scm.com/downloads](https://github.com/kevinalarcon95/todo-backend.git)
```markdown
   git clone <repositorio>
```
```markdown
   cd <carpeta-del-proyecto>
```
2.  Restaurar Dependencias y Compilar
```markdown
   dotnet restore
```
```markdown
   dotnet build
```
3. Configurar la Cadena de Conexión Local
   Modifica el archivo appsettings.Development.json para configurar la cadena de conexión. Por ejemplo, para SQL Server Express:

```csharp
	{
		"ConnectionStrings": {
		"DefaultConnection":"Server=localhost\\SQLEXPRESS;Database=TaskDB;Trusted_Connection=True;"
		}
	}
```
   O, si prefieres SQLite para pruebas rápidas:
```csharp
{
    "ConnectionStrings": {
      "DefaultConnection": "Data Source=TaskDB.sqlite"
    }
}
```

4. Generar y Aplicar Migraciones
 ```markdown
  dotnet ef migrations add Inicial
```
```markdown
   dotnet ef database update
```
7. Ejecutar la Aplicación
```markdown
   dotnet run
```

8. Acceder a:
   https://localhost:5001/api/TaskApi


## ☁ Despliegue en Azure
- Se realiza mediante la extensión **Azure App Service** en Visual Studio Code o desde CLI.
- Requiere una variable de entorno **DefaultConnection** configurada en el portal de Azure.

## 📄 Tecnologías utilizadas
- ASP.NET Core 8
- Entity Framework Core
- SQL Server Azure
- Azure App Service
- CORS

## ✍ Autor
Desarrollado por **Kevin Alarcón**

---
