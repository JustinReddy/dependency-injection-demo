# dependency-injection-demo
 Demo on Microsoft Dependency Injection Container

 ## General info
This is a .NET Core 3.1 MVC Website that demonstrates the different mechanisms used to to Inject Services in a .Net Core Application, ie. Constructor Injection vs Activator Injection.
Can also be used as a Bootstrap application to create new MVC applications in .Net Core 3.1.

## Running this application
### Prerequisites
- Docker
- Git
- .NET Core 3.1

### Steps to Run
1. Download this git repository (https://github.com/JustinReddy/dependency-injection-demo) to your local development PC.
2. In the root folder of the repository execute this command:
```_docker-compose up --build_```
3. This will build and startup the .NET Core 3.1 MVC website and will expose itself on port 5000.
4. Browse the website on http://localhost:5000
5. To tear down the docker instance execute this command:
```_docker-compose down_```

