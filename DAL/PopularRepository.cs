using DTO;
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

        public List<Popular> GetCategoriesPopular()
        {
            List<Popular> list = new List<Popular>();
            using (IDataReader reader = database.ExecuteReader("GetCategoriesPopular"))
            {
                list.Add(new Popular
                {
                    Id = (int)reader["CategoryId"],
                    Name = (string)reader["CategoryName"],
                    Alt = (string)reader["Alt"],
                    Url = (string)reader["Url"]
                });
                return list;
            }
        }
    }
}
