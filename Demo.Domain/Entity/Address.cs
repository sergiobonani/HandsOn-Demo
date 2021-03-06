﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Demo.Domain.Entity
{
    public class Address : EntityBase
    {
        public Guid ClientId { get; set; }

        public string ZipCode { get; set; }

        public string AddressDescription { get; set; }

        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string District { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
