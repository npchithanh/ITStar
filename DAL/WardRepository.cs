using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class WardRepository : BaseRepository
    {
        internal WardRepository() { }

        public List<Ward> GetWards(byte id)
        {
            using (IDataReader reader = database.ExecuteReader("GetWards", id))
            {
                List<Ward> list = new List<Ward>();
                while (reader.Read())
                {
                    list.Add(new Ward
                    {
                        Id = (byte)reader["WardId"],
                        Name = (string)reader["WardName"],
                        Type = reader["WardType"] == DBNull.Value ? null : (string)reader["WardType"],
                        DistrictId = (short)reader["DistrictId"]
                    });
                }
                return list;
            }
        }
    }
}
