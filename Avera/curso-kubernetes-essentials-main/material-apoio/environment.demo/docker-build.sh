#!/bin/bash
docker build -f EnvironmentVariablesDemo/Dockerfile . -t averaacademy/kubernetes:environment-variables

docker push averaacademy/kubernetes:environment-variables
