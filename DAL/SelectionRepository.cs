using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class SelectionRepository : BaseRepository
    {
        public bool Add(Selection obj)
        {
            return database.ExecuteNonQuery("AddSelection", obj.Id, obj.Position) > 0;
        }
        public bool Edit(Selection obj)
        {
            return database.ExecuteNonQuery("EditSelection", obj.Id, obj.Position) > 0;
        }
        public bool Delete(int id)
        {
            return database.ExecuteNonQuery("DeleteSelection", id) > 0;
        }

        public List<Selection> GetCategoriesSelection()
        {
            List<Selection> list = new List<Selection>();
            using (IDataReader reader = database.ExecuteReader("GetCategoriesSelection"))
            {
                list.Add(new Selection
                {
                    Id = (int)reader["CategoryId"],
                    Name = (string)reader["CategoryName"]
                });
                return list;
            }
        }
    }
}
