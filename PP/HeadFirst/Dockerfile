FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HeadFirst/HeadFirst.csproj", "HeadFirst/"]
RUN dotnet restore "HeadFirst/HeadFirst.csproj"
COPY . .
WORKDIR "/src/HeadFirst"
RUN dotnet build "HeadFirst.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HeadFirst.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HeadFirst.dll"]
