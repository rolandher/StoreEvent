#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreAplication/StoreAplication.csproj", "StoreAplication/"]
COPY ["AdapterRabbitProducer/AdapterRabbitProducer.csproj", "AdapterRabbitProducer/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["Adapter/Adapter.csproj", "Adapter/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "StoreAplication/StoreAplication.csproj"
COPY . .
WORKDIR "/src/StoreAplication"
RUN dotnet build "StoreAplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreAplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreAplication.dll"]