using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Util;

namespace DAL
{
    public class OrderRepository : BaseRepository
    {
        internal OrderRepository() { }

        public bool Add(Order obj)
        {
            obj.Id = RandomBuilder.RandomInt();
            if (database.ExecuteNonQuery("AddOrder", obj.Id, obj.AccountId, obj.StatusId) > 0)
            {
                foreach (OrderDetail item in obj.OrderDetails)
                {
                    item.OrderId = obj.Id;
                    database.ExecuteNonQuery("AddOrderDetail", item.OrderId, item.ProductId, item.Price, item.Quantity);
                }
                return true;
            }
            return false;
        }
        public bool EditStatus(Order obj)
        {
            return database.ExecuteNonQuery("EditStatusOrder", obj.Id, obj.StatusId) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveOrder", id) > 0;
        }
        public bool Clear(long id)
        {
            return database.ExecuteNonQuery("ClearOrder", id) > 0;
        }
        static List<Order> GetOrders(IDataReader reader)
        {
            List<Order> list = new List<Order>();
            while (reader.Read())
            {
                list.Add(GetOrder(reader));
            }
            return list;
        }
        public List<Order> GetOrder(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetOrder", id))
            {
                return GetOrders(reader);
            }
        }
        static Order GetOrder(IDataReader reader)
        {
            return new Order
            {
                Id = (int)reader["OrderId"],
                AddedDate = (DateTime)reader["AddedDate"],
                StatusName = (string)reader["StatusName"],
                StatusId = (int)reader["StatusId"],
                AccountId = (long)reader["AccountId"],

            };
        }
    }
}
