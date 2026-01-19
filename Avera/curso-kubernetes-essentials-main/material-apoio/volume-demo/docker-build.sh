#!/bin/bash
docker build -f volume-demo.create/Dockerfile . -t averaacademy/kubernetes:volume-demo-create
docker build -f volume-demo.read/Dockerfile . -t averaacademy/kubernetes:volume-demo-read

docker push averaacademy/kubernetes:volume-demo-create
docker push averaacademy/kubernetes:volume-demo-read
