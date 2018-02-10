using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class AttributeValueRepository : BaseRepository
    {
        public bool Add(AttributeValue obj)
        {
            return database.ExecuteNonQuery("AddAttributeValue", obj.AttributeId, obj.Value) > 0;
        }
        public bool Edit(AttributeValue obj)
        {
            return database.ExecuteNonQuery("EditAttributeValue", obj.Id, obj.AttributeId, obj.Value) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveAttributeValue", id) > 0;
        }

        static List<AttributeValue> GetAttributeValues(IDataReader reader)
        {
            List<AttributeValue> list = new List<AttributeValue>();
            while (reader.Read())
            {
                list.Add(GetAttributeValue(reader));
            }
            return list;
        }
        public List<AttributeValue> GetAttributeValues()
        {
            using (IDataReader reader = database.ExecuteReader("GetAttributeValues"))
            {
                return GetAttributeValues(reader);
            }
        }
        public AttributeValue GetAttributeValueById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetAttributeValueById", id))
            {
                if (reader.Read())
                {
                    return GetAttributeValue(reader);
                }
                return null;
            }
        }

        static AttributeValue GetAttributeValue(IDataReader reader)
        {
            return new AttributeValue
            {
                Id = (int)reader["AttributeValueId"],
                AttributeId = (int)reader["AttributeId"],
                Value = (string)reader["Value"]
            };
        }
    }
}
