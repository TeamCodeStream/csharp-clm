#!/usr/bin/env bash

# start app
nohup dotnet AspNetCoreMvc.dll > /usr/local/newrelic-netcore20-agent/logs/app.log 2>&1 &

# generate load
./tester.sh
