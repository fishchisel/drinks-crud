
There are 3 projects:

DrinksServer
============

asp.net core web api implementation of simple CRUD Drinks table

DrinksClient
============

Simple interactive console application that provides API access

Checkout.ApiClient.Net45
========================

Checkout.ApiClient modified to support connections to DrinksServer.

I modified the following files:

- ApiUrls: Added DrinksUri
- Environment: Added 'LocalTesting' enum option
- AppSettings: Added support for 'LocalTesting' option.

I added the following files:

- DrinksService
- Drink