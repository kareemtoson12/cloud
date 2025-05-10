FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EHR.API/EHR.API.csproj", "EHR.API/"]
COPY ["HealthcareManagement.Shared/HealthcareManagement.Shared.csproj", "HealthcareManagement.Shared/"]
RUN dotnet restore "EHR.API/EHR.API.csproj"
COPY . .
WORKDIR "/src/EHR.API"
RUN dotnet build "EHR.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EHR.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EHR.API.dll"] 