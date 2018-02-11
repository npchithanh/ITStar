using DTO;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAL
{
    public class CategoryRepository: BaseRepository
    {
        internal CategoryRepository() { }
        public bool Add(Category obj)
        {
            return database.ExecuteNonQuery("AddCategory", obj.Name, obj.Position, obj.Title, obj.Description, obj.Keywords, obj.ParentId) > 0;
        }
        public bool Edit(Category obj)
        {
            return database.ExecuteNonQuery("EditCategory", obj.Id, obj.Name, obj.Position, obj.Title, obj.Description, obj.Keywords, obj.ParentId) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveCategory", id) > 0;
        }
        public bool Restore(int id)
        {
            return database.ExecuteNonQuery("RestoreCategory", id) > 0;
        }

        static Category GetCategory(IDataReader reader)
        {
            return new Category
            {
                Id = (int)reader["CategoryId"],
                Name = (string)reader["CategoryName"],
                Position = (byte)reader["Position"],
                Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                Title = reader["Title"] == DBNull.Value ? null : (string)reader["Title"],
                Keywords = reader["Keywords"] == DBNull.Value ? null : (string)reader["Keywords"],
                ParentId = reader["ParentId"] == DBNull.Value ? null : (int?)reader["ParentId"]
            };
        }
        static List<Category> GetCategories(IDataReader reader)
        {
            List<Category> list = new List<Category>();
            while (reader.Read())
            {
                list.Add(GetCategory(reader));
            }
            return list;
        }

        public Category GetCategoryById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetCategoryById", id))
            {
                if (reader.Read())
                {
                    return GetCategory(reader);
                }
                return null;
            }
        }
        public List<Category> GetCategoriesByParent(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetCategories"))
            {
                return GetCategories(reader);
            }
        }
        public List<Category> GetCategories()
        {
            using (IDataReader reader = database.ExecuteReader("GetCategories"))
            {
                return GetCategories(reader);
            }
        }

        public List<Category> GetParentCategories()
        {
            using (IDataReader reader = database.ExecuteReader("GetParentCategories"))
            {
                return GetCategories(reader);
            }
        }

        

    }
}
