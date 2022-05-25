#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AspNetCoreMvc/AspNetCoreMvc.csproj", "AspNetCoreMvc/"]
RUN dotnet restore "AspNetCoreMvc/AspNetCoreMvc.csproj"
COPY . .
WORKDIR "/src/AspNetCoreMvc"
RUN dotnet build "AspNetCoreMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["newrelic/", "/usr/local/newrelic-netcore20-agent/"]
ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-netcore20-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-netcore20-agent/libNewRelicProfiler.so \
NEW_RELIC_LICENSE_KEY=YOUR_LICENSE_KEY \
NEW_RELIC_APP_NAME=YOUR_APP_NAME

ENTRYPOINT ["dotnet", "AspNetCoreMvc.dll"]