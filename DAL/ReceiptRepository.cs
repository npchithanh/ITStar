using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using Util;

namespace DAL
{
    public class ReceiptRepository : BaseRepository
    {
        internal ReceiptRepository() { }

        public bool Add(Receipt obj)
        {
            obj.Id = RandomBuilder.RandomInt();
            if (database.ExecuteNonQuery("AddReceipt", obj.Id, obj.CustomerId, obj.StatusId) > 0)
            {
                foreach (ReceiptDetail item in obj.ReceiptDetails)
                {
                    item.ReceiptId = obj.Id;
                    database.ExecuteNonQuery("AddReceiptDetail", item.ReceiptId, item.ProductId, item.Price, item.Quantity);
                }
                return true;
            }
            return false;
        }
        public bool EditStatus(Receipt obj)
        {
            return database.ExecuteNonQuery("EditStatusReceipt", obj.Id, obj.StatusId) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveReceipt", id) > 0;
        }
        public bool Clear(long id)
        {
            return database.ExecuteNonQuery("ClearReceipt", id) > 0;
        }
        static List<Receipt> GetReceipts(IDataReader reader)
        {
            List<Receipt> list = new List<Receipt>();
            while (reader.Read())
            {
                list.Add(GetReceipt(reader));
            }
            return list;
        }
        public List<Receipt> GetReceipt(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetReceipt", id))
            {
                return GetReceipts(reader);
            }
        }
        static Receipt GetReceipt(IDataReader reader)
        {
            return new Receipt
            {
                Id = (int)reader["ReceiptId"],
                AddedDate = (DateTime)reader["AddedDate"],
                StatusName = (string)reader["StatusName"],
                StatusId = (int)reader["StatusId"],
                CustomerId = (long)reader["CustomerId"]
            };
        }
    }
}
