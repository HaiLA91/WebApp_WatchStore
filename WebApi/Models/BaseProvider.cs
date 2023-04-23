namespace WebApi.Models
{
    public class BaseProvider : IDisposable
    {
        WatchStoreContext context;
        protected WatchStoreContext Context
        {
            get
            {
                if(context is null)
                {
                    context = new WatchStoreContext();
                }
                return context;
            }
        }
        public void Dispose()
        {
            if(context != null)
            {
                context.Dispose();
            }
        }
    }
}
