using Delivary.Application.Interfaces;
using Delivary.Application.Models;
using Delivary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Delivary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService) => _orderService = orderService;

        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <param name="order">Модель заказа</param>
        /// <returns>Модель заказа</returns>
        /// <response code="200">Модель заказа</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpPost]
        public async Task<ActionResult<Order>> Create(OrderDTO order)
        {
            return await _orderService.Create(order);
        }

        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns>Список заказов</returns>
        /// <response code="200">Список заказов</response>
        /// <response code="400">Ошибка запроса</response>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAll()
        {
            return await _orderService.GetAll();
        }
    }
}
