using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheScheduler.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }

        [ForeignKey("Consumer")]
        public int ConsumerId { get; set; }
        public Consumer Consumer { get; set; }

        public bool Accepted { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool Completed { get; set; }
    }
}