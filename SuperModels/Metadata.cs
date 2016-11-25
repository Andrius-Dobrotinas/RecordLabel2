using System;
using System.Collections.Generic;
using System.Linq;
using AndrewD.RecordLabel;

namespace AndrewD.RecordLabel.SuperModels
{
    public class Metadata
    {
        public int Id { get; set; }

        public MetadataType Type { get; set; }

        public string Text { get; set; }
    }
}
