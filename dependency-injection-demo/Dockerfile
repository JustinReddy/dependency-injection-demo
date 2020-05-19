#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["dependency-injection-demo/dependency-injection-demo.csproj", "dependency-injection-demo/"]
RUN dotnet restore "dependency-injection-demo/dependency-injection-demo.csproj"
COPY . .
WORKDIR "/src/dependency-injection-demo"
RUN dotnet build "dependency-injection-demo.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS tests
WORKDIR /src
COPY ["dependency-injection-demo.tests/dependency-injection-demo.tests.csproj", "dependency-injection-demo.tests/"]
COPY ["dependency-injection-demo/dependency-injection-demo.csproj", "dependency-injection-demo/"]
RUN dotnet restore "dependency-injection-demo.tests/dependency-injection-demo.tests.csproj"
COPY . .
WORKDIR "/src/dependency-injection-demo.tests"
RUN dotnet build "dependency-injection-demo.tests.csproj" -c Release -o /app/tests
RUN dotnet test "dependency-injection-demo.tests.csproj" -c --verbose --logger "console;verbosity=detailed" -o /app/tests

WORKDIR /src
FROM build AS publish
RUN dotnet publish "dependency-injection-demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dependency-injection-demo.dll"]