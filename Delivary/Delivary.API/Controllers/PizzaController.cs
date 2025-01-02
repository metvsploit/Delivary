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
        /// <response code="200">Модель пиццы</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPost]
        public async Task<ActionResult<Pizza>> Create(PizzaDTO model)
        {
            return await _service.Create(model);
        }

        /// <summary>
        /// Удалить пиццу
        /// </summary>
        /// <param name="id">Идентификатор пиццы</param>
        /// <returns>Успешно/неуспешно</returns>
        /// <response code="200">true/false</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// Изменить пиццу
        /// </summary>
        /// <param name="model">Модель пиццы</param>
        /// <returns>Успешно/неуспешно</returns>
        /// <response code="200">true/false</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPut]
        public async Task<ActionResult<bool>> Edit(Pizza model)
        {
            return await _service.Edit(model);
        }

        /// <summary>
        /// Получить все пиццы
        /// </summary>
        /// <returns>Список пицц</returns>
        /// <response code="200">Список пицц</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet]
        public async Task<ActionResult<List<Pizza>>> GetAll()
        {
            return await _service.GetAll();
        }

        /// <summary>
        /// Получить пиццу по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пиццы</param>
        /// <returns>Пицца</returns>
        /// <response code="200">Пицца</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetById(Guid id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// Получить пиццы по пагинации
        /// </summary>
        /// <param name="page">Номер страницы</param>
        /// <param name="size">Количество возвращаемых пицц</param>
        /// <returns>Список пицц</returns>
        /// <response code="200">Список пицц</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet("{page}/{size}")]
        public async Task<ActionResult<List<Pizza>>> GetByPagination(int page, int size)
        {
            return await _service.GetByPagination(page, size);
        }

        /// <summary>
        /// Получить пиццы по префиксу
        /// </summary>
        /// <param name="prefix">Префикс</param>
        /// <returns>Список пицц</returns>
        /// <response code="200">Список пицц</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet("{prefix}")]
        public async Task<ActionResult<List<Pizza>>> GetByPrefix(string prefix)
        {
            return await _service.GetByPrefix(prefix);
        }
    }
}
