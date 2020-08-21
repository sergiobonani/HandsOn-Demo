using AutoMapper;
using EntityFrameworkCoreMock;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Demo.Application.Interfaces;
using Demo.Application.Services;
using Demo.Application.ViewModels;
using Demo.Domain.Entity;
using Demo.Infra;
using Demo.Infra.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Demo.Application.Tests
{
    public class ClientServiceTests
    {
        public Mock<ClientService> MockClient()
        {
            var mm = new Mock<IMapper>().Object;
            var mock = new Mock<ClientService>(MockClientRepository().Object, mm);

           // mock.Setup(x => x.Add(ClientServiceDataTests.GetClient())).Returns(new ViewModels.Notifications.ResultWrap<ClientViewModel>().SetSuccess());

            return mock;
        }

        public Mock<ClientRepository> MockClientRepository()
        {
            var dbContextMock = new DbContextMock<TestDbContext>();
            var usersDbSetMock = dbContextMock.CreateDbSetMock(x => x.Client, ClientServiceDataTests.GetEntitiesClient());
            var mock = new Mock<ClientRepository>(dbContextMock.Object);
            return mock;
        }

        public class TestDbContext : DbContext
        {
            public TestDbContext(DbContextOptions<TestDbContext> options)
                : base(options)
            {
            }

            public virtual DbSet<Client> Client { get; set; }
        }

        [Fact]
        public void AddNewClientSucess()
        {
            var service = MockClient().Object;

            var newEntity = ClientServiceDataTests.GetClient();

            var result = service.Add(newEntity);

            result.IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData("João", "", "F", "12345897", "Rua um", "123", "Complemento", "Zona 1", "Paraná", "Maringá")]
        public void AddNewClientWithInvalidFields(string name, DateTime dateOfBirth, string gender, string zipCode,
            string address, string addressNumber, string complement, string district, string state, string city)
        {
            var service = MockClient().Object;

            var newEntity = new ClientViewModel { 
                Name = name, 
                DateOfBirth = dateOfBirth, 
                Gender = gender, 
                ZipCode = zipCode,
                Address = address,
                AddressNumber = addressNumber,
                Complement = complement,
                District = district,
                State = state,
                City = city
            };

            var result = service.Add(newEntity);

            result.IsSuccess.Should().BeFalse();
            result.Errors.Count.Should().NotBe(0);
        }


        [Fact]
        public void UpdateClientSucess()
        {
            var service = MockClient().Object;

            var newEntity = ClientServiceDataTests.GetClientForUpdate();

            var result = service.Update(newEntity);

            result.IsSuccess.Should().BeTrue();
        }

    }

    public enum TestedItem
    {
        name, dateOfBirth, gender, zipCode, address, addressNumber, complement, district, state, city
    }
}
