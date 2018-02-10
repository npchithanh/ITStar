using DTO;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAL
{
    public class BrandRepository: BaseRepository
    {
        internal BrandRepository() { }
        public bool Add(Brand obj)
        {
            return database.ExecuteNonQuery("AddBrand", obj.Name, obj.Position, obj.Title, obj.Description, obj.Keywords) > 0;
        }
        public bool Edit(Brand obj)
        {
            return database.ExecuteNonQuery("EditBrand", obj.Id, obj.Name, obj.Position, obj.Title, obj.Description, obj.Keywords) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveBrand", id) > 0;
        }
        public bool Restore(int id)
        {
            return database.ExecuteNonQuery("RestoreBrand", id) > 0;
        }

        static Brand GetBrand(IDataReader reader)
        {
            return new Brand
            {
                Id = (int)reader["BrandId"],
                Name = (string)reader["BrandName"],
                Position = (byte)reader["Position"],
                Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                Title = reader["Title"] == DBNull.Value ? null : (string)reader["Title"],
                Keywords = reader["Keywords"] == DBNull.Value ? null : (string)reader["Keywords"]
            };
        }
        static List<Brand> GetBrands(IDataReader reader)
        {
            List<Brand> list = new List<Brand>();
            while (reader.Read())
            {
                list.Add(GetBrand(reader));
            }
            return list;
        }

        public Brand GetBrandById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetBrandById", id))
            {
                if (reader.Read())
                {
                    return GetBrand(reader);
                }
                return null;
            }
        }
        public List<Brand> GetBrandsByParent(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetBrands"))
            {
                return GetBrands(reader);
            }
        }
        public List<Brand> GetBrands()
        {
            using (IDataReader reader = database.ExecuteReader("GetBrands"))
            {
                return GetBrands(reader);
            }
        }
    }
}
