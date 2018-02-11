using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class AttachmentRepository : BaseRepository
    {
        public bool Add(Attachment obj)
        {
            using (SqlCommand command = new SqlCommand("AddAttachment"))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@attachmentTypeId", SqlDbType.Int).Value = obj.AttachmentTypeId;
                command.Parameters.Add("@url", SqlDbType.VarChar, 128).Value = obj.Url;
                command.Parameters.Add("@alt", SqlDbType.NVarChar, 64).Value = obj.Alt;
                command.Parameters.Add("@size", SqlDbType.Int).Value = obj.Size;
                command.Parameters.Add("@contentType", SqlDbType.VarChar, 32).Value = obj.ContentType;
                command.Parameters.Add("@ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                if (database.ExecuteNonQuery(command) > 0)
                {
                    obj.Id = (int)command.Parameters["@ret"].Value;

                    return true;
                }
                return false;
            }
            //return database.ExecuteNonQuery("AddAttachment", obj.AttachmentTypeId, obj.Url, obj.Alt, obj.Size, obj.ContentType) > 0;
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
