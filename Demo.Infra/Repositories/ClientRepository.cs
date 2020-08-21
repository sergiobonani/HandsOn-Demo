using Demo.Domain.Entity;
using Demo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infra.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context): base(context) { }
    }
}
