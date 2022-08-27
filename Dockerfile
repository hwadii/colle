FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app
EXPOSE 5000
COPY . ./
