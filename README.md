# LNQ - Pharmacy Management System
This project Pharmacy Management is written by .Net (Windows Form)
### Technical requires
- C# .NET Framework 4.7
- DevExpress for Winform v24.1
- Guna.UI2.Winform Framework 4.6
- MSSQL Server (others might not work properly)
----
### Setup DB
To install the database for the Pharmacy Management System, follow these steps:
**1. Locate the Project Folder:**
- Right-click on the PharmacyManagement project.
- Select Open Folder in File Explorer from the context menu.
**2. Navigate to the Database Query Folder:**
- Open the folder named DB-Query.
- Inside, locate the PharmacyMgtSys folder.
**3. Run the Database:**
- Run *PharmacyMgtSys.sql* file to complete the database setup.
----
### Features
**User role identity**
The software employs a role-based identity system for user management. The Admin role has exclusive permissions to create new user accounts and assign roles to them. Other roles, created by the Admin, are restricted to managing pharmacy commodities and updating their personal information.
- Login as admin: 
In the database, an account with admin privileges has been provided. We use the account of Hoang Thi Lan with the username “hoangthilan” and the password “12345”.
![Sign In](imageReadme/image.png)
1. Profile:
![Profile Setting](imageReadme/image-1.png)
2. New user:
![New user](imageReadme/image-2.png)
3. All accounts:
![All accounts](imageReadme/image-3.png)
4. All users:
![All users](imageReadme/image-4.png)