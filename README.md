# RESTfulWCF
Demonstrates a REST-ful WCF Service which is capable of returning JSON and XML Data

Note: localhost:port is your specific deployment host and port number
  
Some Sample Requests for JSON:

Http GET request:
-----------------
http://localhost:port/RESTfulService.svc/json/Data/4

Expected Response:
------------------
[{"BoolValue":false,"StringValue":"some data #1"}]

Http PUT Request:
-----------------
PUT http://localhost:port/RESTfulService.svc/json/AddData/ HTTP/1.1
User-Agent: Fiddler
Content-Type: application/json
Host: localhost:61220
Content-Length: 60

{
 "BoolValue": "true",
 "StringValue": "some new data"
}

Expected Response:
------------------
HTTP/1.1 200 OK
Cache-Control: private
Content-Length: 54
Content-Type: application/json; charset=utf-8

{"BoolValue":true,"StringValue":"some new data"}
