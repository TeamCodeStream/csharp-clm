#!/bin/bash

logfile="/usr/local/newrelic-netcore20-agent/logs/tester.log"

sleep 5

echo "Running automated tests..." >> $logfile

while true; do
    # agents/show
    curl -s -o /dev/null http://localhost:80/

    # agents/create
    curl -s -o /dev/null http://localhost:80/Agents/Create

    # agents/destroy
    curl -s -o /dev/null http://localhost:80/Agents/Destroy

    # agents/slowresponse
    curl -s -o /dev/null http://localhost:80/Agents/SlowResponse

    echo "Completed a full set of operations." >> $logfile

    # go too fast and the agent starts sampling
    sleep 3
done
