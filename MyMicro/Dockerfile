FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /APP
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MyMicro.Application/MyMicro.Application.csproj", "./MyMicro.Application/"] 
COPY ["MyMicro.Domain/MyMicro.Domain.csproj", "./MyMicro.Domain/"] 
COPY ["MyMicro.Infrastructure/MyMicro.Infrastructure.csproj", "./MyMicro.Infrastructure/"] 
COPY ["MyMicro.API/MyMicro.API.csproj", "./MyMicro.API/"] 
RUN dotnet restore "MyMicro.Application/MyMicro.Application.csproj"
RUN dotnet restore "MyMicro.Domain/MyMicro.Domain.csproj"
RUN dotnet restore "MyMicro.Infrastructure/MyMicro.Infrastructure.csproj"
RUN dotnet restore "MyMicro.API/MyMicro.API.csproj"
COPY . .
RUN dotnet build "./MyMicro.API/MyMicro.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./MyMicro.API/MyMicro.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "MyMicro.API.dll" ]