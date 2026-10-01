# Hospital Appointment Management System

ASP.NET Core MVC assignment implementation.

### Requirements covered
1. Doctor model with DoctorId, DoctorName, Specialization, Experience and ConsultationFee.
2. CalculateTotalCharge() extension method adds ₹100 service charge.
3. Doctor list and details pages.
4. Async GET request to https://jsonplaceholder.typicode.com/posts using HttpClientFactory.
5. Cookie stores patient name.
6. Session stores selected specialization.
7. Query string passes DoctorId to the details page.
8. Hidden field submits DoctorId with appointment form.
9. Response caching on doctor details page.
10. IMemoryCache caches doctor list for 3 minutes.

### Run
Install .NET 8 SDK, open this folder in VS Code, then run:

    dotnet restore
    dotnet run

Open the localhost URL printed in the terminal.
