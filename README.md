# 🍔 PoliFood API

> API REST para pedidos de comida en campus universitario. Estudiantes, vendors y admin.

![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square)
![EF Core](https://img.shields.io/badge/EF_Core-10-512BD4?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL_Server-2019-CC2927?style=flat-square)
![JWT](https://img.shields.io/badge/Auth-JWT-orange?style=flat-square)

---

## 📋 Descripción

PoliFood es una API REST construida con **ASP.NET Core 10** que permite a estudiantes ordenar comida de vendors del campus, gestionar su carrito, hacer checkout y rastrear el estado de sus órdenes en tiempo real.

**Arquitectura:** `Controller → Interface → Service → DbContext`

---

## 🛠️ Stack

| Tecnología | Uso |
|-----------|-----|
| ASP.NET Core 10 | Framework principal |
| Entity Framework Core 10 | ORM y migraciones |
| SQL Server | Base de datos |
| ASP.NET Identity | Gestión de usuarios y roles |
| JWT Bearer | Autenticación |
| Scalar | Documentación interactiva |

---

## 🚀 Setup

### 1. Instalar herramienta global de EF
```bash
dotnet tool install --global dotnet-ef
```

### 2. Configurar `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=Polifood;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Jwt": {
    "Key": "Tu_Clave_Secreta_Larga",
    "Issuer": "APIPolifood",
    "Audience": "UsuarioDeLaAPi"
  }
}
```

### 3. Migración y base de datos
```bash
dotnet ef migrations add MigracionFinal
dotnet ef database update
```

### 4. Correr el proyecto
```bash
dotnet run
```

📖 Documentación interactiva: `https://localhost:{puerto}/scalar/v1`

---

## 👥 Roles

| Rol | Cómo se crea |
|-----|-------------|
| `Admin` | `POST /api/auth/register` con `Role: "Admin"` |
| `Vendor` | `POST /api/auth/create-vendor` — solo Admin puede crearlo |
| `Student` | `POST /api/auth/register` — valor por defecto si no se envía Role |

---

## 📡 Endpoints

### 🔐 Auth
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| POST | `/api/auth/register` | Público | Registro de usuarios |
| POST | `/api/auth/login` | Público | Login → retorna JWT |
| POST | `/api/auth/create-vendor` | Admin | Crea vendor + tienda simultáneamente |

### 🏪 Tienda
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| GET | `/api/tienda` | Público | Lista todas las tiendas activas |
| GET | `/api/tienda/{id}` | Público | Detalle de una tienda |
| PUT | `/api/tienda/{id}` | Vendor | Actualizar nombre de tienda |
| PATCH | `/api/tienda/{id}/change-status` | Admin | Activar / desactivar tienda |

### 🗂️ Categoría
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| GET | `/api/categoria/{tiendaId}` | Público | Categorías de una tienda |
| GET | `/api/categoria/detalle/{id}` | Público | Detalle de categoría |
| POST | `/api/categoria` | Vendor | Crear categoría |
| PUT | `/api/categoria/{id}` | Vendor | Actualizar categoría |
| PATCH | `/api/categoria/{id}/change-status` | Vendor | Activar / desactivar |

### 🍔 Producto
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| GET | `/api/producto/{tiendaId}` | Público | Productos de una tienda |
| GET | `/api/producto/detalle/{id}` | Público | Detalle de producto |
| POST | `/api/producto` | Vendor | Crear producto |
| PUT | `/api/producto/{id}` | Vendor | Actualizar producto |
| PATCH | `/api/producto/{id}/change-status` | Vendor | Activar / desactivar |

### 🛒 Carrito
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| GET | `/api/carrito/{studentId}` | Student | Ver mi carrito |
| POST | `/api/carrito` | Student | Agregar producto al carrito |
| PATCH | `/api/carrito/{id}` | Student | Actualizar cantidad |
| DELETE | `/api/carrito/{id}` | Student | Eliminar producto del carrito |

### 📦 Orden
| Método | Ruta | Rol | Descripción |
|--------|------|-----|-------------|
| POST | `/api/orden/checkout` | Student | Crear orden desde carrito |
| PATCH | `/api/orden/{id}/confirmar-pago` | Student | Confirmar pago simulado |
| GET | `/api/orden/student` | Student | Mis órdenes activas e historial |
| GET | `/api/orden/tienda/{tiendaId}` | Vendor | Cola de órdenes por fecha |
| PATCH | `/api/orden/{id}/estado` | Vendor | Avanzar estado de orden |
| GET | `/api/orden/eta/{tiendaId}` | Público | ETA estimado de la tienda |

---

## 📊 Estados de Orden

```
Recibida (0) → Preparando (1) → Lista (2) → Entregada (3)
```

> Los estados solo avanzan hacia adelante. No se puede saltar ni retroceder.

---

## ⚙️ Flujo de prueba

```
1. POST /api/auth/register          → crear Admin (Role: "Admin")
2. POST /api/auth/login             → obtener token Admin
3. POST /api/auth/create-vendor     → crear vendor + tienda [token Admin]
4. POST /api/categoria              → crear categoría [token Vendor]
5. POST /api/producto               → crear producto [token Vendor]
6. POST /api/auth/register          → crear Student
7. POST /api/auth/login             → obtener token Student
8. POST /api/carrito                → agregar productos [token Student]
9. POST /api/orden/checkout         → crear orden [token Student]
10. PATCH /api/orden/{id}/confirmar-pago → confirmar pago [token Student]
11. PATCH /api/orden/{id}/estado    → avanzar a Preparando (body: 1) [token Vendor]
12. GET /api/orden/tienda/{id}      → ver cola en vivo [token Vendor]
```

---

## 🔒 Reglas de negocio

- **Total server-side** — el backend calcula el precio, nunca se confía en totales del cliente
- **Sin productos no disponibles** — si `disponible = false`, el checkout rechaza la orden
- **Pago antes de preparar** — el vendor no puede avanzar a `Preparando` sin pago confirmado
- **Estados lineales** — `Recibida → Preparando → Lista → Entregada`, sin saltos ni retrocesos
- **1 vendor = 1 tienda** — la tienda se crea automáticamente al crear el vendor
- **ETA automático** — calculado con `minutos_preparacion` de los productos en cola activa

---

## 📁 Estructura del proyecto

```
PoliFood/
├── Controllers/
│   ├── AuthController.cs
│   ├── TiendaController.cs
│   ├── CategoriaController.cs
│   ├── ProductoController.cs
│   ├── CarritoController.cs
│   └── OrdenController.cs
├── DAO/
│   └── ApplicationDbContext.cs
├── Interfaces/
│   ├── IAuthService.cs
│   ├── ITiendaService.cs
│   ├── ICategoriaService.cs
│   ├── IProductoService.cs
│   ├── ICarritoService.cs
│   └── IOrdenService.cs
├── Models/
│   ├── Tienda.cs
│   ├── Categoria.cs
│   ├── Producto.cs
│   ├── Orden.cs
│   ├── OrdenItem.cs
│   ├── CarritoItem.cs
│   └── DTOs/
│       ├── LoginDTO.cs
│       ├── RegisterDTO.cs
│       ├── CreateVendorDTO.cs
│       └── CheckoutDTO.cs
├── Services/
│   ├── AuthService.cs
│   ├── TiendaService.cs
│   ├── CategoriaService.cs
│   ├── ProductoService.cs
│   ├── CarritoService.cs
│   └── OrdenService.cs
├── appsettings.json
└── Program.cs
```
# Miembros:
-Samuel Giraldo Jimenez
-Jeronimo Tavera Ramirez
