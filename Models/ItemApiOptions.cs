namespace OptionMangApi.Models
{
    public class ItemApiOptions
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public int TimeoutSeconds { get; set; }
        public int CacheExpirationMinutes { get; set; }
    }
}
