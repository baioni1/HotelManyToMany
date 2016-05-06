using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManyToManyMVC.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; }
        public decimal Price { get; set; }
        public int MaxCapacity { get; set; }
    }
}