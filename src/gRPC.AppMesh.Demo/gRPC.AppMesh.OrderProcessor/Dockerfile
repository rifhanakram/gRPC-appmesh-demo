#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["gRPC.AppMesh.OrderProcessor/gRPC.AppMesh.OrderProcessor.csproj", "gRPC.AppMesh.OrderProcessor/"]
RUN dotnet restore "gRPC.AppMesh.OrderProcessor/gRPC.AppMesh.OrderProcessor.csproj"
COPY . .
WORKDIR "/src/gRPC.AppMesh.OrderProcessor"
RUN dotnet build "gRPC.AppMesh.OrderProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gRPC.AppMesh.OrderProcessor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gRPC.AppMesh.OrderProcessor.dll"]