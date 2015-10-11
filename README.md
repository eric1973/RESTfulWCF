# RESTfulWCF
Demonstrates a REST-ful WCF Service which is capable of returning JSON and XML Data

Note: localhost:port is your specific deployment host and port number.

      I am using Fiddler for the composition of the HTTP Requests. 
      Go to View->Composer (F9)
  

#Help

http://localhost:61220/RESTfulService.svc/help


#Requests for JSON


**Http GET request**

GET http://localhost:61220/RESTfulService.svc/Data/73 HTTP/1.1
User-Agent: Fiddler
Content-Type: application/json

**Expected Response**

HTTP/1.1 200 OK
Cache-Control: private
Content-Length: 50
Content-Type: application/json; charset=utf-8

[{"BoolValue":false,"StringValue":"some data #1"}]

**Http PUT Request**

PUT http://localhost:61220/RESTfulService.svc/AddData/ HTTP/1.1
User-Agent: Fiddler
Content-Type: application/json
Host: localhost:61220
Content-Length: 60

{
 "BoolValue": "true",
 "StringValue": "some new data"
}

**Expected Response**

HTTP/1.1 200 OK
Cache-Control: private
Content-Length: 48
Content-Type: application/json; charset=utf-8

{"BoolValue":true,"StringValue":"some new data"}


#Requests for bare XML

**Http GET Request**

GET http://localhost:61220/RESTfulService.svc/xml/Data/73 HTTP/1.1
User-Agent: Fiddler
Content-Type: application/xml
Host: localhost:61220

**Expected Response**

HTTP/1.1 200 OK
Cache-Control: private
Content-Length: 256
Content-Type: application/xml; charset=utf-8

<ArrayOfCompositeType xmlns="http://schemas.datacontract.org/2004/07/ServiceLayer" xmlns:i="http://www.w3.org/2001/XMLSchema-instance"><CompositeType><BoolValue>false</BoolValue><StringValue>some data #1</StringValue></CompositeType></ArrayOfCompositeType>
