# PoliFood API

API REST para pedidos de comida en campus universitario.
Basada en la arquitectura de ApiConciertos.

---

## Stack
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core + SQL Server
- ASP.NET Identity + JWT
- Scalar (documentación)

---

## Setup

### 1. Instalar herramienta global de EF
dotnet tool install --global dotnet-ef

### 2. Configurar appsettings.json
{
  "Jwt": {
    "Key": "Tu_Clave_Secreta",
    "Issuer": "APIPolifood",
    "Audience": "UsuarioDeLaAPi"
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=Polifood;Trusted_Connection=True;TrustServerCertificate=True"
  }
}

### 3. Migración y base de datos
dotnet ef migrations add MigracionFinal
dotnet ef database update

### 4. Correr el proyecto
dotnet run
Documentación: https://localhost:{puerto}/scalar/v1

---

## Usuarios y Roles

| Rol     | Cómo se crea                              |
|---------|-------------------------------------------|
| Admin   | POST /api/auth/register con Role: "Admin" |
| Vendor  | POST /api/auth/create-vendor (solo Admin) |
| Student | POST /api/auth/register con Role: "Student"|

---

## Endpoints

### Auth
| Método | Ruta                      | Rol     | Descripción              |
|--------|---------------------------|---------|--------------------------|
| POST   | /api/auth/register        | Público | Registro de usuarios     |
| POST   | /api/auth/login           | Público | Login → retorna JWT      |
| POST   | /api/auth/create-vendor   | Admin   | Crea vendor + tienda     |

### Tienda
| Método | Ruta                          | Rol          | Descripción           |
|--------|-------------------------------|--------------|-----------------------|
| GET    | /api/tienda                   | Público      | Lista tiendas activas |
| GET    | /api/tienda/{id}              | Público      | Detalle de tienda     |
| PUT    | /api/tienda/{id}              | Vendor       | Actualizar tienda     |
| PATCH  | /api/tienda/{id}/change-status| Admin        | Activar/desactivar    |

### Categoria
| Método | Ruta                                  | Rol    | Descripción              |
|--------|---------------------------------------|--------|--------------------------|
| GET    | /api/categoria/{tiendaId}             | Público| Categorías de una tienda |
| GET    | /api/categoria/detalle/{id}           | Público| Detalle de categoría     |
| POST   | /api/categoria                        | Vendor | Crear categoría          |
| PUT    | /api/categoria/{id}                   | Vendor | Actualizar categoría     |
| PATCH  | /api/categoria/{id}/change-status     | Vendor | Activar/desactivar       |

### Producto
| Método | Ruta                                  | Rol    | Descripción              |
|--------|---------------------------------------|--------|--------------------------|
| GET    | /api/producto/{tiendaId}              | Público| Productos de una tienda  |
| GET    | /api/producto/detalle/{id}            | Público| Detalle de producto      |
| POST   | /api/producto                         | Vendor | Crear producto           |
| PUT    | /api/producto/{id}                    | Vendor | Actualizar producto      |
| PATCH  | /api/producto/{id}/change-status      | Vendor | Activar/desactivar       |

### Carrito
| Método | Ruta                      | Rol     | Descripción              |
|--------|---------------------------|---------|--------------------------|
| GET    | /api/carrito/{studentId}  | Student | Ver carrito              |
| POST   | /api/carrito              | Student | Agregar producto         |
| PATCH  | /api/carrito/{id}         | Student | Actualizar cantidad      |
| DELETE | /api/carrito/{id}         | Student | Eliminar producto        |

### Orden
| Método | Ruta                              | Rol     | Descripción              |
|--------|-----------------------------------|---------|--------------------------|
| POST   | /api/orden/checkout               | Student | Crear orden desde carrito|
| PATCH  | /api/orden/{id}/confirmar-pago    | Student | Confirmar pago simulado  |
| GET    | /api/orden/student                | Student | Mis órdenes              |
| GET    | /api/orden/tienda/{tiendaId}      | Vendor  | Cola de órdenes          |
| PATCH  | /api/orden/{id}/estado            | Vendor  | Actualizar estado        |
| GET    | /api/orden/eta/{tiendaId}         | Público | ETA de la tienda         |

---

## Estados de Orden
Recibida (0) → Preparando (1) → Lista (2) → Entregada (3)

## Reglas de negocio
- Totales calculados server-side
- No se pueden pedir productos no disponibles
- El pago debe confirmarse antes de preparar
- Los estados solo avanzan en orden, no retroceden
- Solo Admin puede crear vendors
- Un vendor está ligado a exactamente una tienda
