# WeatherBoy

The WeatherBoy API is a C# based web application that provides current weather and weather forecast data using the http://api.weatherapi.com/ API. It utilizes minimal APIs, MediatR for CQRS, and Mapito for mapping. This README file provides an overview of the API, its functionalities, and instructions on how to set it up and use it.

## Table of Contents
- [Features](#features)
- [Requirements](#requirements)
- [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Configuration](#configuration)
- [Usage](#usage)
  - [Endpoints](#endpoints)
  - [Swagger Support](#swagger-support)

## Features

The WeatherBoy API provides the following features:

- Fetches current weather data for a specific location using latitude and longitude coordinates.
- Retrieves weather forecast data for a specified location using latitude and longitude coordinates for the next few days.
- Utilizes minimal APIs for a streamlined and efficient routing approach.
- Employs [MediatR](https://github.com/jbogard/MediatR) to implement CQRS (Command Query Responsibility Segregation) for better separation of concerns.
- Utilizes [Mapito](https://github.com/jbmoe/Mapito) for object-to-object mapping to simplify data transformation.
- Includes Swagger support for easy API documentation and testing.

## Requirements

To run the WeatherBoy API, you need the following:

- .NET Core SDK (version 7 or later) installed on your machine.
- An API key from http://api.weatherapi.com/. (Sign up for a free account to obtain the API key.)

## Getting Started

Follow the steps below to set up and run the WeatherBoy API:

### Installation

1. Clone this repository to your local machine.
2. Open the solution file (WeatherBoy.sln) in Visual Studio.

### Configuration

1. In the solution, find the `appsettings.json` file in the `WeatherBoy.Runtime.WeatherApi` ASP.NET Core Web API.
2. Replace `"YOUR_API_KEY"` with your actual WeatherAPI API key.

```json
{
  "WeatherApiSettings": {
    "ApiKey": "YOUR_API_KEY",
    "BaseUrl": "http://api.weatherapi.com"
  }
}
```

## Usage

### Endpoints

The WeatherApi ASP.NET Core Web API exposes the following endpoints:

- `GET {{BaseUrl}}/weather/forecast?latitude={latitude}&longitude={longitude}`: Fetches weather forecast data for the specified `latitude` and `longitude` coordinates.
- `GET {{BaseUrl}}/weather/current?latitude={latitude}&longitude={longitude}`: Fetches current weather data for the specified `latitude` and `longitude` coordinates.
- `GET {{BaseUrl}}/locations/search?term={term}`: Searches for locations based on the `term`.

Replace `{latitude}` and `{longitude}` with the latitude and longitude coordinates of the location for which you want to retrieve weather data. Replace `{term}` with the search term to find locations.

### Swagger Support

The WeatherBoy ASP.NET Core Web API includes Swagger support, providing easy API documentation and testing.

To access the Swagger UI, run the API and navigate to the `/swagger` endpoint (e.g., `http://localhost:{port}/swagger`).
