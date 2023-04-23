using System.Net.Http.Headers;
namespace WebApp.Models
{
    public abstract class BaseRepositoryContext
    {
        protected WatchStoreContext context;
        public BaseRepositoryContext(WatchStoreContext context)
        {
            this.context = context;
        }
        public async Task<Out> Post<In, Out>(string url, In obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351/");
                HttpResponseMessage message = await client.PostAsJsonAsync(url, obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<Out>();
                }
                return default(Out);
            }
        }
        public async Task<Out> Put<In, Out>(string url, In obj)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44351");
                HttpResponseMessage message = await client.PutAsJsonAsync(url, obj);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<Out>();
                }
                return default(Out);
            }
        }
        public async Task<T> Get<T>(string url, string token = null)
        {
            return await Fetch<T>(url, new StrategyGet(), token);
        }
        public async Task<T> Delete<T>(string url, string token = null)
        {
            return await Fetch<T>(url, new StrategyDelete(), token);
        }
        protected async Task<T> Fetch<T>(String url, StrategyFetch strategy, string token = null)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = new Uri("https://localhost:44376");
                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }
                HttpResponseMessage message = await strategy.Execute(client, url);
                if (message.IsSuccessStatusCode)
                {
                    return await message.Content.ReadFromJsonAsync<T>();
                }
                return default(T);
            }
        }

    }
}
