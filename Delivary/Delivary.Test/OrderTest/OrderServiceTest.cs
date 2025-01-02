using Delivary.Application.Exceptions;
using Delivary.Application.Models;
using Delivary.Application.Services;
using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;
using Delivary.Infrastructure;
using Delivary.Test.CustomerTest;
using Delivary.Test.PizzaTest;

namespace Delivary.Test.OrderTest
{
    [Collection("Database collection")]
    public class OrderServiceTest
    {
        private readonly TestDataFixture _fixture;
        public OrderServiceTest(TestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Create_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);
            var order = new OrderDTO
            {
                Address = new Address("Address", "Address"),
                CreatedDate = DateTime.Now,
                CustomerId = CustomerData.Get()[1].Id,
                Pizzas = new List<OrderItemDTO>
                {
                    new OrderItemDTO
                    {
                        Count = 1,
                        PizzaId = PizzaData.Id,
                    }
                }

            };

            //act
            var result = await service.Create(order);
            //assert
            Assert.NotEqual(result.Id, Guid.Empty);
        }

        [Fact]
        public async Task GetAll_sucessfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);
            //act
            var result = await service.GetAll();
            //assert
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.NotNull(x.Customer));
            //Assert.All(result, x => Assert.NotEmpty(x.Pizzas));
        }

        [Fact]
        public async Task GetById_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);

            //act
            var orders = await service.GetAll();
            var result = await service.GetById(orders[0].Id);

            //assert
            Assert.Equal(result.Id, orders[0].Id);
        }


        [Fact]
        public async Task GetById_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);

            //act
            var act = async() => await service.GetById(Guid.NewGuid());

            //assert
            await Assert.ThrowsAsync<AppException>(async () => await act());
        }


        [Fact]
        public async Task Delete_sucessfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);

            //act
            var result = await service.Delete(OrderData.Id);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);

            //act
            var act = async () => await service.Delete(Guid.NewGuid());

            //assert
            await Assert.ThrowsAsync<AppException>(async () => await act());
        }

        [Fact]
        public async Task Edit_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var customerService = new CustomerService(context, Configuration.GetAutoMapper());
            var service = new OrderService(context, Configuration.GetAutoMapper(), customerService);

            //act
            var order = OrderData.Get()[3];
            order.Completed = true;
            order.CompletionDate = DateTime.Now;

            var response = await service.Edit(order);
            var model = await service.GetById(order.Id);

            //assert
            Assert.Equal(model.Id, order.Id);
            Assert.True(model.Completed);
        }
    }
}
