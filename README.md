# ASP.NET Core Application

This is an ASP.NET MVC application. This README provides instructions on how to set up and run the application, as well as some general information.

Quick Overview of the application as follows:

### Create Assignment
![](https://github.com/nkouki98/Assignment-tracker/blob/main/Creategif.gif?raw=true)

### Complete Assignment
![](https://github.com/nkouki98/Assignment-tracker/blob/main/Completegif.gif?raw=true)
)

### Edit Assignment
![](https://github.com/nkouki98/Assignment-tracker/blob/main/Editgif.gif?raw=true)

### Delete Assignment
![](https://github.com/nkouki98/Assignment-tracker/blob/main/Deletegif.gif?raw=true)
)

## Prerequisites

Make sure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started) (if running in a Docker container)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (if using SQL Server as the database)

## Getting Started

Follow these steps to get the application running on your local machine.

### Clone the Repository

git clone https://github.com/your-username/Assignment-tracker.git
cd your-repo

## Run MS SQL Server Instance using Docker on MacOS.

## In appsettings.json connect to db using 
```bash
"ConnectionStrings": {
    "DefaultConnection":"Server=localhost;Database=DBName;User Id=UserID;Password=Setyourpassword;TrustServerCertificate=true;"
  },
```

use 
```bash 
dotnet build
dotnet watch run
```




