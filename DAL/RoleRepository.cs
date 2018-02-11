using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class RoleRepository: BaseRepository
    {
        internal RoleRepository() { }

        public bool Add(RoleFeature obj)
        {
            return database.ExecuteNonQuery("AddRoleFeature", obj.RoleId, obj.FeatureId) > 0;
        }

        public bool Remove(RoleFeature obj)
        {
            return database.ExecuteNonQuery("RemoveRoleFeature", obj.RoleId, obj.FeatureId) > 0;
        }
        public bool IsInRole(long accountId, string role)
        {
            return (int)database.ExecuteScalar("IsInRole", accountId, role) > 0;
        }

        public bool Add(Role obj)
        {
            return database.ExecuteNonQuery("AddRole", obj.Name, obj.Explain) > 0;
        }
        public bool Edit(Role obj)
        {
            return database.ExecuteNonQuery("EditRole", obj.Id, obj.Name, obj.Explain) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveRole", id) > 0;
        }

        static List<Role> GetRoles(IDataReader reader)
        {
            List<Role> list = new List<Role>();
            while (reader.Read())
            {
                list.Add(GetRole(reader));
            }
            return list;
        }
        public List<Role> GetRolesByUser(long id)
        {
            using (IDataReader reader = database.ExecuteReader("GetRolesByUser", id))
            {
                return GetRoles(reader);
            }
        }
        public List<Role> GetRoles()
        {
            using (IDataReader reader = database.ExecuteReader("GetRoles"))
            {
                return GetRoles(reader);
            }
        }
        public Role GetRoleById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetRoleById", id))
            {
                if (reader.Read())
                {
                    return GetRole(reader);
                }
                return null;
            }
        }

        static Role GetRole(IDataReader reader)
        {
            return new Role
            {
                Id = (int)reader["RoleId"],
                Name = (string)reader["RoleName"],
                Explain = (string)reader["Explain"]
            };
        }
    }
}
