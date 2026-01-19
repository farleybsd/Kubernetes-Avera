#!/bin/bash
docker build -f pod-lifecycle.failed/Dockerfile . -t averaacademy/kubernetes:pod-lifecycle-failed
docker build -f pod-lifecycle.succeeded/Dockerfile . -t averaacademy/kubernetes:pod-lifecycle-succeeded
docker build -f pod-lifecycle.running/Dockerfile . -t averaacademy/kubernetes:pod-lifecycle-running
docker build -f pod-lifecycle.hooks/Dockerfile . -t averaacademy/kubernetes:pod-lifecycle-hooks

docker push averaacademy/kubernetes:pod-lifecycle-failed
docker push averaacademy/kubernetes:pod-lifecycle-succeeded
docker push averaacademy/kubernetes:pod-lifecycle-running
docker push averaacademy/kubernetes:pod-lifecycle-hooks
