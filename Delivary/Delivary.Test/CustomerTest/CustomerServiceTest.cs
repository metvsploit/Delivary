using Delivary.Application.Exceptions;
using Delivary.Application.Models;
using Delivary.Application.Services;
using Delivary.Domain.Entities;
using Delivary.Domain.ValueObjects;
using Delivary.Infrastructure;

namespace Delivary.Test.CustomerTest
{
    [Collection("Database collection")]
    public class CustomerServiceTest
    {
        private readonly TestDataFixture _fixture;
        public CustomerServiceTest(TestDataFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Create_successfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new CustomerService(context, Configuration.GetAutoMapper());
            var customer = new CustomerDTO
            {
                Name = new Name("Customer_Test", "Customer_Test"),
                
            };

            //act
            var result = await service.Create(customer);
            //assert
            Assert.NotEqual(result.Id, Guid.Empty);
            Assert.Equal(result.Name, customer.Name);
        }

        [Fact]
        public async Task GetAll_sucessfull()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new CustomerService(context, Configuration.GetAutoMapper());
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
            var service = new CustomerService(context, Configuration.GetAutoMapper());

            //act
            var customers = await service.GetAll();
            var result = await service.GetById(customers[0].Id);

            //assert
            Assert.Equal(result.Id, customers[0].Id);
        }


        [Fact]
        public async Task GetById_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new CustomerService(context, Configuration.GetAutoMapper());

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
            var service = new CustomerService(context, Configuration.GetAutoMapper());

            //act
            var result = await service.Delete(CustomerData.Id);

            //assert
            Assert.True(result);
        }

        [Fact]
        public async Task Delete_notFound()
        {
            //arrange
            using var context = new PizzaDbContext(_fixture.PizzaOptions);
            var service = new CustomerService(context, Configuration.GetAutoMapper());

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
            var service = new CustomerService(context, Configuration.GetAutoMapper());

            //act
            var customer = new Customer
            {
                Id = CustomerData.Id,
                Name = new Name("Test", "Test"),
            };

            var response = await service.Edit(customer);
            var model = await service.GetById(customer.Id);

            //assert
            Assert.Equal(model.Id, customer.Id);
            Assert.Equal(model.Name, customer.Name);
        }
    }
}
