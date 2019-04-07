# Car store API technical spec

Full spec you can find in `TechnicalTest.pdf`

For this test you need to create a RESTful API using .NET's WebApi2 technology and Visual Studio (2012 or higher). 
 
### Requirements 
These are the two must have requirements for this project: 
1. First, you need to create a data structure using the following normalized tables: 
 
Don't implement a real database solution. Just a data structure in the application's memory. 
The initial data must be mocked up and filled as soon as the API is running or in the first HTTP request. 
Explanation: There are different manufacturers building different card models. Each user can own 1 or many car model and each car model can be owned by many users. Every owned car has unique plate number. 
 
2. Once the data structure is ready, our API must implement the following HTTP GET calls and return the values in JSON format according with the description: 
http://localhost/api/users 
Returns a list of users with their ID, email and name. 
 
http://localhost/api/manufacturers 
Returns a list of manufacturers with their ID, name, country and available Cars. For each card include ID, model and year. 

 
http://localhost/api/user/{id} 
Given an user's ID, returns detailed information of that User which includes ID, email, name and a list with owned Cars. For each card include ID, plate number, model, year and the Manufacturer. For the manufacturer include ID, name and country. 
 
#### Delivery 
You need to return the full solution with all required projects compressed in a ZIP file. 
The created solution must work without any extra installation. You can use NuGet packages, but you cannot any other libraries out of Visual Studio application or IIS Express. The solution must work just opening, building, restoring NuGet packages (if required) and clicking on run. 
Do not include binaries. 
 
#### Extra 
The complexity of the solution is up to the candidate, but including additional things such as unit testing, dependency injection, inversion of control, LINQ, etc... will be appreciated. 
