# LNQ - Pharmacy Management System

This project, **Pharmacy Management**, is developed using .NET (Windows Forms).

---

## Technical Requirements
- **C# .NET Framework 4.7**
- **DevExpress for WinForms v24.1**
- **Guna.UI2.WinForm Framework 4.6**
- **MSSQL Server** (other database servers might not function properly)

---

## Database Setup
To install the database for the Pharmacy Management System, follow these steps:

### 1. Locate the Project Folder
- Right-click on the `PharmacyManagement` project.
- Select **Open Folder in File Explorer** from the context menu.

### 2. Navigate to the Database Query Folder
- Open the folder named `DB-Query`.
- Inside, locate the `PharmacyMgtSys` folder.

### 3. Run the Database Script
- Execute the `PharmacyMgtSys.sql` file to complete the database setup.

---

## Features

### User Role Identity
The software employs a role-based identity system for managing users. The **Admin** role has exclusive permissions to:
- Create new user accounts.
- Assign roles to users.

Other roles, created by the Admin, are limited to:
- Managing pharmacy commodities.
- Updating their personal information.

## Permission role

![alt text](doc/PermissionRole.png)

## Pre-configured Accounts

### Admin Account:
- **Username:** `hoangthilan`
- **Password:** `12345`

### User Account:
- **Username:** `lethihong`
- **Password:** `12345`

![Sign In](doc/SignIn.png)

### Key Functionalities

#### 1. Profile Management
View and update user profile information.

![Profile Setting](doc/Profile.png)

#### 2. Commodity
- Users can create New Commodity

![New Commodity](doc/NewCommodity.png)

- Admin, User can view and delete commodity

![All Commodity](doc/AllCommodities.png)

#### 3. Manage Human
- Admins can create new user accounts.

![New User](doc/NewUser.png)

- Admins can view and manage all user accounts.

![All Accounts](doc/AllAccounts.png)

- Admins can access and update user details.

![All Users](doc/AllUsers.png)

- Users can create and manage customer

![Manage Customer](doc/Customer.png)

#### 4. Manage Invoice
- Users can create new invoice

![New Invoice](doc/NewInvoice.png)

- Admins can view all invoices of users

![All Invoice Admin](doc/AllInvoicesAdmin.png)

- Users can view all invoices written by themselves

![All Invoice User](doc/AllInvoicesUser.png)
---