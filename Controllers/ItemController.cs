using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionMangApi.Models;

namespace OptionMangApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemApiOptions _itemApiOptions;

        public ItemController(IOptions<ItemApiOptions> itemApiOptions)
        {
            _itemApiOptions = itemApiOptions.Value;
        }

        [HttpGet]
        public IActionResult GetItemSettings()
        {
            return Ok(new
            {
                ApiKey = _itemApiOptions.ApiKey,
                BaseUrl = _itemApiOptions.BaseUrl,
                TimeoutSeconds = _itemApiOptions.TimeoutSeconds,
                CacheExpirationMinutes = _itemApiOptions.CacheExpirationMinutes
            });
        }
    }
}
