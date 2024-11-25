import { check, sleep } from "k6";
import http from "k6/http";

export let options = {

  stages: [
    { duration: '30s', target: 10 }, // Ramp up to 10 users over 30 seconds
    { duration: '1m', target: 10 }, // Stay at 10 users for 1 minute
    { duration: '30s', target: 0 },  // Ramp down to 0 users over 30 seconds
  ],

 	thresholds: {
    "http_req_duration": ["p(95) < 100"]
  },

  // required for post for antiforgery 
  discardResponseBodies: false,
}; //end options

// main k6 function
export default function() {
 
  let res = http.get("https://sb-csd-bp.azurewebsites.net/", {"responseType": "text"})

  check(res, {
    "is status 200": (r) => r.status === 200
  });

  // POST with random data to prevent server cached response to POST, discard response body
  res = res.submitForm({
    fields: { 'BP.Systolic' : (Math.floor(Math.random() * 121) + 70).toString(),  // Simulated systolic value (70 - 190)
              'BP.Diastolic': (Math.floor(Math.random() * 61) + 40).toString() }  // Simulated diastolic value (40 - 100)
  });

  // Validate the response
  check(res, {
      'status is 200': (r) => r.status === 200,
  });
  // "think" for 3 seconds
  sleep(3);
}
