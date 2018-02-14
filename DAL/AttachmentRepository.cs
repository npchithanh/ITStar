using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Util;

namespace DAL
{
    public class AttachmentRepository : BaseRepository
    {
        public bool Add(Attachment obj)
        {
            obj.Id = RandomBuilder.RandomInt();
            return database.ExecuteNonQuery("AddAttachment", obj.Id, obj.AttachmentTypeId, obj.Url, obj.Alt, obj.Size, obj.ContentType) > 0;
        }
        public bool Edit(Attachment obj)
        {
            return database.ExecuteNonQuery("EditAttachment", obj.Id, obj.AttachmentTypeId, obj.Url, obj.Alt, obj.Size, obj.ContentType) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveAttachment", id) > 0;
        }

        static List<Attachment> GetAttachments(IDataReader reader)
        {
            List<Attachment> list = new List<Attachment>();
            while (reader.Read())
            {
                list.Add(GetAttachment(reader));
            }
            return list;
        }
        public List<Attachment> GetAttachments()
        {
            using (IDataReader reader = database.ExecuteReader("GetAttachments"))
            {
                return GetAttachments(reader);
            }
        }
        public Attachment GetAttachmentById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetAttachmentById", id))
            {
                if (reader.Read())
                {
                    return GetAttachment(reader);
                }
                return null;
            }
        }

        static Attachment GetAttachment(IDataReader reader)
        {
            return new Attachment
            {
                Id = (int)reader["AttachmentId"],
                AttachmentTypeId = (int)reader["AttachmentTypeId"],
                Url = (string)reader["Url"],
                Alt = reader["Alt"] == DBNull.Value ? null : (string)reader["Alt"],
                Size = reader["Size"] == DBNull.Value ? null : (int?)reader["Size"],
                ContentType = reader["ContentType"] == DBNull.Value ? null : (string)reader["ContentType"]
            };
        }
    }
}
