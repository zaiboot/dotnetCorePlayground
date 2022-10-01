# we need to set the port, since k6 has an http server where data can be fetched
k6 run -e HOST_NAME='localhost' -a 'localhost:6001' queue.js &
k6 run -e HOST_NAME='localhost' -a 'localhost:6000' dequeue.js &