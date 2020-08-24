using AutoMapper;
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
using EntityFrameworkCore3Mock;

namespace Demo.Application.Tests
{
    public class ClientServiceTests
    {
        public Mock<ClientService> MockClient()
        {
            var mock = new Mock<ClientService>(MockClientRepository().Object, MockMapper().Object);

            //mock.Setup(x => x.Add(It.IsAny<ClientViewModel>())).Returns(new ViewModels.Notifications.ResultWrap<ClientViewModel>().SetSuccess());

            return mock;
        }

        public Mock<IMapper> MockMapper()
        {
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<ClientViewModel, Client>(It.IsAny<ClientViewModel>())).Returns(ClientServiceDataTests.GetEntitiesClient().First());

            return mapperMock;
        }


        public Mock<ClientRepository> MockClientRepository()
        {
            var context = new Mock<ApplicationDbContext>();
            var set = new Mock<DbSet<Client>>();

            context.Setup(c => c.Set<Client>()).Returns(set.Object);
            var mock = new Mock<ClientRepository>(null);

            //var teste = new Mock<RepositoryBase<Client>>();
            //teste.Setup(x => x.Add(It.IsAny<Client>()));

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
              .UseInMemoryDatabase(databaseName: "HandsOn")
              .Options;

            using (var contexta = new ApplicationDbContext(options))
            {
                contexta.Client.Add(ClientServiceDataTests.GetEntityClient());


                contexta.SaveChanges();
            }

            return mock;
        }

        public class TestDbContext : DbContext
        {
            public TestDbContext(DbContextOptions<TestDbContext> options)
                : base(options)
            {
            }

            public virtual FakeDbSet<Client> Client { get; set; }
            public virtual FakeDbSet<Address> Address { get; set; }
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
                Address = new AddressViewModel 
                { 
                    ZipCode = zipCode,
                    AddressDescription = address,
                    AddressNumber = addressNumber,
                    Complement = complement,
                    District = district,
                    State = state,
                    City = city
                }
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
