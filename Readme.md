1. Crear el directorio de la aplicación
mddir MyMicro

2. Asignar accesos
chmod -R 755 MyMicro

3. Ingresar a la carpeta y crear la solución
cd MyMicro
dotnet new sln

4. Crear los proyectos
dotnet new classlib -n MyMicro.Domain
dotnet new classlib -n MyMicro.Application
dotnet new classlib -n MyMicro.Infrastructure
dotnet new webapi -n MyMicro.API

5. Adicionar los proyectos a la solucion
dotnet sln add MyMicro.Domain
dotnet sln add MyMicro.Application
dotnet sln add MyMicro.Infrastructure
dotnet sln add MyMicro.API

6. Adicionar referencias
dotnet add MyMicro.Application reference MyMicro.Domain
dotnet add MyMicro.Infrastructure reference MyMicro.Domain
dotnet add MyMicro.Infrastructure reference MyMicro.Application
dotnet add MyMicro.API reference MyMicro.Application
dotnet add MyMicro.API reference MyMicro.Infrastructure

7. Instalar los siguientes paquetes.
dotnet add MyMicro.Infrastructure/MyMicro.Infrastructure.csproj package Microsoft.EntityFrameworkCore.InMemory
dotnet add MyMicro.API/MyMicro..csproj package Microsoft.EntityFrameworkCore.InMemory


8. Colocar el código en cada proyecto y luego ejecutarlo.

dotnet run --project CleanArchitecture.API

9. Compilar la imagen ejecutando
docker build -t mymicro-service .

10. Ejecutar el contenedor
docker run -d -it --rm -p 3001:8080 --name mymicro-service mymicro-service


