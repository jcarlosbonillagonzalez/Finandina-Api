# Finandina API - Guía Rápida

### 1. Configuración de Base de Datos
Modifica el archivo `src/Finandina-Api/appsettings.json`. En la sección `DefaultConnection`, cambia:
*   **Server**: Dirección del servidor.
*   **Password**: Tu contraseña.

### 2. Ejecutar Migración (Crear tablas)
Desde la carpeta raíz, ejecuta:
```bash
dotnet ef database update --project src/Finandina-Persistence --startup-project src/Finandina-Api
```

### 3. Ejecutar Proyecto
Desde la carpeta raíz, ejecuta:
```bash
dotnet run --project src/Finandina-Api
```

### 4. Descripción
La solucion al iniciar va a contar con dos servicios que son los que se consumen desde el api solicitada y posterior a esto el servicio de busqueda por Id realiza un registro a tipo "Auditoria" para el segundo punto que se pidio de realizar el registros de las regionales en la base de datos local. quedo como especie de auditoria, siempre que se consuma ese servicio y se busque por el id se va a realizar el registro en la tabla AuditoriaConsultaRegion.
