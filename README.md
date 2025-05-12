# Healthcare Management System

A comprehensive healthcare management system built with .NET 8 microservices architecture, providing patient management, EHR (Electronic Health Records), and appointment scheduling capabilities.

## 🏗️ Project Structure

The system consists of three main microservices:

- **Patient Management API** (Port: 5001)
  - Handles patient registration and management
  - Manages patient demographics and medical history
  - Provides patient search and filtering capabilities

- **EHR API** (Port: 5002)
  - Manages electronic health records
  - Handles medical documentation
  - Provides secure access to patient medical data

- **Appointment Scheduling API** (Port: 5003)
  - Manages appointment bookings
  - Handles scheduling conflicts
  - Provides calendar integration

## 🛠️ Technologies Used

- **Backend**: .NET 8
- **Database**: SQL Server 2019
- **Containerization**: Docker & Docker Compose
- **API Documentation**: Swagger/OpenAPI
- **Environment Management**: Multiple environment configurations (Dev/Staging/Prod)

## 🚀 Getting Started

### Prerequisites

- Docker Desktop
- .NET 8 SDK
- SQL Server (if running locally)

### Quick Start

1. Clone the repository:
```bash
git clone https://github.com/kareemtoson12/cloud.git
cd cloud
```

2. Choose your environment and start the services:

#### Development Environment
```bash
# Copy development environment variables
cp .env.dev .env

# Start the development environment
docker-compose -f docker-compose.yml -f docker-compose.dev.yml up -d
```

#### Staging Environment
```bash
# Copy staging environment variables
cp .env.staging .env

# Start the staging environment
docker-compose -f docker-compose.yml -f docker-compose.staging.yml up -d
```

#### Production Environment
```bash
# Copy production environment variables
cp .env.prod .env

# Start the production environment
docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d
```

## 🔧 Environment-Specific Features

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

## ⚙️ Configuration

### Environment Variables

Each environment has its own .env file:
- `.env.dev` - Development environment variables
- `.env.staging` - Staging environment variables
- `.env.prod` - Production environment variables

**Note:** Never commit sensitive information in .env files. Use CI/CD pipeline secrets for production credentials.

### Database Configuration

Each service has its own SQL Server instance:
- Patient Management DB: Port 1433
- EHR DB: Port 1434
- Appointment DB: Port 1435

## 🏥 API Endpoints

Each service exposes its API on different ports:
- Patient Management API: http://localhost:5001
- EHR API: http://localhost:5002
- Appointment Scheduling API: http://localhost:5003

## 🔍 Health Checks

All services include health checks that run every 30 seconds:
```yaml
healthcheck:
  test: ["CMD", "curl", "-f", "http://localhost:80/health"]
  interval: 30s
  timeout: 10s
  retries: 3
```

## 💻 Resource Management

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

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 👥 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request 