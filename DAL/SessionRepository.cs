using DTO;
using System.Data;

namespace DAL
{
    public class SessionRepository : BaseRepository
    {
        internal SessionRepository() { }
        public bool Add(Session obj)
        {
            return database.ExecuteNonQuery("AddSession", obj.Id, obj.AccountId, obj.IP, obj.Device, obj.Browser) > 0;
        }
        public string GetUsername(string id)
        {
            using (IDataReader reader = database.ExecuteReader("GetUsername", id))
            {
                if (reader.Read())
                {
                    return (string)reader["Username"];
                }
                return null;
            }
        }
        public bool IsLogined(string id)
        {
            return (int)database.ExecuteScalar("IsLogined", id) > 0;
        }
        public bool Remove(string id)
        {
            return database.ExecuteNonQuery("RemoveSession", id) > 0;
        }
    }
}
