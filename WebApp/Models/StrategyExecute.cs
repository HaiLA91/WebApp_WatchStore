namespace WebApp.Models
{
    public interface StrategyExecute
    {
        Task<HttpResponseMessage> Execute(HttpClient client, string url);
    }
    public class SaveExecute<T> : StrategyExecute
    {
        StrategySave strategy;
        T obj;
        public SaveExecute(StrategySave strategy, T obj)
        {
            this.strategy = strategy;
            this.obj = obj;
        }
        public Task<HttpResponseMessage> Execute(HttpClient client, string url)
        {
            return strategy.Execute(client, url, obj);
        }
    }
    public class FetchExecute : StrategyExecute
    {
        StrategyFetch strategy;
        public FetchExecute(StrategyFetch strategy)
        {
            this.strategy = strategy;
        }
        public Task<HttpResponseMessage> Execute(HttpClient client, string url)
        {
            return strategy.Execute(client, url);
        }
    }
}

