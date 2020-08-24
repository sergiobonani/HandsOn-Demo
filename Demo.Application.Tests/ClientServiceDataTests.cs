using Demo.Application.ViewModels;
using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Application.Tests
{
    internal static class ClientServiceDataTests
    {
        internal static Guid _id1 = Guid.NewGuid();
        internal static Guid _id2 = Guid.NewGuid();

        internal static ClientViewModel GetClient()
            => new ClientViewModel
            {
                Name = "Ana Maria",
                DateOfBirth = new DateTime(1990, 01, 25),
                Gender = "F",
                Address = GetAddress()
            };

        internal static ClientViewModel GetClientForUpdate()
            => new ClientViewModel
            {
                Id = _id1,
                Name = "Ana Maria",
                DateOfBirth = new DateTime(1990, 01, 25),
                Gender = "F",
                Address = GetAddress()
            };

        internal static AddressViewModel GetAddress()
            => new AddressViewModel
            {
                AddressDescription = "Rua um",
                AddressNumber = "123",
                City = "Maringá",
                Country = "Brasil",
                District = "Zona 1",
                State = "PR",
                ZipCode = "8700000"
            };

        internal static FakeDbSet<Client> GetDbSetClients()
            => new FakeDbSet<Client>
            {
                GetEntitiesClient().First()
            };

        internal static List<Client> GetEntitiesClient()
            => new List<Client>
            {
                new Client
                {
                    Id = _id1,
                    Name = "Ana Maria",
                    DateOfBirth = new DateTime(1990, 01, 25),
                    Gender = "F",
                    Address = GetEntityAddress()
                },
                new Client
                {
                    Id = _id2,
                    Name = "Ana Maria 2",
                    DateOfBirth = new DateTime(1990, 01, 25),
                    Gender = "F",
                    Address = GetEntityAddress()
                }
            };

        internal static Address GetEntityAddress()
            => new Address
            {
                Id = new Guid(),
                AddressDescription = "Rua são joão",
                AddressNumber = "123",
                City = "Maringá",
                Country = "Brasil",
                District = "Zona 1",
                State = "PR",
                ZipCode = "87000000"
            };

        internal static Client GetEntityClient()
            => new Client
                {
                    Id = _id1,
                    Name = "AAA1234"
                };
    }
}
