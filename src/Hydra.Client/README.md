# Hydra Client
This client requests an access token, and then uses this token to access the API.

The token endpoint at Identity Server implements the OAuth 2.0 protocol, and you could use raw HTTP to access it.

However there is a client library called ```IdentityModel``` that encapsules the protocol interaction in an easy to use API.

Usage: ```dotnet add package IdentityModel```