using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class RatingRepository : BaseRepository
    {
        internal RatingRepository() { }
        public bool Add(Rating obj)
        {
            return database.ExecuteNonQuery("AddRating", obj.ProductId, obj.AccountId, obj.Star) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveRating", id) > 0;
        }

        Rating GetRating(IDataReader reader)
        {
            return new Rating
            {
                ProductId = (int)reader["ProductId"],
                AccountId = (long)reader["AccountId"],
                Star = (byte)reader["Star"]
            };
        }
        public int GetRating(int productId)
        {
            return (int)database.ExecuteScalar("GetRating", productId);
        }
        public Rating GetRatingById(int productId, long accountId)
        {
            using (IDataReader reader = database.ExecuteReader("GetRatingById", productId, accountId))
            {
                if (reader.Read())
                {
                    return GetRating(reader);
                }
                return null;
            }
        }
        List<Rating> GetRatings(IDataReader reader)
        {
            List<Rating> list = new List<Rating>();
            while (reader.Read())
            {
                list.Add(GetRating(reader));
            }
            return list;
        }
        public List<Rating> GetRatings(int productId)
        {
            using (IDataReader reader = database.ExecuteReader("GetRatings", productId))
            {
                return GetRatings(reader);
            }
        }
    }
}
