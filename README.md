# RESTfulWCF
      
      Demonstrates a REST-ful WCF Service which is capable of returning JSON and bare XML Data
	  and a ConsoleUI client which uses the SOAP endpoint of that service.

#Notes 

      localhost:port is your specific deployment host and port number.

      I am using Fiddler for the composition of the HTTP Requests. 
      Go to View->Composer (F9)
  
# REST HTML Client

      RESTfulWCF/ServiceLayer/Views/rest.html

#Help

      http://localhost:port/RESTfulService.svc/help

#Requests for JSON

**Http GET request**

      GET http://localhost:port/RESTfulService.svc/Data/73 HTTP/1.1
      User-Agent: Fiddler
      Content-Type: application/json

**Expected Response**

      HTTP/1.1 200 OK
      Cache-Control: private
      Content-Length: 50
      Content-Type: application/json; charset=utf-8
      
      [{"BoolValue":false,"StringValue":"some data #1"}]

**Http PUT Request**

      PUT http://localhost:port/RESTfulService.svc/AddData/ HTTP/1.1
      User-Agent: Fiddler
      Content-Type: application/json
      Host: localhost:port
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

**Http DELETE Request**

	DELETE http://localhost:port/RESTfulService.svc/DeleteData/1 HTTP/1.1
	User-Agent: Fiddler
	Content-Type: application/json

**Expected Response**

	HTTP/1.1 200 OK
	Cache-Control: private
	Content-Length: 4
	Content-Type: application/json; charset=utf-8

	true
 
**Http PUT Request for Data Update**

	PUT http://localhost:port/RESTfulService.svc/UpdateData/1 HTTP/1.1
	User-Agent: Fiddler
	Content-Type: application/json
	Host: localhost:port
	Content-Length: 72

	{
	 "BoolValue":true,
	 "Id":1,
	 "StringValue":"some new data"
	} 
 
**Expected Response**

	HTTP/1.1 200 OK
	Cache-Control: private
	Content-Length: 5
	Content-Type: application/json; charset=utf-8

	true
 
#Requests for bare XML

**Http GET Request**

      GET http://localhost:port/RESTfulService.svc/xml/Data/73 HTTP/1.1
      User-Agent: Fiddler
      Content-Type: application/xml
      Host: localhost:port


**Expected Response**

      HTTP/1.1 200 OK
      Cache-Control: private
      Content-Length: 256
      Content-Type: application/xml; charset=utf-8
      
      <ArrayOfCompositeType xmlns="http://schemas.datacontract.org/2004/07/ServiceLayer" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
      <CompositeType>
            <BoolValue>false</BoolValue>
            <StringValue>some data #1</StringValue>
      </CompositeType></ArrayOfCompositeType>

#Requests to the SOAP Endpoint

** Via ConsoleUI

	  Open the VS solution and launch the ServiceLayer Project. Then open a second instance of the
	  same RESTful solution, set ConsoleUI project as the startup project and launch it. The communication
	  from the client to the WCF service is done via that configured endpoint:
	  
	  <system.serviceModel>
        <bindings>
            <basicHttpBinding>
                <binding name="BasicHttpBinding_IRestfulService" />
            </basicHttpBinding>
        </bindings>
        <client>
            <endpoint address="http://localhost:61220/RESTfulService.svc/soap"
                binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_IRestfulService"
                contract="ServiceReference1.IRestfulService" name="BasicHttpBinding_IRestfulService" />
        </client>
      </system.serviceModel>
	
** Via SOAPUI

		Import WSDL from WCF Service URL: http://localhost:61220/RESTfulService.svc?wsdl
		
		Sample Request/Response
		
		POST http://localhost:61220/RESTfulService.svc/soap HTTP/1.1
		Accept-Encoding: gzip,deflate
		Content-Type: text/xml;charset=UTF-8
		SOAPAction: "http://tempuri.org/IRestfulService/GetXmlData"
		Content-Length: 301
		Host: localhost:61220
		Connection: Keep-Alive
		User-Agent: Apache-HttpClient/4.1.1 (java 1.5)
		
		HTTP/1.1 200 OK
		Cache-Control: private
		Content-Type: text/xml; charset=utf-8
		Content-Encoding: gzip
		Vary: Accept-Encoding
		Server: Microsoft-IIS/10.0
		X-AspNet-Version: 4.0.30319
		X-SourceFiles: =?UTF-8?B?QzpcZGV2XFJFU1RmdWxXQ0ZcU2VydmljZUxheWVyXFJFU1RmdWxTZXJ2aWNlLnN2Y1xzb2Fw?=
		X-Powered-By: ASP.NET
		Date: Sat, 12 Mar 2016 08:44:31 GMT
		Content-Length: 361

		<s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">
		<s:Body>
			<GetXmlDataResponse xmlns="http://tempuri.org/">
				<GetXmlDataResult xmlns:a="http://schemas.datacontract.org/2004/07/ServiceLayer.DataContract" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
				<a:CompositeType>
					<a:BoolValue>false</a:BoolValue>
					<a:Id>2</a:Id>
					<a:StringValue>some data </a:StringValue>
					</a:CompositeType>
				</GetXmlDataResult>
			</GetXmlDataResponse>
		</s:Body>
		</s:Envelope>

	  