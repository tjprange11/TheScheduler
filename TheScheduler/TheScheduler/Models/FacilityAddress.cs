﻿using System.ComponentModel.DataAnnotations;

namespace TheScheduler.Models
{
    public class FacilityAddress
    {
        [Key]
        public int ID { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}