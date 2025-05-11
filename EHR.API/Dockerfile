# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

# Copy and restore project files
COPY ["EHR.API/EHR.API.csproj", "EHR.API/"]
COPY ["HealthcareManagement.Shared/HealthcareManagement.Shared.csproj", "HealthcareManagement.Shared/"]
RUN dotnet restore "EHR.API/EHR.API.csproj"

# Copy and build source code
COPY . .
WORKDIR "/src/EHR.API"
RUN dotnet build "EHR.API.csproj" -c Release -o /app/build && \
    dotnet publish "EHR.API.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS final
WORKDIR /app

# Install required runtime dependencies and clean up
RUN apk add --no-cache icu-libs && \
    rm -rf /var/cache/apk/* && \
    rm -rf /tmp/*

# Copy published files
COPY --from=build /app/publish .

# Set environment variables
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80
ENTRYPOINT ["dotnet", "EHR.API.dll"] 