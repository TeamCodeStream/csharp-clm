#!/bin/bash

sleep 5

echo "Running automated tests..."

while true; do
    # agents/show
    curl -s -o /dev/null http://localhost:80/
    sleep 1

    # agents/create
    curl -s -o /dev/null http://localhost:80/Agents/Create
    sleep 1
    
    # agents/doerror
    curl -s -o /dev/null http://localhost:80/Agents/DoError
    sleep 1
    
    
    # agents/doerror
    curl -s -o /dev/null http://localhost:80/Agents/Error
    sleep 1
    
    # agents/RealisticError
    curl -s -o /dev/null http://localhost:80/Agents/RealisticError
    sleep 1

    # agents/destroy
    curl -s -o /dev/null http://localhost:80/Agents/Destroy
    
    # agents/slowresponse
    curl -s -o /dev/null http://localhost:80/Agents/SlowResponse
        
    echo "Completed a full set of operations."
    sleep 5
done
