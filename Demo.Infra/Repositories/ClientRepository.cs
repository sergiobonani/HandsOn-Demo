using Demo.Domain.Entity;
using Demo.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infra.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public readonly ApplicationDbContext _contex;

        public ClientRepository(ApplicationDbContext context): base(context) 
        {
            _contex = context;
        }

        public new Client GetById(Guid id)
        {
            return _contex.Client.Include(x => x.Address).FirstOrDefaultAsync(y => y.Id == id).Result;
        }
    }
}
