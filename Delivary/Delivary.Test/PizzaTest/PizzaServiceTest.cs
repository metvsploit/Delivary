using Delivary.Application.Exceptions;
using Delivary.Application.Models;
using Delivary.Application.Services;
using Delivary.Domain.Entities;
using Delivary.Infrastructure;

namespace Delivary.Test.PizzaTest
{
    [Collection("Database collection")]
    public class PizzaServiceTest
    {
        private readonly TestDataFixture _fixture;
        public PizzaServiceTest(TestDataFixture fixture) { 
            _fixture = fixture;
        }

        [Fact]
        public async Task Create_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());
            var pizza = new PizzaDTO
            {
                Description = "Pizza_Test",
                Name = "Pizza_Test",
                Price = 1,
            };

            //act
            var result = await service.Create(pizza);
            //assert
            Assert.NotEqual(result.Id, Guid.Empty);
            Assert.Equal(result.Name, pizza.Name);
            Assert.Equal(result.Description, pizza.Description);
            Assert.Equal(result.Price, pizza.Price);
        }

        [Fact]
        public async Task GetAll_sucessfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());
            //act
            var result = await service.GetAll();
            //assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task GetById_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var pizzas = await service.GetAll();
            var result = await service.GetById(pizzas[0].Id);

            //assert
            Assert.Equal(result.Id, pizzas[0].Id);
        }


        [Fact]
        public async Task GetById_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var result = await service.GetById(Guid.NewGuid());

            //assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByPagination_sucessfull()
        {

            //arrange
            int page = 1;
            int size = 2;
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var result = await service.GetByPagination(page, size);

            //assert
            Assert.Equal(result.Count, size);
        }

        [Fact]
        public async Task Delete_sucessfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var result = await service.Delete(PizzaData.Id);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var act = async() => await service.Delete(Guid.NewGuid());

            //assert
            await Assert.ThrowsAsync<AppException>(async() => await act());
        }

        [Fact]
        public async Task Edit_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new PizzaService(context, Configuration.GetAutoMapper());

            //act
            var pizza = new Pizza
            {
                Id = PizzaData.Id,
                Name = "Test",
                Description = "Test",
                Price = 2346
            };

            var response = await service.Edit(pizza);
            var model = await service.GetById(pizza.Id);

            //assert
            Assert.Equal(model.Id, pizza.Id);
            Assert.Equal(model.Name, pizza.Name);
            Assert.Equal(model.Description, pizza.Description);
        }


    }
}
