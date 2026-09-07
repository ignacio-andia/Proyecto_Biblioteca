# Sistema de Gestión de Biblioteca

Aplicación de consola desarrollada en C# con .NET 10 para gestionar libros, usuarios y préstamos de una biblioteca.

## Funcionalidades

- Registrar libros.
- Registrar usuarios.
- Registrar préstamos.
- Registrar devoluciones.
- Buscar libros por código.
- Eliminar libros.
- Mostrar libros registrados.
- Mostrar libros disponibles y no disponibles.
- Buscar libros por autor o categoría.
- Ordenar libros por título.
- Mostrar usuarios registrados.
- Consultar préstamos activos, devueltos y registrados.
- Mostrar los datos principales de los préstamos activos.
- Validar datos y controlar errores sin cerrar la aplicación.

## Tecnologías utilizadas

- C#
- .NET 10
- LINQ
- Git
- GitHub

## Estructura principal

- `Libro.cs` — Representa los libros y controla su disponibilidad.
- `Usuario.cs` — Representa a los usuarios de la biblioteca.
- `Prestamo.cs` — Representa los registros de préstamos.
- `BibliotecaService.cs` — Gestiona libros, usuarios y préstamos.
- `IPrestable.cs` — Define las operaciones de préstamo y devolución.
- `Program.cs` — Contiene el menú y la interacción con el usuario.

## Requisitos

- .NET 10 SDK
- Visual Studio 2022 o superior

## Ejecución

1. Clonar el repositorio.
2. Abrir la solución `ProyectoBiblioteca.sln` en Visual Studio.
3. Compilar el proyecto.
4. Ejecutar la aplicación.

## Autor

Proyecto académico desarrollado para la gestión de una biblioteca.