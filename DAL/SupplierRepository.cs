using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class SupplierRepository : BaseRepository
    {
        public bool Save(Supplier obj)
        {
            return database.ExecuteNonQuery("SaveSupplier", obj.Name, obj.Email, obj.Tel, obj.AttachmentId, obj.WardId, obj.Address, obj.TaxCode) > 0;
        }

        public List<Supplier> GetSuppliers()
        {
            using (IDataReader reader = database.ExecuteReader("GetSuppliers"))
            {
                List<Supplier> list = new List<Supplier>();
                while (reader.Read())
                {
                    list.Add(GetSupplier(reader));
                }
                return list;
            }
        }
        static Supplier GetSupplier(IDataReader reader)
        {
            return new Supplier
            {
                Id = (long)reader["SupplierId"],
                Email = (string)reader["Email"],
                Name = (string)reader["PersonName"],
                TaxCode = (string)reader["TaxCode"],
                AttachmentId = (int)reader["AttachmentId"],
                WardId = (int)reader["WardId"],
                Address = reader["Address"] == DBNull.Value ? null : (string)reader["Address"],
                Tel = reader["Tel"] == DBNull.Value ? null : (string)reader["Tel"]
            };
        }

        public Supplier GetSupplierById(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetSupplierById", id))
            {
                if (reader.Read())
                {
                    return GetSupplier(reader);      
                }
                return null;
            }
        }

    }
}
