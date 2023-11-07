using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TraVeL.Core.Models
{
    public class DestinationModel
    {
        [Key] // Marks the Id property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; } // Primary Key
        public string location_name { get; set; }
        public string address { get; set; }
        public string number_of_passenger { get; set; }
    }
}
