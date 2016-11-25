using System;

namespace AndrewD.RecordLabel.SuperModels
{
    public class Reference
    {
        public int Id { get; set; }

        public string Target { get; set; }
        
        public ReferenceType Type { get; set; }

        public int Order { get; set; }
    }
}