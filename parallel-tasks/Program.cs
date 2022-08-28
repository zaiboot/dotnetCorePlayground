//We will be simulating reading from kafka, with 4 partitions and try to handle errors
// just for kicks. This is in no way PROD code, but a POC on how to use concurrency using
// tasks (async,await)

var tests1 = new ParalleForEachTests();
tests1.Main();
