using Demo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Application.Interfaces
{
    public interface IClientValidation
    {
        void Validate(Client client);
    }
}
