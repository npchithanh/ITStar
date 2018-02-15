using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class CommentRepository : BaseRepository
    {
        internal CommentRepository() { }
        public bool Add(Comment obj)
        {
            obj.Id = Util.RandomBuilder.RandomInt();
            return database.ExecuteNonQuery("AddComment", obj.Id, obj.ProductId, obj.AccountId, obj.Content, obj.ParentId) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveComment", id) > 0;
        }

        Comment GetComment(IDataReader reader)
        {
            return new Comment
            {
                Id = (int)reader["CommentId"],
                ProductId = (int)reader["ProductId"],
                AccountId = (long)reader["AccountId"],
                FullName = (string)reader["FullName"],
                Content = (string)reader["Content"],
                ParentId = reader["ParentId"] == DBNull.Value ? null : (int?)reader["ParentId"]
            };
        }
        List<Comment> GetComments(IDataReader reader)
        {
            List<Comment> list = new List<Comment>();
            while (reader.Read())
            {
                list.Add(GetComment(reader));
            }
            return list;
        }
        public List<Comment> GetComments(int productId)
        {
            using (IDataReader reader = database.ExecuteReader("GetComments", productId))
            {
                return GetComments(reader);
            }
        }

    }
}
