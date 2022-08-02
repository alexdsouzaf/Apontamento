#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ConProAPI/ConProAPI.csproj", "ConProAPI/"]
COPY ["Apontamento.CamadaRepositorio/ControladorProjetos.CamadaRepositorio.csproj", "Apontamento.CamadaRepositorio/"]
COPY ["Apontamento.CamadaModelo/ControladorProjetos.CamadaModelo.csproj", "Apontamento.CamadaModelo/"]
COPY ["Apontamento.CamadaNegocio/ControladorProjetos.CamadaNegocio.csproj", "Apontamento.CamadaNegocio/"]
RUN dotnet restore "ConProAPI/ConProAPI.csproj"
COPY . .
WORKDIR "/src/ConProAPI"
RUN dotnet build "ConProAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConProAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS.