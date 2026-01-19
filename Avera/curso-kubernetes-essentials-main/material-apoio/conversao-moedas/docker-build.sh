#!/bin/bash
docker build -f conversao-moedas/Dockerfile . -t averaacademy/kubernetes:conversao-moedas

docker push averaacademy/kubernetes:conversao-moedas