using System;
using System.ComponentModel.DataAnnotations;

namespace AndrewD.RecordLabel
{
    public class Reference
    {
        public int Id { get; set; }

        [Required]
        public string Target { get; set; }

        [Required]
        public ReferenceType Type { get; set; }

        public int Order { get; set; }
    }
}