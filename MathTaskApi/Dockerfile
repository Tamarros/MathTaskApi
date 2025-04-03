# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . ./

# Create a local NuGet source folder
RUN mkdir -p /root/.nuget/local
COPY Extensions/IO.Models.1.0.0.nupkg /root/.nuget/local/

# Create NuGet.Config with local source included
RUN echo '<?xml version="1.0" encoding="utf-8"?>\
<configuration>\
  <packageSources>\
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />\
    <add key="local" value="/root/.nuget/local" />\
  </packageSources>\
</configuration>' > NuGet.Config

# Restore dependencies using the custom NuGet config
RUN dotnet restore MathTaskApi.csproj --configfile NuGet.Config

# Publish the application
RUN dotnet publish MathTaskApi.csproj -c Release -o /app/publish

# Stage 2: Create the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose default port
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "MathTaskApi.dll"]
