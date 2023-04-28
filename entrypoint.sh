#!/usr/bin/env bash

# start app
dotnet AspNetCoreMvc.dll &

# generate load
./tester.sh
