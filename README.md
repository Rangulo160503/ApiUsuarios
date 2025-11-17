# README – Práctica Programada 3  
Curso: Programación Avanzada  
Profesor: Arce Vargas Richard  
Periodo: III Cuatrimestre, 2025  

---

## Integrantes del grupo
| Nombre completo | Rol |
|------------------------------|-----------------------------------------------|
| **Ronald Joel Angulo Hernández** | Lógica de negocio y base de datos |
| **Marvin Gustavo Marín Lazo** | Diseño de interfaz y vistas Razor |
| **Sonia Sofía Umaña Piñar** | Controladores, validaciones y testing |
| **Argenis David Cerrato Amador** | Modelado de entidades y reportes |

---

## Enlace del repositorio
(Opcional, si corresponde)  
Ejemplo:  
https://github.com/RonaldAngulo/PP3-PrograAvanzada

---

## Descripción general del proyecto

Esta práctica consiste en la construcción de una API REST utilizando ASP.NET Core Web API bajo una arquitectura por capas.  
El objetivo principal es implementar el CRUD completo para las entidades **Usuarios** y **Vehículos**, incluyendo:

- Capa de presentación (API)  
- Capa de lógica de negocio (servicios)  
- Capa de acceso a datos (repositorios)  
- Entidades y DTOs  
- Mapeo con AutoMapper  
- Persistencia mediante base de datos SQLite embebida en el proyecto

La API expone endpoints que permiten listar, consultar, registrar, modificar y eliminar información de ambas entidades.

---

## Arquitectura del proyecto

La solución implementa una estructura por capas dividida en **tres proyectos** dentro de la solución:

### 1. ApiUsuarios (Capa de Presentación / API)
Incluye:
- Controladores `UsuariosController` y `VehiculosController`
- Configuración de servicios, Swagger y rutas
- Archivo `Program.cs` con la inyección de dependencias

### 2. ApiUsuarios.BLL (Capa de Lógica de Negocio)
Incluye:
- Interfaces de servicios (`IUsuariosServicio`, `IVehiculosServicio`)
- Implementaciones (`UsuarioServicio`, `VehiculosServicio`)
- DTOs (`UsuarioDto`, `VehiculoDto`)
- Configuración de AutoMapper (`MapeoClases`)

### 3. ApiUsuarios.DLL (Capa de Acceso a Datos)
Incluye:
- Entidades (`Usuario`, `Vehiculo`)
- Repositorios (`IUsuariosRepositorio`, `IVehiculosRepositorio`)
- Implementaciones (`UsuariosRepositorio`, `VehiculosRepositorio`)
- Contexto de EF Core (`ApiContext`)
- Base de datos SQLite (`API.db`)

---

## Paquetes NuGet utilizados

| Paquete | Descripción |
|------------------------------|-------------------------------|
| Microsoft.EntityFrameworkCore | ORM para acceso a datos |
| Microsoft.EntityFrameworkCore.Sqlite | Proveedor SQLite |
| Microsoft.EntityFrameworkCore.Design | Soporte adicional para EF Core |
| Swashbuckle.AspNetCore | Documentación Swagger |
| AutoMapper | Mapeo de objetos |
| AutoMapper.Extensions.Microsoft.DependencyInjection | Integración de AutoMapper |

---

## Principios SOLID y patrones aplicados

| Principio / Patrón | Implementación |
|--------------------|----------------|
| Single Responsibility | Cada clase cumple una única responsabilidad. |
| Interface Segregation | Interfaces pequeñas y específicas (`IUsuariosRepositorio`, `IVehiculosRepositorio`). |
| Dependency Inversion | Controladores y servicios dependen de interfaces inyectadas mediante DI. |
| DTO Pattern | Separación entre entidades de BD y datos expuestos por la API. |
| Repository Pattern | Abstracción del acceso a datos en la capa DLL. |
| Layered Architecture | Separación clara entre API, BLL y DLL. |

---

## Funcionalidades principales

### Usuarios
- `GET /Usuarios`
- `GET /Usuarios/{id}`
- `POST /Usuarios`
- `PUT /Usuarios`
- `DELETE /Usuarios/{id}`

### Vehículos
- `GET /Vehiculos`
- `GET /Vehiculos/{id}`
- `POST /Vehiculos`
- `PUT /Vehiculos`
- `DELETE /Vehiculos/{id}`

Todas las respuestas siguen el patrón `CustomResponse<T>` utilizado en clase.

---

## Base de datos SQLite embebida

Archivo utilizado:
