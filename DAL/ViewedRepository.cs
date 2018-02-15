using DTO;

namespace DAL
{
    public class ViewedRepository : BaseRepository
    {
        public bool Save(Viewed obj)
        {
            return database.ExecuteNonQuery("AddViewed", obj.ViewId, obj.ProductId) > 0;
        }
    }
}
