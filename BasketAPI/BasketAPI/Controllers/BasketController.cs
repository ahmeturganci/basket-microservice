using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BasketAPI.Models.ViewModel;
using BasketAPI.Services.Implementations;

namespace BasketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _service;

        public BasketController(IBasketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBaskets()
        {
            var response = await _service.GetBasketsAsync();
            if (response == null)
            {
                return BadRequest();
            }

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost, Route("AddBasket")]
        public async Task<IActionResult> AddBasket([FromBody] AddBasketRequest request)
        {
            var response = await _service.AddBasketsAsync(request);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet, Route("BasketByUserName")]
        public async Task<IActionResult> GetTourById([FromBody] GetBasketByUserNameRequest request)
        {
            var response = await _service.GetBasketsByUserNameAsync(request);
            return StatusCode(response.StatusCode, response);
        }

    }
}
