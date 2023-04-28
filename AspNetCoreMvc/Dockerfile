#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update; apt-get install -y curl
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
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

RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
&& wget https://download.newrelic.com/548C16BF.gpg \
&& apt-key add 548C16BF.gpg \
&& apt-get update \
&& apt-get install -y newrelic-dotnet-agent \
&& rm -rf /var/lib/apt/lists/*

COPY --chmod=0755 entrypoint.sh /
COPY --chmod=0755 tester.sh /app

ENV CORECLR_ENABLE_PROFILING=1 \
CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
NEW_RELIC_CODE_LEVEL_METRICS_ENABLED=true \
NEW_RELIC_APP_NAME="CSharp Agent CLM Demo" \
NEWRELIC_LOG_CONSOLE="true"


ENTRYPOINT ["/entrypoint.sh"]
