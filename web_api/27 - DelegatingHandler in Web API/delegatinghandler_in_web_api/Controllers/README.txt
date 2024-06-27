
A DelegatingHandler in ASP.NET Core is a way to process HTTP requests and responses. It's part of 
the HTTP message handler pipeline, which allows for custom handling of HTTP requests and responses 
in a modular way.

How DelegatingHandler Works?

1. Pipeline Concept:

		- The HTTP message handler pipeline consists of a series of handlers that process the HTTP 
		request and response messages. Each handler can either process the message itself or pass 
		it along to the next handler in the pipeline.

		- DelegatingHandler is a special type of HttpMessageHandler that can delegate the processing 
		of the HTTP request to another handler.

2. Creating a DelegatingHandler:
		
		- You create a custom handler by inheriting from DelegatingHandler and overriding the SendAsync 
		method.

3. SendAsync Method:

		- The SendAsync method is called to process the HTTP request. This method receives an 
		HttpRequestMessage and a CancellationToken as parameters and returns a Task<HttpResponseMessage>.

		- Within the SendAsync method, you can process the request, modify it, and then call the base 
		SendAsync method to pass the request to the next handler in the pipeline.