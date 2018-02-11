using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class CartRepository : BaseRepository
    {
        internal CartRepository() { }

        public bool Add(Cart obj)
        {
            return database.ExecuteNonQuery("AddCart", obj.CartId, obj.ProductId, obj.Quantity) > 0;
        }
        public bool Edit(Cart obj)
        {
            return database.ExecuteNonQuery("EditCart", obj.Id, obj.Quantity) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveCart", id) > 0;
        }
        public bool Clear(long id)
        {
            return database.ExecuteNonQuery("ClearCart", id) > 0;
        }
        static List<Cart> GetCarts(IDataReader reader)
        {
            List<Cart> list = new List<Cart>();
            while (reader.Read())
            {
                list.Add(GetCart(reader));
            }
            return list;
        }
        public List<Cart> GetCart(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetCart", id))
            {
                return GetCarts(reader);
            }
        }
       

        static Cart GetCart(IDataReader reader)
        {
            return new Cart
            {
                Id = (int)reader["RecordId"],
                ProductName = (string)reader["ProductName"],
                Price = (int)reader["Price"],
                DealPrice = (int)reader["DealPrice"],
                Quantity = (short)reader["Quantity"],
                CartId = (long)reader["CartId"]
            };
        }
    }
}
