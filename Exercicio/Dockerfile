
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR .
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR .
COPY . .
RUN dotnet restore "./Application/DependencyRoomBooking.csproj"
RUN dotnet build "./Application/DependencyRoomBooking.csproj" -c Debug -o ./app/build
COPY . .

FROM build AS publish
RUN dotnet publish "./Application/DependencyRoomBooking.csproj" -c Debug -o  ./app/publish

FROM base AS final
WORKDIR .
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet DependencyRoomBooking.dll