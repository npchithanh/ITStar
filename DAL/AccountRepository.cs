using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AccountRepository : BaseRepository
    {
        object GetObject(string proc, string id)
        {
            return database.ExecuteScalar(proc, id);
        }
        public long GetAccountId(string id)
        {
            return (long)GetObject("GetAccountId", id);
        }

        public string GetUsername(string id)
        {
            return (string)GetObject("GetUsername", id);
        }
        public string GetFullName(string id)
        {
            return (string)GetObject("GetFullName", id);
        }

        public bool Add(UserInRole obj)
        {
            return database.ExecuteNonQuery("AddUserInRole", obj.AccountId, obj.RoleId) > 0;
        }

        public bool Remove(UserInRole obj)
        {
            return database.ExecuteNonQuery("RemoveUserInRole", obj.AccountId, obj.RoleId) > 0;
        }

        public int Count()
        {
            return (int)database.ExecuteScalar("CountAccount");
        }

        public List<Account> GetAccounts(int index, int size)
        {
            using (IDataReader reader = database.ExecuteReader("GetAccounts", (index - 1) * size + 1, index * size)) 
            {
                List<Account> list = new List<Account>();
                while (reader.Read())
                {
                    list.Add(new Account
                    {
                        Id = (long)reader["AccountId"],
                        Username = (string)reader["Username"],
                        FullName = reader["FullName"] == DBNull.Value ? null : (string)reader["FullName"],
                        DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)reader["DateOfBirth"],
                        Gender = (bool)reader["Gender"],
                        IsApproved = (bool)reader["IsApproved"],
                        IsLocked = (bool)reader["IsLocked"]
                    });
                }
                return list;
            }
        }
        public int Login(Account obj)
        {
            using (SqlCommand command = new SqlCommand("LoginAccount"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.VarChar, 32).Value = obj.Username;
                command.Parameters.Add("@password", SqlDbType.Binary, 16).Value = Hash.MD5(obj.Username + "@" + obj.Password);
                command.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                using (IDataReader reader = database.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        obj.Id = (long)reader["AccountId"];
                        return 2;
                    }
                }
                return (int)command.Parameters["@ret"].Value;
            }
            
        }
        public bool Add(Account obj)
        {
            return database.ExecuteNonQuery("AddAccount", obj.Username, Hash.MD5(obj.Username + "@" + obj.Password), obj.FullName, obj.DateOfBirth, obj.Gender, obj.IsApproved) > 0;
        }
    }
}
