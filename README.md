<p align="center">
  <a href="https://github.com/zandiarash/Arshid-Aspire-ApiDocs-Extensions">
    <img src="https://github.com/user-attachments/assets/e0324879-a50d-43ec-9cbf-6a5d241e6ee0">
  </a>
</p>

<h1 align="center">Arshid Aspire ApiDocs Extensions</h1>

An extension to add **Swagger**, **OpenApi**, **Scalar**, **CustomUrl** and **CustomRoute** to **.Net Aspire** dashboard for **API**, **Blazor** and any other app.

You can have **ApiDocs** and also your custom **links** in your **.Net Aspire Dashboard** like this :
![AspireDashboard](https://github.com/user-attachments/assets/ab975e4e-9f42-4b93-a983-c359a2bb500c)

## Getting Started
### Installation
Simply install this **nuget package**  [Arshid.Aspire.ApiDocs.Extensions](https://www.nuget.org/packages/Arshid.Aspire.ApiDocs.Extensions) to your **AppHost.csproj**  
  
```
dotnet add package Arshid.Aspire.ApiDocs.Extensions
```

![Nuget Package](https://github.com/user-attachments/assets/824ede4b-2afd-46ae-b8cb-b24e0dacff92)

Then add these lines for the project that has Swagger, Scalar or etc.

## 📦 Example
```C#
using Arshid.Aspire.ApiDocs.Extensions;

var apiService = builder.AddProject<Projects.AspireApp1_ApiService>("apiservice")
    .WithScalar()
    .WithSwagger()
    .WithOpenApi()
    .WithCustomUrl("https://127.0.0.1:5000/CustomRoute/CustomPage1")
    .WithRoute("/CustomRoute/CustomPage2"); //The URL become something like this {protocol}://{url}:{port}/CustomRoute/CustomPage2
```
  
![Usage](https://github.com/user-attachments/assets/b289704b-3bb0-4cc2-ba4f-ccaafe5732f3)

### If you are not familiar with Swagger, Scalar, OpenApi and similar tools please read from this article :
[net-9-revolutionizing-documentation-of-apis-from-swashbuckle-to-scalar](https://dev.to/arashzandi/net-9-revolutionizing-documentation-of-apis-from-swashbuckle-to-scalar-527)

## 🤝 Contributing is welcome
If you would like to contribute, please feel free to create a Pull Request.
