#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreApiQuery/StoreApiQuery.csproj", "StoreApiQuery/"]
COPY ["AdapteRabbitConsumer/AdapteRabbitConsumer.csproj", "AdapteRabbitConsumer/"]
COPY ["UseCasesQuery/UseCasesQuery.csproj", "UseCasesQuery/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["UseCases/UseCases.csproj", "UseCases/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "StoreApiQuery/StoreApiQuery.csproj"
COPY . .
WORKDIR "/src/StoreApiQuery"
RUN dotnet build "StoreApiQuery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreApiQuery.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreApiQuery.dll"]