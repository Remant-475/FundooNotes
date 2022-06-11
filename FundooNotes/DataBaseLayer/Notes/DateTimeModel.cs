using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBaseLayer.Notes
{
    public class DateTimeModel
    {
        [Required]
        public DateTime Reminder { get; set; }
    }
}
