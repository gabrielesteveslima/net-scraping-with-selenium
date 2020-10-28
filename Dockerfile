FROM mcr.microsoft.com/dotnet/core/sdk AS build

# Set the workdir for the application
WORKDIR /app

# Copy csproj and restore
COPY . /app

# Install Cake, and compile the Cake build script
RUN dotnet tool restore
RUN dotnet cake

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet AS runtime
WORKDIR /app

# Copy the production artifacts to the workdir
COPY --from=build /app/dist .

# Set the port that the application will run on
ENV ASPNETCORE_URLS=http://+:80

# Set the command that will run the API
ENTRYPOINT ["dotnet", "SibSample.API.dll"]

# Expose the port that the application will run on
EXPOSE 80