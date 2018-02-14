using DTO;
using System.Collections.Generic;
using System.Data;

namespace DAL
{
    public class StatusRepository: BaseRepository
    {
        internal StatusRepository() { }

        public bool Add(Status obj)
        {
            return database.ExecuteNonQuery("AddStatus", obj.Name) > 0;
        }
        public bool Edit(Status obj)
        {
            return database.ExecuteNonQuery("EditStatus", obj.Id, obj.Name) > 0;
        }
        public bool Remove(int id)
        {
            return database.ExecuteNonQuery("RemoveStatus", id) > 0;
        }

        static List<Status> GetStatuses(IDataReader reader)
        {
            List<Status> list = new List<Status>();
            while (reader.Read())
            {
                list.Add(GetStatus(reader));
            }
            return list;
        }
        public List<Status> GetStatuses()
        {
            using (IDataReader reader = database.ExecuteReader("GetStatuses"))
            {
                return GetStatuses(reader);
            }
        }
        public Status GetStatusById(int id)
        {
            using (IDataReader reader = database.ExecuteReader("GetStatusById", id))
            {
                if (reader.Read())
                {
                    return GetStatus(reader);
                }
                return null;
            }
        }

        static Status GetStatus(IDataReader reader)
        {
            return new Status
            {
                Id = (int)reader["StatusId"],
                Name = (string)reader["StatusName"]
            };
        }
    }
}
