 docker run -d --rm --network 'dependencies_metrics' \
   --name queuer_go \
   --env-file=dotnet.env \
   -v $(pwd):/scripts \
   grafana/k6:latest run /scripts/queue.js

docker run -d --rm --network 'dependencies_metrics' \
  --name dequeuer_go \
  --env-file=dotnet.env \
  -v $(pwd):/scripts \
  grafana/k6:latest run /scripts/dequeue.js
