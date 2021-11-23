FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LogReader/LogReader.csproj", "LogReader/"]
RUN dotnet restore "LogReader/LogReader.csproj"
COPY . .
WORKDIR "/src/LogReader"
RUN dotnet build "LogReader.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogReader.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogReader.dll"]
