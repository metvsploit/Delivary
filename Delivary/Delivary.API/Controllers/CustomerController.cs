using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Delivary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) { 
            _customerService = customerService;
        }

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="customer">Клиент</param>
        /// <returns>Модель клиента</returns>
        /// <response code="200">Модель клиента</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPost]
        public async Task<ActionResult<Customer>> Create(CustomerDTO customer)
        {
            return await _customerService.Create(customer);
        }

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <returns>Успешно/неуспешно</returns>
        /// <response code="200">Успешно/неуспешно</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _customerService.Delete(id);
        }

        /// <summary>
        /// Редактировать клиента
        /// </summary>
        /// <param name="customer">Клиент</param>
        /// <returns>Успешно/неуспешно</returns>
        /// <response code="200">Успешно/неуспешно</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPut]
        public async Task<ActionResult<bool>> Edit(Customer customer)
        {
            return await _customerService.Edit(customer);
        }

        /// <summary>
        /// Получить всех клиентов
        /// </summary>
        /// <returns>Список клиентов</returns>
        /// <response code="200">Список клиентов</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return await _customerService.GetAll();
        }

        /// <summary>
        /// Получить клиента
        /// </summary>
        /// <param name="id">Идентификатор клиента</param>
        /// <returns>Модель клиента</returns>
        /// <response code="200">Модель клиента</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetById(Guid id)
        {
            return await _customerService.GetById(id);
        }
    }
}
