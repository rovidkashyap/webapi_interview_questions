
HTTP PUT and HTTP POST are two HTTP methods used to send data to a server, but they are used for 
different purposes and have distinct semantics. Here are the key differences between HttpPut and 
HttpPost:

HTTP PUT:

		- Idempotent: The PUT method is idempotent, meaning that multiple identical requests should 
						have the same effect as a single request. This means that if you send the same 
						PUT request multiple times, the state of the resource should remain the same.

		- Updating or Creating a Resource: PUT is generally used to update an existing resource or 
											create a new resource at a specific URI. If the resource 
											does not exist, the server can create it. If the resource 
											exists, the server updates it with the data provided in 
											the request.

		- Target Resource URI: The client specifies the URI of the resource. The data sent in the PUT 
								request is meant to be stored at the specified URI.

		- Resource Replacement: The resource at the specified URI is completely replaced by the data 
								sent in the PUT request.

HTTP POST:

		- Non-Idempotent: The POST method is non-idempotent, meaning that multiple identical requests 
							can have different effects. For instance, submitting the same form multiple 
							times can result in multiple records being created.

		- Creating a Resource or Triggering a Process: POST is used to create new resources or submit 
													data to be processed to a specific URI. It is often 
													used for submitting form data, uploading files, or 
													triggering server-side operations.

		- Target Resource URI: The client submits data to a specified URI, but the server determines the 
								URI of the newly created resource (if applicable).

		- Resource Creation: The server can create a new resource and often returns the URI of the newly 
								created resource in the response (e.g., in the Location header).