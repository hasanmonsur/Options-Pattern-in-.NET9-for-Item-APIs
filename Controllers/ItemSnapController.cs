using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionMangApi.Models;
using OptionMangApi.Services;

namespace OptionMangApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemSnapController : ControllerBase
    {
        private readonly MyService _myService;

        public ItemSnapController(MyService myService)
        {
            // IOptionsSnapshot gives the current settings for each request
                _myService = myService;
        }

        [HttpGet]
        public IActionResult GetItemSettings()
        {
            _myService.DisplaySettings();

            return Ok("Success");
        }
    }
}
