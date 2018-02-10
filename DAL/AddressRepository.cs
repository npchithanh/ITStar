using DTO;
using System.Collections.Generic;
using System.Data;
using System;

namespace DAL
{
    public class AddressRepository : BaseRepository
    {
        internal AddressRepository() { }
        public bool Add(Address obj)
        {
            return database.ExecuteNonQuery("AddAddress", obj.AccountId, obj.Company, obj.Tel, obj.HouseNumber) > 0;
        }
        public bool Edit(Address obj)
        {
            return database.ExecuteNonQuery("EditAddress", obj.Id, obj.AccountId, obj.Company, obj.Tel, obj.HouseNumber) > 0;
        }
        public bool Remove(Address obj)
        {
            return database.ExecuteNonQuery("RemoveAddress", obj.Id) > 0;
        }
        public List<Address> GetAddresses(long id)
        {
            using (IDataReader reader = database.ExecuteReader("EditAddress", id))
            {
                List<Address> list = new List<Address>();
                while (reader.Read())
                {
                    list.Add(GetAddress(reader));
                }
                return list;
            }
        }

        public Address GetAddressById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetAddressById", id))
            {
                if (reader.Read())
                {
                    return GetAddress(reader);
                }
                return null;
            }
        }

        static Address GetAddress(IDataReader reader)
        {
            return new Address
            {
                Id = (int)reader["AddressId"],
                AccountId = (long)reader["AccountId"],
                Company = reader["Company"] == DBNull.Value ? null : (string)reader["Company"],
                HouseNumber = (string)reader["HouseNumber"],
                Tel = (string)reader["Tel"],
                WardId = (int)reader["WardId"]
            };
        }
    }
}
