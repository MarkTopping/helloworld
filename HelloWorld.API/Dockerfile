#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-jammy AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HelloWorld.API/HelloWorld.API.csproj", "HelloWorld.API/"]
RUN dotnet restore "HelloWorld.API/HelloWorld.API.csproj"

COPY . .
WORKDIR "/src/HelloWorld.API"
RUN dotnet build "HelloWorld.API.csproj" -c Release -o /app/build

# tests
#RUN dotnet tool install dotnet-reportgenerator-globaltool

#COPY HelloWorld.UnitTests/ HelloWorld.UnitTests/
#RUN dotnet restore
#RUN dotnet test --no-restore --no-build

FROM build AS publish
RUN dotnet publish "HelloWorld.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

RUN groupadd --system --gid 2001 appgroup && adduser -u 1001 --gid 2001 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

RUN 

ENTRYPOINT ["dotnet", "HelloWorld.API.dll"]