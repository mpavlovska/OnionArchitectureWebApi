using System;
using System.Data.SqlClient;
using OnionArchitecturedWebApi.Core.MyApp.Core.Entities;
using OnionArchitecturedWebApi.Core.MyApp.Core.Interfaces;

namespace OnionArchitecturedWebApi.Infrastructure.MyApp.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Customer GetCustomer(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Customers WHERE Id = {customerId}", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new Customer
                    {
                        Id = customerId,
                        Name = reader["Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
                return null;
            }
        }

        public void AddCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Customers (Name, Address, Email) VALUES (@Name, @Address, @Email)", connection);
                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@Email", customer.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
