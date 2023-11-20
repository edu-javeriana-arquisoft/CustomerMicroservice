FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out



FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App

COPY --from=build-env /App/out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CustomerMicroservice.dll"]