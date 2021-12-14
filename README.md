# api_57blocks

REST API for Backend Homework. ASP NET Core Web API developed with C#, using Entity Framework and SQL Server
Topic selected: **Music**

# Requirements
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)  
- Visual Studio Code
- [C# Extension for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

OR
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

# Installation / Configuration
- Download or clone the project code from https://github.com/wmadrid1/api_57blocks/
- Configure appsettings.json
  - AppSettings/Secret: Used to create JWT tokens
  - ConnectionStrings/database: Connection string to SQL Server database
- Database: to create / fill database with seeds
  - Run command `dotnet ef database update`
  - OR from VS 2022, in Package Manager Console: `Update-Database` 

# Running
Start the API by running `dotnet run` from the command line in the project root folder
OR Ctrl + F5 (Run button) from VS Code or VS 2022

# Using the API
In the URL: API_URL/swagger you can discover all the API resources and data schemas

## User registration
**Request**

POST /User/register

`{
  "email": "string",
  "password": "string"
}`

**Response**

Message

## User authentication
The API uses JWT Bearer Token such as authentication mechanism
**Request**

POST /User/authenticate

`{
  "email": "string",
  "password": "string"
}`

**Response**
`
{
    "id": 1,
    "email": "string",
    "token": "string with JWT token"
}`

From here, all request should include the JWT bearer token (expiring in 20 minutes)

In the request as Header Authorization : Bearer [token] 

## Song creation
**Request**

POST /Song

`{
  "name": "string",
  "artist": "string",
  "album": "string",
  "year": 0,
  "genre": "string"
}`

**Response**

`{
    "id": 16,
    "name": "Para no olvidar",
    "artist": "Los Rodriguez",
    "album": "Para no olvidar",
    "year": 2002,
    "genre": "Rock en español"
}`

## Song edition
**Request**

PUT /Song/[id]

`{
  "id": [song identifier],
  "name": "string",
  "artist": "string",
  "album": "string",
  "year": 0,
  "genre": "string"
}`

**Response**

`{
    "id": 16,
    "name": "Para no olvidar",
    "artist": "Los Rodriguez",
    "album": "Para no olvidar",
    "year": 2002,
    "genre": "Rock en español"
}`

## Get private songs
**Note:** User is already identified in the JWT token
**Request**

GET /Song/private

Optional parameters for pagination:
- PageSize
- PageNumber

Example /Song/private/?PageNumber=1&PageSize=10

**Response**

`[
    {
        "id": 16,
        "name": "Para no olvidar",
        "artist": "Los Rodriguez",
        "album": "Para no olvidar",
        "year": 2002,
        "genre": "Rock en español"
    }
]`



## Get public songs
**Request**

GET /Song/public

Optional parameters for pagination:
- PageSize
- PageNumber

Example /Song/public/?PageNumber=1&PageSize=5

**Response**

`[
    {
        "id": 1,
        "name": "That Ain't Love",
        "artist": "REO Speedwagon",
        "album": "Life as We Know It",
        "year": 1987,
        "genre": "Rock"
    },
    {
        "id": 2,
        "name": "Beds Are Burning",
        "artist": "Midnight Oil",
        "album": "Diesel and Dust",
        "year": 1987,
        "genre": "Rock"
    },
    {
        "id": 3,
        "name": "Take On Me",
        "artist": "A-ha",
        "album": "Hunting High and Low",
        "year": 1985,
        "genre": "Rock"
    },
    {
        "id": 4,
        "name": "Don't Stop Me Now",
        "artist": "Queen",
        "album": "Jazz",
        "year": 1978,
        "genre": "Rock"
    },
    {
        "id": 5,
        "name": "Your Love",
        "artist": "The Outfield",
        "album": "Play Deep",
        "year": 1985,
        "genre": "Rock"
    }
]`
