using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class AttachmentTypeRepository : BaseRepository
    {
        public bool Add(AttachmentType obj)
        {
            return database.ExecuteNonQuery("AddAttachmentType", obj.Name) > 0;
        }
        public bool Edit(AttachmentType obj)
        {
            return database.ExecuteNonQuery("EditAttachmentType", obj.Id, obj.Name) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveAttachmentType", id) > 0;
        }

        static List<AttachmentType> GetAttachmentTypes(IDataReader reader)
        {
            List<AttachmentType> list = new List<AttachmentType>();
            while (reader.Read())
            {
                list.Add(GetAttachmentType(reader));
            }
            return list;
        }
        public List<AttachmentType> GetAttachmentTypes()
        {
            using (IDataReader reader = database.ExecuteReader("GetAttachmentTypes"))
            {
                return GetAttachmentTypes(reader);
            }
        }
        public AttachmentType GetAttachmentTypeById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetAttachmentTypeById", id))
            {
                if (reader.Read())
                {
                    return GetAttachmentType(reader);
                }
                return null;
            }
        }

        static AttachmentType GetAttachmentType(IDataReader reader)
        {
            return new AttachmentType
            {
                Id = (int)reader["AttachmentTypeId"],
                Name = (string)reader["AttachmentTypeName"]
            };
        }
    }
}
