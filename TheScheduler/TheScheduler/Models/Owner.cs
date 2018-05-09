using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheScheduler.Models
{
    public class Owner
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
    }
}