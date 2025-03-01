using Microsoft.Extensions.Options;
using OptionMangApi.Models;

namespace OptionMangApi.Services
{
    public class ItemService
    {
        private readonly IOptionsMonitor<ItemApiOptions> _itemApiOptionsMonitor;

        public ItemService(IOptionsMonitor<ItemApiOptions> itemApiOptionsMonitor)
        {
            _itemApiOptionsMonitor = itemApiOptionsMonitor;

            // Register a callback for changes in the configuration
            _itemApiOptionsMonitor.OnChange(options =>
            {
                // Handle configuration changes
                Console.WriteLine($"Configuration changed: {options.BaseUrl}");
            });
        }

        public string GetApiUrl()
        {
            // Get the current configuration value
            return _itemApiOptionsMonitor.CurrentValue.BaseUrl;
        }
    }
}
