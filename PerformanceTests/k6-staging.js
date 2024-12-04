import { check, sleep } from "k6";
import http from "k6/http";

export let options = {

  stages: [
    { duration: '30s', target: 100 }, // Ramp up to 100 users over 30 seconds
    { duration: '1m', target: 100 }, // Stay at 100 users for 1 minute
    { duration: '30s', target: 0 },  // Ramp down to 0 users over 30 seconds
  ],

 	thresholds: {
    "http_req_duration": ["p(95) < 200ms"],
    "iteration_duration": ["p(90) < 5s"]
  },

  // required for post for antiforgery 
  discardResponseBodies: false,
}; //end options

/** Generate random blood pressure values in correct ranges
 and ensure systolic is greater than diastolic**/
function getRandomBloodPressure() {
  const diastolic = Math.floor(Math.random() * 61) + 40; // Range: 40 - 100
  const systolic = Math.max(Math.floor(Math.random() * 121) + 70, diastolic + 1); // Ensure systolic >= diastolic + 1
  return { systolic, diastolic };
}
// main k6 function
export default function() {
 
let res = http.get("https://sb-csd-bp.azurewebsites.net/", {"responseType": "text"})

  check(res, {
    "get status is 200": (r) => r.status === 200
  });
  // POST with random data to prevent server cached response to POST
  let bp = getRandomBloodPressure()
  res = res.submitForm({
    fields: { 'BP.Systolic' : bp.systolic,  // Simulated systolic value (70 - 190)
              'BP.Diastolic' : bp.diastolic }  // Simulated diastolic value (40 - 100)
  });

  // Validate the response
  check(res, {
      'post status is 200': (r) => r.status === 200,
      'post body contains blood presure category': (r) => r.body.includes(' Blood Pressure')
  });
  // "think" for 3 seconds
  sleep(3);
}
