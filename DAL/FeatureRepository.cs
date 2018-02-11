using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class FeatureRepository : BaseRepository
    {


        public bool Add(Feature obj)
        {
            return database.ExecuteNonQuery("AddFeature", obj.Name, obj.Controller, obj.Action, obj.Url) > 0;
        }
        public bool Edit(Feature obj)
        {
            return database.ExecuteNonQuery("EditFeature", obj.Id, obj.Name, obj.Controller, obj.Action, obj.Url) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveFeature", id) > 0;
        }

        static List<Feature> GetFeatures(IDataReader reader)
        {
            List<Feature> list = new List<Feature>();
            while (reader.Read())
            {
                list.Add(GetFeature(reader));
            }
            return list;
        }
        public List<Feature> GetFeatures()
        {
            using (IDataReader reader = database.ExecuteReader("GetFeatures"))
            {
                return GetFeatures(reader);
            }
        }
        public Feature GetFeatureById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetFeatureById", id))
            {
                if (reader.Read())
                {
                    return GetFeature(reader);
                }
                return null;
            }
        }

        static Feature GetFeature(IDataReader reader)
        {
            return new Feature
            {
                Id = (int)reader["FeatureId"],
                Name = (string)reader["FeatureName"],
                Controller = reader["Controller"] == DBNull.Value ? null : (string)reader["Controller"],
                Action = reader["Alt"] == DBNull.Value ? null : (string)reader["Alt"],
                Url = reader["Url"] == DBNull.Value ? null : (string)reader["Url"]
            };
        }
    }
}
