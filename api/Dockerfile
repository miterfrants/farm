FROM mcr.microsoft.com/dotnet/sdk:5.0.202 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0.5
RUN echo "Asia/Taipei" > /etc/timezone
ENV TZ Asia/Taipei

WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "FarmApi.dll"]