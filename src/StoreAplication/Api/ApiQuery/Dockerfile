#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/ApiQuery/ApiQuery.csproj", "Api/ApiQuery/"]
COPY ["Application/UseCasesQuery/UseCasesQuery.csproj", "Application/UseCasesQuery/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["Application/UseCasesCommand/UseCasesCommand.csproj", "Application/UseCasesCommand/"]
COPY ["Infrastructure/AdapterSQL/AdapterSQL.csproj", "Infrastructure/AdapterSQL/"]
COPY ["Infrastructure/AdapterSubscribe/AdapterSubscribe.csproj", "Infrastructure/AdapterSubscribe/"]
COPY ["Infrastructure/AdapterWebSocket/AdapterWebSocket.csproj", "Infrastructure/AdapterWebSocket/"]
COPY ["Api/ApiWebSocket/ApiWebSocket.csproj", "Api/ApiWebSocket/"]
RUN dotnet restore "Api/ApiQuery/ApiQuery.csproj"
COPY . .
WORKDIR "/src/Api/ApiQuery"
RUN dotnet build "ApiQuery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiQuery.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiQuery.dll"]