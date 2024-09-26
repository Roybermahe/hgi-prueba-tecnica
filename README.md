
# HGI Prueba Técnica

Este repositorio contiene una aplicación web compuesta por un backend en ASP.NET Core y un frontend en Angular. La solución utiliza una arquitectura basada en capas, que se explica a continuación.

## Estructura del Proyecto

- **api**: Contiene el proyecto ASP.NET Core Web API. Este proyecto tiene referencias a las siguientes bibliotecas de clase:
  - **Capa Aplicación**: [aplicacion](https://github.com/Roybermahe/hgi-prueba-tecnica/tree/master/aplicacion).
  - **Capa Dominio**: [dominio](https://github.com/Roybermahe/hgi-prueba-tecnica/tree/master/dominio).
  - **Capa Infraestructura**: [infraestructura](https://github.com/Roybermahe/hgi-prueba-tecnica/tree/master/infraestructura).

- **webapp**: Contiene el proyecto Angular.

## Requisitos Previos

- [Docker](https://www.docker.com/) instalado en el sistema.
- [.NET Core SDK](https://dotnet.microsoft.com/download) (opcional, solo si deseas ejecutar el backend localmente).
- [Node.js](https://nodejs.org/) instalado (para el proyecto Angular).

## Ejecución del Proyecto con Docker

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/Roybermahe/hgi-prueba-tecnica.git
   cd hgi-prueba-tecnica/api
   ```

2. Levantar el contenedor de la base de datos PostgreSQL usando el `docker-compose` ubicado en la carpeta `api`:

   El archivo `docker-compose.yml` contiene lo siguiente:

   ```yaml
   version: "3.8"

   services:
     postgres:
       image: postgres
       restart: always
       environment:
         POSTGRES_ROOT_PASSWORD: pruebatecnicahgi
         POSTGRES_USER: pruebatecnicahgi
         POSTGRES_PASSWORD: pruebatecnicahgi
         POSTGRES_DATABASE: pruebatecnicahgi
         TZ: America/Bogota
       ports:
         - 5432:5432
       volumes:
         - ./docker/postgres/volumes:/var/lib/postgres
   ```

3. Ejecutar `docker-compose`:

   ```bash
   docker-compose up --build
   ```

   Esto solo creará y ejecutará el contenedor para la base de datos PostgreSQL. **La API se debe ejecutar manualmente**.

## Ejecución de Migraciones en la Capa de Infraestructura

Es necesario ejecutar las migraciones para configurar las bases de datos correctamente. La capa de infraestructura contiene un script de migraciones ubicado en su `package.json`.

1. Dirígete a la carpeta `infraestructura`:

   ```bash
   cd ../infraestructura
   ```

2. Ejecutar las migraciones usando el siguiente comando:

   ```bash
   npm run migration
   ```

   Esto generará las tablas y la estructura de base de datos requerida por la aplicación.

## Ejecución del Backend (ASP.NET Core)

1. Navegar a la carpeta `api`:

   ```bash
   cd ../api
   ```

2. Restaurar dependencias y ejecutar el proyecto:

   ```bash
   dotnet restore
   dotnet run
   ```

3. La API estará disponible en `http://localhost:5043`.

## Ejecución del Frontend (Angular)

1. Navegar a la carpeta `webapp`:

   ```bash
   cd ../webapp
   ```

2. Instalar dependencias:

   ```bash
   npm install
   ```

3. Ejecutar la aplicación:

   ```bash
   ng serve
   ```

4. La aplicación estará disponible en `http://localhost:4200`.

## Notas

- Si usas Docker, no es necesario ejecutar manualmente la base de datos, pero sí la API y el frontend por separado.
- Asegúrate de tener los puertos necesarios (5043 para la API y 4200 para Angular) libres antes de iniciar.
