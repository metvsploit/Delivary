using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Delivary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Создать пиццу
        /// </summary>
        /// <param name="model">Модель пиццы</param>
        /// <returns>Модель пиццы</returns>
        /// <response code="200">true/false</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPost]
        public async Task<ActionResult<Pizza>> Create(PizzaDTO model)
        {
            return await _service.Create(model);
        }
    }
}
