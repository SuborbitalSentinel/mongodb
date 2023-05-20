FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /src
COPY *.sln .
COPY consoleapp/*.csproj /src/consoleapp/
RUN dotnet restore

COPY consoleapp/. /src/consoleapp/
RUN dotnet build -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/runtime:7.0 as console-app
COPY --from=build /app /app
ENTRYPOINT /app/mongodb-crud
