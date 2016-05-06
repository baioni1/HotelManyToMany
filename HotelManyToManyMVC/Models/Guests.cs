using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManyToManyMVC.Models
{
    public class Guests
    {
        [Key]
        public int GuestID { get; set; }        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Occupancy { get; set; }
    }
}