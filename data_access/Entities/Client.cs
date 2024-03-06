﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using data_access.Entities;

namespace EntityFramoworkCore.Entities
{
    [Table("Passangers")]

    public class Client
    {
        //foreign key and primary key
        public int Id { get; set; }//not null

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }

        public ICollection<Flight> Flights { get; set; }

        //one to one
        public Credentials Credentials { get; set; }//null

    }
}
