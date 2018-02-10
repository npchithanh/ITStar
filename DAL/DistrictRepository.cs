using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class DistrictRepository : BaseRepository
    {
        internal DistrictRepository() { }

        public List<District> GetDistricts(byte id)
        {
            using (IDataReader reader = database.ExecuteReader("GetDistricts", id))
            {
                List<District> list = new List<District>();
                while (reader.Read())
                {
                    list.Add(new District
                    {
                        Id = (byte)reader["DistrictId"],
                        Name = (string)reader["DistrictName"],
                        Type = reader["DistrictType"] == DBNull.Value ? null : (string)reader["DistrictType"],
                        ProvinceId = (byte)reader["ProvinceId"]
                    });
                }
                return list;
            }
        }
    }
}
