using Demo.Application.ViewModels;
using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
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
                Name = "AAA1234"
            };

        internal static ClientViewModel GetClientForUpdate()
            => new ClientViewModel
            {
                Id = _id1,
                Name = "AAA1234"
            };

        internal static List<Client> GetEntitiesClient()
            => new List<Client>
            {
                new Client
                {
                    Id = _id1,
                    Name = "AAA1234"
                },
                new Client
                {
                    Id = _id2,
                    Name = "BBB1234"
                }
            };

        internal static Client GetEntityClient()
            => new Client
                {
                    Id = _id1,
                    Name = "AAA1234"
                };
    }
}
