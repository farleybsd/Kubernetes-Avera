#!/bin/bash
docker build -f probes/Dockerfile . -t averaacademy/kubernetes:probes

docker push averaacademy/kubernetes:probes