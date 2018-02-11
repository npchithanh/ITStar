using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ProductRepository : BaseRepository
    {
        internal ProductRepository() { }
        public bool Add(Product obj)
        {
            return database.ExecuteNonQuery("AddProduct", obj.CategoryId, obj.BrandId, obj.Name, obj.Price, obj.DealPrice, obj.Explain, obj.IsNewest, obj.IsHotest, obj.Title, obj.Description, obj.Keywords) > 0;
        }
        public bool Edit(Product obj)
        {
            return database.ExecuteNonQuery("EditProduct", obj.Id, obj.CategoryId, obj.BrandId, obj.Name, obj.Price, obj.DealPrice, obj.Explain, obj.IsNewest, obj.IsHotest, obj.Title, obj.Description, obj.Keywords) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveProduct", id) > 0;
        }
        public bool Restore(int id)
        {
            return database.ExecuteNonQuery("RestoreProduct", id) > 0;
        }

        static Product GetProduct(IDataReader reader)
        {
            return new Product
            {
                Id = (int)reader["ProductId"],
                CategoryId = (int)reader["CategoryId"],
                BrandId = (int)reader["BrandId"],
                Name = (string)reader["ProductName"],
                Price = (int)reader["Position"],
                DealPrice = (int)reader["DealPrice"],
                IsNewest = (bool)reader["IsNewest"],
                IsHotest = (bool)reader["IsHotest"],
                Description = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                Title = reader["Title"] == DBNull.Value ? null : (string)reader["Title"],
                Keywords = reader["Keywords"] == DBNull.Value ? null : (string)reader["Keywords"],
            };
        }
        static List<Product> GetProducts(IDataReader reader)
        {
            List<Product> list = new List<Product>();
            while (reader.Read())
            {
                list.Add(GetProduct(reader));
            }
            return list;
        }

        public Product GetProductById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetProductById", id))
            {
                if (reader.Read())
                {
                    return GetProduct(reader);
                }
                return null;
            }
        }
        public List<Product> GetProducts(int index, int size)
        {
            using (IDataReader reader = database.ExecuteReader("GetProducts", (index - 1)*size + 1, index * size ))
            {
                return GetProducts(reader);
            }
        }

        public List<Product> GetProductsByCategory(int id, int index, int size)
        {
            using (IDataReader reader = database.ExecuteReader("GetProductsByCategory", id, (index - 1) * size + 1, index * size))
            {
                return GetProducts(reader);
            }
        }

        public List<Product> GetProductsByBrand(int id, int index, int size)
        {
            using (IDataReader reader = database.ExecuteReader("GetProductsByBrand", id, (index - 1) * size + 1, index * size))
            {
                return GetProducts(reader);
            }
        }

        public List<Product> GetProductsNewest()
        {
            using (IDataReader reader = database.ExecuteReader("GetProductsNewest"))
            {
                return GetProducts(reader);
            }
        }

        public List<Product> GetProductsHotest()
        {
            using (IDataReader reader = database.ExecuteReader("GetProductsHotest"))
            {
                return GetProducts(reader);
            }
        }

        /*public Product GetProductById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetProductById", id))
            {
                if (reader.Read())
                {
                    return GetProduct(reader);
                }
                return null;
            }
        }*/
    }
}
