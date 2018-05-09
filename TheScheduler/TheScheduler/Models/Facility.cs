using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheScheduler.Models
{
    public class Facility
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("FacilityAddress")]
        public int FacilityAddressId { get; set; }
        public FacilityAddress FacilityAddress { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        public string Name { get; set; }
        public string Sport { get; set; }
        public bool Indoor { get; set; }

    }
}