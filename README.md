# ASP.NET MVC Job Portal

A full-featured job portal web application built with ASP.NET MVC 5, Entity Framework 6, and SQL Server. This project serves as a practical example of building a database-driven web application with role-based user authentication.

---
## Features

* **User Authentication:** Secure user registration and login system.
* **Role-Based Authorization:** Two distinct user roles with different permissions:
    * **Employer:** Can post new job listings, and edit or delete their own postings.
    * **Job Seeker:** Can browse and search for jobs, and submit applications.
* **Job Management (CRUD):** Full Create, Read, Update, and Delete functionality for job listings.
* **Job Application System:** Job seekers can apply for jobs and optionally upload a resume.
* **Database-Driven:** All data (jobs, applications, users, roles) is stored in a SQL Server database.
* **Modern UI:** Clean, responsive user interface built with Bootstrap.

---
## Technologies Used

* **Backend:** C#, ASP.NET MVC 5, Entity Framework 6
*nstructions
1. Clone the repository: `git clone https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git`
2. Open the `DatabaseSetup.sql` file in SQL Server Management Studio (SSMS) and execute the script to create the `JobPortalDB` database and tables.
3. Open the `JobPortal.sln` file in Visual Studio.
4. In the `Web.config` file, update the `JobPortalDB` connection string with your SQL Server instance name if it's different from `(localdb)\MSSQLLocalDB`.
5. Build the solution and run the project (F5).
