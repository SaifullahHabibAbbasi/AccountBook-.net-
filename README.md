AccountBook-.NET
This project demonstrates how to create a basic account book application using .NET and Microsoft SQL Server.

Prerequisites
Visual Studio 2019

Download and install from the official Visual Studio website.
Microsoft SQL Server

Download and install from the Microsoft SQL Server download page.
Database Setup
Open SQL Server Management Studio (SSMS)

Connect to your SQL Server instance.
Create the Database and Tables

Copy and execute the following SQL queries to create the AccountBook database and necessary tables.
sql
Copy code
-- Create AccountBook database
CREATE DATABASE AccountBook;
USE AccountBook;

-- Create LoginInfo table
CREATE TABLE LoginInfo (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255),
    password NVARCHAR(255)
);

-- Create SalesCategoryTable
CREATE TABLE SalesCategoryTable (
    SaleId INT PRIMARY KEY IDENTITY(1,1),
    SaleDate DATE,
    Amount DECIMAL(10,2),
    CategoryName NVARCHAR(255)
);
Application Configuration
Update Connection String
In your application's configuration file or code, update the connection string to match your SQL Server instance details. Replace YourServerName with the actual name of your SQL Server.
csharp
Copy code
string connectionString = "Data Source=YourServerName;Initial Catalog=AccountBook;Integrated Security=True;";
Sample Code to Use the Connection String
Here is a sample code snippet to demonstrate how to use the connection string in a C# application:
csharp
Copy code
using System;
using System.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=YourServerName;Initial Catalog=AccountBook;Integrated Security=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection opened successfully.");
                
                // Sample query to fetch data from LoginInfo table
                string query = "SELECT * FROM LoginInfo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}, {reader["name"]}, {reader["password"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}
Additional Resources
Visual Studio Documentation
SQL Server Documentation
Entity Framework Documentation
