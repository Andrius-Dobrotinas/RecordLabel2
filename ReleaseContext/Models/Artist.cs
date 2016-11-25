using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewD.RecordLabel.Data.EF
{
    public class Artist : Content
    {
        [Required]
        public string Name { get; set; }

        public string Text { get; set; }
    }
}
