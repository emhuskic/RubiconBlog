# RubiconBlog
 A backend solution for a simple blogging platform

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. 

## Requirments

* Visual Studio 2015 or later - [Download](https://visualstudio.microsoft.com/vs/older-downloads/)
* Microsoft SQL Server Express 2012 or later - [Download](https://www.microsoft.com/en-us/download/details.aspx?id=29062)
* Microsoft .NET framework 4.5.2 or later - [Download](https://support.microsoft.com/en-us/help/2901907/microsoft-net-framework-4-5-2-offline-installer-for-windows-server-201)

## Running this app

1. Clone this GitHub repository
2. Open `BlogAssignment.sln` with Visual Studio;
3. If needed, update the connection string in the `web.config` acording to the SQL Server instance installed;  
4. Open Package Manager Console, and type in 'update-database', it will seed the database
5. Hit `Ctrl` + `F5`.
6. Use Postman or whatever tool you'd like to test..


## Notes

* Slug is unique for a Blog post, so you cannot create 2 posts with the same titles (slugs). 
* API controller is in: `Controller\PostsController.cs` class
* Repository in which all the magic happens (by magic I mean data manipulation in the database) is in:  `DAL\BlogRepository.cs`
* AutoMapper and API configuration is in the Configuration folder
