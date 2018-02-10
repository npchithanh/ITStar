using System.Collections.Generic;
using DTO;
using System.Data;

namespace DAL
{
    public class AttributeRepository : BaseRepository
    {
        public bool Add(Attribute obj)
        {
            return database.ExecuteNonQuery("AddAttribute", obj.Name) > 0;
        }
        public bool Edit(Attribute obj)
        {
            return database.ExecuteNonQuery("EditAttribute", obj.Id, obj.Name) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveAttribute", id) > 0;
        }

        static List<Attribute> GetAttributes(IDataReader reader)
        {
            List<Attribute> list = new List<Attribute>();
            while (reader.Read())
            {
                list.Add(GetAttribute(reader));
            }
            return list;
        }
        public List<Attribute> GetAttributes()
        {
            using (IDataReader reader = database.ExecuteReader("GetAttributes"))
            {
                return GetAttributes(reader);
            }
        }
        public Attribute GetAttributeById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetAttributeById", id))
            {
                if (reader.Read())
                {
                    return GetAttribute(reader);
                }
                return null;
            }
        }

        static Attribute GetAttribute(IDataReader reader)
        {
            return new Attribute
            {
                Id = (int)reader["AttributeId"],
                Name = (string)reader["AttributeName"]
            };
        }
    }
}
