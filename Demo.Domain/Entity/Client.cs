using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Domain.Entity
{
    public class Client : EntityBase
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public Address Address { get; set; }

        //public string ZipCode { get; set; }

        //public string Address { get; set; }

        //public string AddressNumber { get; set; }

        //public string Complement { get; set; }

        //public string District { get; set; }

        //public string State { get; set; }

        //public string City { get; set; }

        //public string Country { get; set; }
    }
}
