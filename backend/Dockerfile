# Use the .NET SDK for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
 
# Copy the project file and restore dependencies
COPY ./test_projekt/test_projekt/*.csproj ./
RUN dotnet restore
 
# Copy everything else and build the app
COPY ./test_projekt/test_projekt/ ./
RUN dotnet publish -c Release -o out
 
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "test_projekt.dll","--urls","http://*:8080"]
