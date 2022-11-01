# E-commerce project based on a microservices architecture

# Development and deployment
## Application settings and environmental variables
### Catalog API
- ASPNETCORE_ENVIRONMENT=[Development|Production]

- ConnectionStrings__CatalogContext

- BusOptions__Host
- BusOptions__Username
- BusOptions__Password
- BusOptions__LicensePath

## Useful commands
- `dotnet ef migrations add Initial --output-dir ./Migrations`
- `dotnet ef database update`

- `docker build --build-arg NET_VERSION=6.0 --build-arg CONFIGURATION=release -f Dockerfile ../../../`

- `kubectl apply -f ./k8s --recursive`
- `kubectl apply -f ./k8s/configmap/catalog-api.dev.yaml -f ./k8s/deployment --recursive`

## Architecture

## Tech stack
- .NET 6
- ASP.NET Core
- Docker
- Kubernetes
- Helm Charts

## References
- [.NET Microservices: Architecture for Containerized .NET Applications](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/)
- [.NET Microservices Sample Reference Application](https://github.com/dotnet-architecture/eShopOnContainers)
