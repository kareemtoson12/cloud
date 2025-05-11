# Healthcare Management System

## Environment Setup

### Development Environment
```bash
# Copy development environment variables
cp .env.dev .env

# Start the development environment
docker-compose -f docker-compose.yml -f docker-compose.dev.yml up -d
```

### Staging Environment
```bash
# Copy staging environment variables
cp .env.staging .env

# Start the staging environment
docker-compose -f docker-compose.yml -f docker-compose.staging.yml up -d
```

### Production Environment
```bash
# Copy production environment variables
cp .env.prod .env

# Start the production environment
docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d
```

## Environment-Specific Features

### Development
- Hot-reloading enabled
- Debug ports exposed
- Local volume mounts for development
- Default credentials for easy setup

### Staging
- 2 replicas per service
- Resource limits configured
- Environment variables from .env.staging
- Suitable for testing and QA

### Production
- 3 replicas per service
- Strict resource limits
- Restart policies configured
- Environment variables from .env.prod
- High availability configuration

## Environment Variables

Each environment has its own .env file:
- `.env.dev` - Development environment variables
- `.env.staging` - Staging environment variables
- `.env.prod` - Production environment variables

**Note:** Never commit sensitive information in .env files. Use CI/CD pipeline secrets for production credentials.

## Health Checks

All services include health checks that run every 30 seconds:
```yaml
healthcheck:
  test: ["CMD", "curl", "-f", "http://localhost:80/health"]
  interval: 30s
  timeout: 10s
  retries: 3
```

## Resource Management

### Development
- No resource limits
- Local volume mounts
- Debug ports exposed

### Staging
- API Services: 0.5 CPU, 512MB RAM
- Databases: 1 CPU, 2GB RAM

### Production
- API Services: 1 CPU, 1GB RAM
- Databases: 2 CPU, 4GB RAM
- Restart policies configured
- High availability settings 