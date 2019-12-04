FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app

# copy everything and build app
COPY . .
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/runtime:2.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

CMD ["dotnet", "ToxicPredictor.ConsoleApp.dll"]
