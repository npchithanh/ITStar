using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BillRepository : BaseRepository
    {
        internal BillRepository() { }

        public bool Add(Bill obj)
        {
            obj.Id = Util.RandomBuilder.RandomInt();
            if (database.ExecuteNonQuery("AddBill", obj.Id, obj.SupplierId, obj.StatusId) > 0)
            {
                foreach (BillDetail item in obj.BillDetails)
                {
                    item.BillId = obj.Id;
                    database.ExecuteNonQuery("AddBillDetail", item.BillId, item.ProductId, item.Price, item.Quantity);
                }
                return true;
            }
            return false;
        }
        public bool EditStatus(Bill obj)
        {
            return database.ExecuteNonQuery("EditStatusBill", obj.Id, obj.StatusId) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveBill", id) > 0;
        }
        public bool Clear(long id)
        {
            return database.ExecuteNonQuery("ClearBill", id) > 0;
        }
        static List<Bill> GetBills(IDataReader reader)
        {
            List<Bill> list = new List<Bill>();
            while (reader.Read())
            {
                list.Add(GetBill(reader));
            }
            return list;
        }
        public List<Bill> GetBill(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetBill", id))
            {
                return GetBills(reader);
            }
        }
        static Bill GetBill(IDataReader reader)
        {
            return new Bill
            {
                Id = (int)reader["BillId"],
                AddedDate = (DateTime)reader["AddedDate"],
                StatusName = (string)reader["StatusName"]
            };
        }
    }
}
