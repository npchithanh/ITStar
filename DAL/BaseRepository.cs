using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DAL
{
    public class BaseRepository
    {
        protected DatabaseProviderFactory factory = new DatabaseProviderFactory();
        protected Database database;
        internal BaseRepository()
        {
            database = factory.Create("ITStar");
        }
    }
}
