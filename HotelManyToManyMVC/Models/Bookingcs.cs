using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManyToManyMVC.Models
{
    public class Bookingcs
    {
        [Key]
        public int BookingID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GuestID { get; set; }
        public Guests CustomerName { get; set; }
        public int RoomID { get; set; }
        public Rooms Suite { get; set; }
    }
}