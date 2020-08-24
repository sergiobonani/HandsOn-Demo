using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Application.ViewModels
{
    public class ClientViewModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
