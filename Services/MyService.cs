using Microsoft.Extensions.Options;
using OptionMangApi.Models;

namespace OptionMangApi.Services
{
    public class MyService
    {
        private readonly IOptionsSnapshot<MyAppSettings> _settings;

        public MyService(IOptionsSnapshot<MyAppSettings> settings)
        {
            _settings = settings;
        }

        public void DisplaySettings()
        {
            var setting1 = _settings.Value.Setting1;
            var setting2 = _settings.Value.Setting2;
            Console.WriteLine($"Setting1: {setting1}, Setting2: {setting2}");
        }
    }
}
