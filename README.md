# AccountBook-.net
First of all install visual studio (2019) 
Then install MSSQL and run the following queries
Copy these queries and run them

CREATE DATABASE AccountBook;
USE AccountBook; 

CREATE TABLE LoginInfo (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255),
    password NVARCHAR(255)
);
USE AccountBook; 

CREATE TABLE SalesCategoryTable (
    SaleId INT PRIMARY KEY IDENTITY(1,1),
    SaleDate DATE,
    Amount DECIMAL(10,2),
    CategoryName NVARCHAR(255)
);

After These in the connection string of forms update the server name accordingly
string connectionString = "Data Source=YourServerName;Initial Catalog=AccountBook;Integrated Security=True;";
