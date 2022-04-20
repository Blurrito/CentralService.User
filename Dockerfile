#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update
RUN apt-get install -y openvpn openconnect 

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CentralService.Api.User.Presentation/CentralService.Api.User.Presentation.csproj", "CentralService.Api.User.Presentation/"]
RUN dotnet restore "CentralService.Api.User.Presentation/CentralService.Api.User.Presentation.csproj"
COPY . .
WORKDIR "/src/CentralService.Api.User.Presentation"
RUN dotnet build "CentralService.Api.User.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CentralService.Api.User.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["tail", "-f", "/dev/null"]
ENTRYPOINT ["dotnet", "CentralService.Api.User.Presentation.dll"]
