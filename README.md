Necesitás tener instalado en la PC:

&#x09;Git → para el clone

&#x09;.NET SDK (versión 10) → para compilar y ejecutar

&#x09;dotnet-ef → solo si querés correr comandos de migración manualmente



Luego de clonar el repositorio



Paso 1 — Entrar a la carpeta del proyecto:

cd TUP.MateriasMVC



Paso 2 — Restaurar los paquetes NuGet:

dotnet restore



Paso 3 — Crear la base de datos (esto aplica la migración y carga los datos automáticamente):
quisa de deba instalar antes: dotnet tool install --global dotnet-ef

dotnet ef database update



Paso 4 — Ejecutar la aplicación:

dotnet run



En realidad el Paso 3 es opcional porque en el Program.cs tenemos esta línea:

db.Database.Migrate();

Que crea y migra la base de datos automáticamente al arrancar. Así que técnicamente con solo hacer dotnet run ya funciona todo.

