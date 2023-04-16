FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out
RUN dotnet tool install -g dotnet-ef
RUN /root/.dotnet/tools/dotnet-ef migrations bundle -o out/efbundle

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS build
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "colle.dll"]
