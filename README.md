# SimpleWebApiWith.net9andScalar
```
A small ASP.NET Core Web API project targeting .NET 9.
Tests use the Scalar NuGet package for API testing.

About

This repository contains a Web API built with ASP.NET Core targeting .NET 9. The project demonstrates Web API endpoints and includes automated tests which use the Scalar NuGet package to run API tests.

Features

ASP.NET Core Web API (target: .NET 9)

OpenAPI / automatic API documentation (JSON). (.NET 9 ships with built-in OpenAPI generation but not the Swagger UI by default)

Tests implemented using the Scalar NuGet package (used to test the API behavior).

easy-to-run sample project for learning and experimentation.

Prerequisites

.NET 9 SDK
 — install the SDK for your OS.

Git (to clone the repo)

An editor/IDE (VS Code, Visual Studio 2022/2023+, etc.)

Getting started

Clone the repository

git clone https://github.com/Sornali-Sanu/SimpleWebApiWith.net9andScalar.git
cd SimpleWebApiWith.net9andScalar


Restore dependencies

dotnet restore


Build the solution

dotnet build

Run locally

From the Web API project folder (adjust path if project is in a subfolder):

cd <YourWebApiProjectFolder>   # e.g. WebAppPractiseSln/WebAppPractise.Api (update to your actual path)
dotnet run


By default, ASP.NET Core prints the listening URLs in the console (e.g. http://localhost:5000 and https://localhost:5001). Open the provided URL in your browser 

If you prefer, open launchSettings.json inside the project to see configured ports.

API documentation (OpenAPI)

Important .NET 9 note: .NET 9 includes built-in OpenAPI (JSON) generation but does not include the Swagger UI by default in the project template.

If you want the interactive Swagger UI, add Swashbuckle (Swashbuckle.AspNetCore) and configure UseSwagger() / UseSwaggerUI() in Program.cs.

Otherwise the built-in /openapi/v1.json (or similar path) will provide the OpenAPI JSON document.

Example to enable Swashbuckle:

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();



This project uses the Scalar NuGet package for API testing.The Scalar.AspNetCore NuGet package provides an easy way to render beautiful API References based on OpenAPI/Swagger documents.

Ensure all dependencies are restored:

dotnet restore

Install the Scalar NuGet package. In Program.cs file use this :

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}
 run the project .copy the Url .open Browser and use this end point: http://localhost:5042/Scalar/v1
you will get a Scalar Api Reference UI.Test your Api

```
![Project Screenshot](assets/screenshot.png)
