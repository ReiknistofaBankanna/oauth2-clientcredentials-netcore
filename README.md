oauth2-clientcredentials-netcore
==================================

This sample calls a oAuth2 Authorization Server to get a JWT token using the client credentials flow.

## How To Run This Sample

### To run this sample you will need:
- .Net Core 2.1

### Usage:
Usage... adfsUrl clientId clientSecret resource

Example:
```
dotnet oAuth2ClientCredentials.dll https://sts.test.rb.is/adfs/oauth2/token bc23c39e-5303-488d-920c-acb6af333455 mysecret urn:rb.api
```
