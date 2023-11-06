using System;
using System.Collections.Generic;
using System.Text;

namespace TraVeL.Core.Models
{
    public class DestinationModel
    {
        public byte Id { get; set; } // Primary Key
        public string location_name { get; set; }
        public string address { get; set; }
        public int number_of_passenger { get; set; }
    }
}
