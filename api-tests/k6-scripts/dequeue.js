import http from 'k6/http';
import { sleep, check } from 'k6';
import { Counter } from 'k6/metrics';;

export const requests = new Counter('http_reqs');

// const data = new SharedArray('queues', function () {
//   return JSON.parse(open('./data.json')).queues;
// });

// you can specify stages of your test (ramp up/down patterns) through the options object
// target is the number of VUs you are aiming for

export const options = {
  /*k6 works with the concept of virtual users (VUs), which run your test scripts. VUs are essentially parallel while(true) loops. Scripts are written in JavaScript, as ES6 modules, which allows you to break larger tests into smaller pieces or make reusable pieces as you like.*/
//  vus: 40,
  /*
  A string specifying the total duration a test run should be run for. During this time each VU will execute the script in a loop. Available in k6 run and k6 cloud commands.
  */
//  duration: '30s'
  stages: [
    { duration: '10s', target: 40 },
    { duration: '10s', target: 30 },
    { duration: '10s', target: 0 },
  ],
};

// so this should run during 30s, simulating 10 users. Taking into account, the sleep(1)
// The number of http calls can be expressed as:
// MAX = VUS*DURATION, in this case 300
const port = `${__ENV.PORT_API}`;
const hostname = `${__ENV.HOST_NAME}`; //'host.docker.internal' || 'localhost';

export default function () {
  // our HTTP request, note that we are saving the response to res, which can be accessed later

  const url = `http://${hostname}:${port}/api/Queue/`;
  const res = http.get(url);
  sleep(0.3);
  check(res, {
    'status is 204': (r) => r.status == 204,
    'response body': (r) => r.status == 200 && !isNaN(parseInt(r.body)),
  });

}
