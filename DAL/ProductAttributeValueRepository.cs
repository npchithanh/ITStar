using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ProductAttributeValueRepository : BaseRepository
    {
        public bool Add(ProductAttributeValue obj)
        {
            return database.ExecuteNonQuery("AddProductAttributeValue", obj.ProductId, obj.AttributeValueId, obj.ProductId, obj.CostDifference, obj.Explain) > 0;
        }
        public bool Edit(ProductAttributeValue obj)
        {
            return database.ExecuteNonQuery("EditProductAttributeValue", obj.ProductId, obj.AttributeValueId, obj.Position, obj.CostDifference, obj.Explain) > 0;
        }
        public bool Remove(int productId, int attributeValueId)
        {
            return database.ExecuteNonQuery("RemoveProductAttributeValue", productId, attributeValueId) > 0;
        }

        static List<ProductAttributeValue> GetProductAttributeValues(IDataReader reader)
        {
            List<ProductAttributeValue> list = new List<ProductAttributeValue>();
            while (reader.Read())
            {
                list.Add(GetProductAttributeValue(reader));
            }
            return list;
        }

        public List<ProductAttributeValue> GetProductAttributeValues()
        {
            using (IDataReader reader = database.ExecuteReader("GetProductAttributeValues"))
            {
                return GetProductAttributeValues(reader);
            }
        }
        public ProductAttributeValue GetProductAttributeValueById(int productId, int attributeValueId)
        {
            using (IDataReader reader = database.ExecuteReader("GetProductAttributeValueById", productId, attributeValueId))
            {
                if (reader.Read())
                {
                    return GetProductAttributeValue(reader);
                }
                return null;
            }
        }

        static ProductAttributeValue GetProductAttributeValue(IDataReader reader)
        {
            return new ProductAttributeValue
            {
                ProductId = (int)reader["ProductId"],
                AttributeValueId = (int)reader["AttributeValueId"],
                CostDifference = reader[""] == DBNull.Value ? null : (int?)reader["CostDifference"],
                Position = (byte)reader["Position"],
                Explain = (string)reader["Explain"]
            };
        }
    }
}
