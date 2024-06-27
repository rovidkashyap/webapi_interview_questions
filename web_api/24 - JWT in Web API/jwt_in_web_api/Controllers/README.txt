
JWT (JSON Web Token) is a compact, URL-safe means of representing claims to be transferred between 
two parties. The claims in a JWT are encoded as a JSON object that is used as the payload of a JSON 
Web Signature (JWS) structure or as the plaintext of a JSON Web Encryption (JWE) structure, enabling 
the claims to be digitally signed or integrity protected with a Message Authentication Code (MAC) 
and/or encrypted.

Components of JWT

1. Header - Consist of two parts: the type of token (JWT) and the signing algorithm (e.g., HMACSHA256).

2. Payload - Contains the claims, which are statements about an entity (typically, the user) and 
				additional	data.

3. Signature - Created by taking the encoded header, the encoded payload, a secret, the algorithm
				specified in the header, and signing them.

How JWT Works

1. The client sends credentials to the server.
2. The server verifies the credentials and if valid, generates a JWT.
3. The JWT is sent back to the client.
4. The client stores the JWT and sends it in the Authorization header of subsequent requests.
5. The server verifies the JWT on each request and grants or denies access based on its validity.

and How to implement the JWT you will already saw that in our Authentication and Authorization Code.