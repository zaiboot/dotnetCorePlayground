docker run -d --rm --network 'dependencies_metrics' \
  --env-file=.env \
  -v $(pwd):/scripts \
  grafana/k6:latest run -a 'localhost:6001' /scripts/queue.js

docker run -d --rm --network 'dependencies_metrics' \
  --env-file=.env \
  -v $(pwd):/scripts \
  grafana/k6:latest run -a 'localhost:6001' /scripts/dequeue.js
