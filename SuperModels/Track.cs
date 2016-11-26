using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewD.RecordLabel
{
    public class Track
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        // TODO: come up with constraints?
        public string Reference { get; set; }
    }
}
