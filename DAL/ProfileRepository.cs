using DTO;
using System;
using System.Data;

namespace DAL
{
    public class ProfileRepository : BaseRepository
    {
        public bool Save(Profile obj)
        {
            return database.ExecuteNonQuery("SaveProfile", obj.Id, obj.Email, obj.FullName, obj.Gender, obj.DateOfBirth) > 0;
        }

        public Profile GetProfileById(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetProfileById"))
            {
                if (reader.Read())
                {
                    return new Profile
                    {
                        Id = (long)reader["AccountId"],
                        Email = (string)reader["Email"],
                        FullName = (string)reader["FullName"],
                        DateOfBirth = reader["DateOfBirth"] == DBNull.Value ? null : (DateTime?)reader["DateOfBirth"],
                        Gender = (bool)reader["Gender"]
                    };
                }
                return null;
            }
        }

    }
}
