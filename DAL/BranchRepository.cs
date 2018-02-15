using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class BranchRepository : BaseRepository
    {
        internal BranchRepository() { }
        public bool Add(Branch obj)
        {
            return database.ExecuteNonQuery("AddBranch", obj.Name, obj.WardId, obj.Address, obj.Tel) > 0;
        }
        public bool Edit(Branch obj)
        {
            return database.ExecuteNonQuery("EditBranch", obj.Id, obj.Name, obj.WardId, obj.Address, obj.Tel) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveBranch", id) > 0;
        }
        public bool Restore(int id)
        {
            return database.ExecuteNonQuery("RestoreBranch", id) > 0;
        }

        static Branch GetBranch(IDataReader reader)
        {
            return new Branch
            {
                Id = (int)reader["BranchId"],
                Name = (string)reader["BranchName"],
                WardId = (int)reader["Position"],
                Address = reader["Description"] == DBNull.Value ? null : (string)reader["Description"],
                Tel = reader["Tel"] == DBNull.Value ? null : (string)reader["Tel"]
            };
        }
        static List<Branch> GetBranchs(IDataReader reader)
        {
            List<Branch> list = new List<Branch>();
            while (reader.Read())
            {
                list.Add(GetBranch(reader));
            }
            return list;
        }

        public Branch GetBranchById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetBranchById", id))
            {
                if (reader.Read())
                {
                    return GetBranch(reader);
                }
                return null;
            }
        }
        public List<Branch> GetBranchsByParent(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetBranchs"))
            {
                return GetBranchs(reader);
            }
        }
        public List<Branch> GetBranchs()
        {
            using (IDataReader reader = database.ExecuteReader("GetBranchs"))
            {
                return GetBranchs(reader);
            }
        }
    }
}
