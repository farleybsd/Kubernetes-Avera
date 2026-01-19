#!/bin/bash
docker build -f deployment.demo/Dockerfile . -t averaacademy/kubernetes:deployment-demo

docker push averaacademy/kubernetes:deployment-demo