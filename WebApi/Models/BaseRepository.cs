namespace WebApi.Models
{
    public abstract class BaseRepository
    {
        protected WatchStoreContext context;
        public BaseRepository(WatchStoreContext context)
        {
            this.context = context;
        }
    }
}
