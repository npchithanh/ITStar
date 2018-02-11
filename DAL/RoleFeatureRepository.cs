using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class RoleFeatureRepository : BaseRepository
    {
        static List<RoleFeature> GetRoleFeatures(IDataReader reader)
        {
            List<RoleFeature> list = new List<RoleFeature>();
            while (reader.Read())
            {
                list.Add(GetRoleFeature(reader));
            }
            return list;
        }
        public List<RoleFeature> GetRoleFeatures()
        {
            using (IDataReader reader = database.ExecuteReader("GetRoleFeatures"))
            {
                return GetRoleFeatures(reader);
            }
        }
        public RoleFeature GetRoleFeatureById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetRoleFeatureById", id))
            {
                if (reader.Read())
                {
                    return GetRoleFeature(reader);
                }
                return null;
            }
        }

        static RoleFeature GetRoleFeature(IDataReader reader)
        {
            return new RoleFeature
            {
                RoleId = (int)reader["RoleId"],
                FeatureId = (int)reader["FeatureId"]
            };
        }
    }
}
