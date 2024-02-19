
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramoworkCore.Entities
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string DepartureCity { get; set; }
        [Required, MaxLength(100)]
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }


        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }
        public ICollection<Client> Clients { get; set; }

    }
}
