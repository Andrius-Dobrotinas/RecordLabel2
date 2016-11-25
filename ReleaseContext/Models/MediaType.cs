using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AndrewD.RecordLabel.Data.EF
{
    public class MediaType
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }
    }
}
