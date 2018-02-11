using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class CustomerRepository : BaseRepository
    {
        public bool Save(Customer obj)
        {
            return database.ExecuteNonQuery("SaveCustomer", obj.Name, obj.Email, obj.Tel, obj.AttachmentId, obj.WardId, obj.Address, obj.Gender) > 0;
        }
        public bool Edit(Customer obj)
        {
            return database.ExecuteNonQuery("EditCustomer", obj.Id, obj.Name, obj.Email, obj.Tel, obj.AttachmentId, obj.WardId, obj.Address, obj.Gender) > 0;
        }

        public List<Customer> GetCustomers()
        {
            using (IDataReader reader = database.ExecuteReader("GetCustomers"))
            {
                List<Customer> list = new List<Customer>();
                while (reader.Read())
                {
                    list.Add(GetCustomer(reader));
                }
                return list;
            }
        }
        static Customer GetCustomer(IDataReader reader)
        {
            return new Customer
            {
                Id = (long)reader["CustomerId"],
                Email = (string)reader["Email"],
                Name = (string)reader["PersonName"],
                Gender = (bool)reader["Gender"],
                AttachmentId = (int)reader["AttachmentId"],
                WardId = (int)reader["WardId"],
                Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                Tel = reader["Tel"] == DBNull.Value ? null : (string)reader["Tel"]
            };
        }

        public Customer GetCustomerById(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetCustomerById", id))
            {
                if (reader.Read())
                {
                    return GetCustomer(reader);
                }
                return null;
            }
        }

    }
}
