#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["League-Management-Application/League-Management-Application.csproj", "League-Management-Application/"]
RUN dotnet restore "League-Management-Application/League-Management-Application.csproj"
COPY . .
WORKDIR "/src/League-Management-Application"
RUN dotnet build "League-Management-Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "League-Management-Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "League-Management-Application.dll"]