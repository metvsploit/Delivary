using Delivary.Application.Services;
using Delivary.Infrastructure;

namespace Delivary.Test.PizzaTest
{
    public class PizzaServiceTest : IClassFixture<TestDataFixture>
    {
        private readonly TestDataFixture _fixture;
        public PizzaServiceTest(TestDataFixture fixture) { 
            _fixture = fixture;
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
            Assert.Equal(9, result.Count);
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
            var pizzas = await service.GetAll();
            var result = await service.GetById(pizzas[0].Id);

            //assert
            Assert.Null(result);
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
    }
}
