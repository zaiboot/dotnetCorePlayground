# API TESTS

The idea behind this is to test some CPU/ RAM and IO bound with aspnet core vs golang. At the company I work there seems to be issues when using IO work. I would like to know if golang is a better suit for this or not.

## STACK

* .net core 6
* K6 for load testing

## FUNCTIONALITIES
* QueueController.cs: Holds a queue, where we will store X amount of records and then pop them