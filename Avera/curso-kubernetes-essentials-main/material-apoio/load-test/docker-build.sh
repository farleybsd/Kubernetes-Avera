#!/bin/bash
docker build -f LoadTest/Dockerfile . -t averaacademy/kubernetes:load-test

docker push averaacademy/kubernetes:load-test
