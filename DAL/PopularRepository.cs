using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class PopularRepository : BaseRepository
    {
        public bool Add(Popular obj)
        {
            return database.ExecuteNonQuery("AddPopular", obj.Id, obj.Position) > 0;
        }
        public bool Edit(Popular obj)
        {
            return database.ExecuteNonQuery("EditPopular", obj.Id, obj.Position) > 0;
        }
        public bool Delete(int id)
        {
            return database.ExecuteNonQuery("DeletePopular", id) > 0;
        }
        static Popular GetPopular(IDataReader reader)
        {
            return new Popular
            {
                Id = (int)reader["CategoryId"],
                Name = (string)reader["CategoryName"],
                Url = (string)reader["Url"],
                Alt = reader["Alt"] == DBNull.Value ? null : (string)reader["Alt"]
            };
        }

        public List<Popular> GetCategoriesPopular()
        {
            List<Popular> list = new List<Popular>();
            using (IDataReader reader = database.ExecuteReader("GetCategoriesPopular"))
            {
                while (reader.Read())
                {
                    list.Add(GetPopular(reader));
                }                
                return list;
            }
        }
    }
}
