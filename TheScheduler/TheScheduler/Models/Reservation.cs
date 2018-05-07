using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheScheduler.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Facility")]
        public int Facility_ID { get; set; }
        public Facility Facility { get; set; }
        [ForeignKey("Consumer")]
        public int Consumer_ID { get; set; }
        public Consumer Consumer { get; set; }
        public bool Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}