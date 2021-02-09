# Training - Command API with GraphQL
## By Les Jackson
Based on YouTube video [GraphQL API with .NET 5 and HotChocolate](https://www.youtube.com/watch?v=HuN94qNwQmM)

## Endpoints (localhost)
* GraphQL: [HTTPS](https://localhost:5001/graphql) / [HTTP](http://localhost:5000/graphql)
* GraphQL Voyager: [HTTPS](https://localhost:5001/graphql-voyager) / [HTTP](http://localhost:5000/graphql-voyager)

## What is GraphQL?
- It's a *query* and *manipulation* language for APIs
- It's also the *runtime* for fulfilling requests
- Created @ Facebook to address both *over* and *under* fetching
- Open Source - hosted by the Linux Foundation

### Core Concepts (GraphQL)
- Schema
  - Describes the API in full
  - Self-documenting
  - Comprised of **Types**
  - Must have a **Root Query Type**
- Types
  - Query
  - Mutation
  - Subscription
  - Objects
    - Allow to make complexes things
  - Enumeration
  - Scalar
    - Id
    - Int
    - String
    - Boolean
    - Float
- Resolvers
  - It returns data from a given field (usually done by *Hot Chocolate* framework)
- Data Source
  - Database
  - Microservice
  - REST API
  - Another GraphQL API

## What is wrong with REST?
- Nothing! But... it is not perfect.
- Over-fetching
  - REST over-fetches: returning more data than you need
    - `GET https://somerestapi/api/cars`
      ```json
      [
        {
          "id": 1,
          "make": "Ford",
          "model": "Fiesta",
          "color": "Blue",
          "year": "2021",
          "registration": "AUS123"
        },
        {
          "id": 2,
          "make": "Toyora",
          "model": "Corolla",
          "color": "White",
          "year": "2010",
          "registration": "PRT246"
        },
        {
          "id": 3,
          "make": "Honda",
          "model": "Civic",
          "color": "Green",
          "year": "2011",
          "registration": "BRA789"
        }
      ]
      ```
  - GraphQL delivers only the data you need
    - `POST https://somerestapi/graphql`
      - Request
        ```graphql
        Query {
          cars {
            id
            registration
          }
        }
        ```
      - Response
        ```json
        {
          "data": {
            "cars": [
              {
                "id": 1,
                "registration": "AUS123"
              },
              {
                "id": 2,
                "registration": "PRT246"
              },
              {
                "id": 3,
                "registration": "BRA789"
              }
            ]
          }
        }
        ```
- Under-fetching
  - REST under-fetches: you need to make multiple requests (3 additional requests given by *options*)
    - `GET https://somerestapi/api/cars/1`
      ```json
      {
        "id": 1,
        "make": "Ford",
        "model": "Fiesta",
        "color": "Blue",
        "year": "2021",
        "registration": "AUS123",
        "options": [
          {
            "extra_uri": "https://somerestapi/api/extras/1"
          },
          {
            "extra_uri": "https://somerestapi/api/extras/4"
          },
          {
            "extra_uri": "https://somerestapi/api/extras/23"
          }
        ]
      }
      ```
  - GraphQL delivers only the data you need
    - `POST https://somerestapi/graphql`
      - Request
        ```graphql
        Query {
          car(id:1) {
            id
            registration
            options {
              name
              cost
            }
          }
        }
        ```
      - Response
        ```json
        [
          {
            "id": 1,
            "registration": "AUS123",
            "options": [
              {
                "name": "Metalic Paint",
                "cost": 1000
              },
              {
                "name": "Alloy Wheels",
                "cost": 1999.99
              },
              {
                "name": "Diamond Steering Wheel",
                "cost": 0.5
              }
            ]
          }
        ]
        ```

## When to use?
- GraphQL
  - Interactive / real-time
  - Mobile apps
  - Complex Object Hierarchy
  - Complex Queries
- REST
  - Non-Interactive (system to system)
  - Microservices
  - Simple Object Hierarchy
  - Repeated, simple queries

## GraphQL in .NET
- NuGet packages
  - GraphQL.NET
    - Open Source
    - ~ 4 million downloads
  - HotChocolate
    - Open Source
    - &lt; 1 million downloads

## Author
:point_right: [Lucas Rosinelli](https://www.lucasrosinelli.com)
