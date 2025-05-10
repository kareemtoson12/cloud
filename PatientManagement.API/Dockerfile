FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PatientManagement.API/PatientManagement.API.csproj", "PatientManagement.API/"]
COPY ["HealthcareManagement.Shared/HealthcareManagement.Shared.csproj", "HealthcareManagement.Shared/"]
RUN dotnet restore "PatientManagement.API/PatientManagement.API.csproj"
COPY . .
WORKDIR "/src/PatientManagement.API"
RUN dotnet build "PatientManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientManagement.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientManagement.API.dll"] 