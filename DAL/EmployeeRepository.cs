using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class EmployeeRepository : BaseRepository
    {
        public bool Save(Employee obj)
        {
            return database.ExecuteNonQuery("SaveEmployee", obj.Name, obj.Email, obj.Tel, obj.AttachmentId, obj.WardId, obj.Address, obj.TaxIdentity) > 0;
        }

        public List<Employee> GetEmployees()
        {
            using (IDataReader reader = database.ExecuteReader("GetEmployees"))
            {
                List<Employee> list = new List<Employee>();
                while (reader.Read())
                {
                    list.Add(GetEmployee(reader));
                }
                return list;
            }
        }

        static Employee GetEmployee(IDataReader reader)
        {
            return new Employee
            {
                Id = (long)reader["EmployeeId"],
                Email = (string)reader["Email"],
                Name = (string)reader["PersonName"],
                TaxIdentity = reader["TaxIdentity"] == DBNull.Value ? null : (string)reader["TaxCode"],
                AttachmentId = (int)reader["AttachmentId"],
                WardId = (int)reader["WardId"],
                Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                Tel = reader["Tel"] == DBNull.Value ? null : (string)reader["Tel"]
            };
        }

        public Employee GetEmployeeById(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetEmployeeById", id))
            {
                if (reader.Read())
                {
                    return GetEmployee(reader);
                }
                return null;
            }
        }
    }
}
