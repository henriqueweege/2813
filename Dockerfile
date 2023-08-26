FROM mcr.microsoft.com/dotnet/sdk:latest AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./Exercicio/Application/DependencyRoomBooking.csproj"
RUN dotnet build "./Exercicio/Application/DependencyRoomBooking.csproj" -c Debug -o /app/build

FROM base AS final
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=https://*:$PORT dotnet DependencyRoomBooking.dll
