using Microsoft.AspNetCore.Mvc;
using OptionMangApi.Services;

namespace OptionMangApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ItemMonitorController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemMonitorController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetItemApiUrl()
        {
            return Ok(new
            {
                ApiUrl = _itemService.GetApiUrl()
            });
        }
    }
}
