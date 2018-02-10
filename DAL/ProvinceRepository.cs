using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class ProvinceRepository : BaseRepository
    {
        internal ProvinceRepository() { }
        public List<Province> GetProvinces()
        {
            using (IDataReader reader = database.ExecuteReader("GetProvinces"))
            {
                List<Province> list = new List<Province>();
                while (reader.Read())
                {
                    list.Add(new Province
                    {
                        Id = (byte)reader["ProvinceId"],
                        Name = (string)reader["ProvinceName"],
                        Type = reader["ProvinceType"]== DBNull.Value ? null : (string)reader["ProvinceType"]                         
                    });
                }
                return list;
            }
        }
    }
}
