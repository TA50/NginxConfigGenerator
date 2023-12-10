# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory.
WORKDIR /app

# Copy csproj and restore as distinct layers.
COPY ./NginxConfigGenerator/NginxConfigGenerator.csproj ./NginxConfigGenerator/NginxConfigGenerator.csproj
COPY ./NginxConfigGenerator.Client/NginxConfigGenerator.Client.csproj ./NginxConfigGenerator.Client/NginxConfigGenerator.Client.csproj
COPY ./NginxConfigGenerator.sln ./
RUN cd ./NginxConfigGenerator && dotnet restore
RUN cd ./NginxConfigGenerator.Client && dotnet restore

# Copy everything else and build.

COPY ./NginxConfigGenerator ./NginxConfigGenerator
COPY ./NginxConfigGenerator.Client ./NginxConfigGenerator.Client
RUN cd ./NginxConfigGenerator && dotnet publish -c Release -o out

# Build runtime image.
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/NginxConfigGenerator/out .

# Make sure the application runs when the container starts.
ENTRYPOINT ["dotnet", "./NginxConfigGenerator.dll"]