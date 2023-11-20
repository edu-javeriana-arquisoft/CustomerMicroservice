FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

EXPOSE 8071

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "CustomerMicroservice.dll"]