using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.SuperModels
{
    public abstract class Content
    {
        public int Id { get; set; }

        public virtual IList<Metadata> Metadata
        {
            get
            {
                return metadata ?? (metadata = new List<Metadata>());
            }
            set
            {
                metadata = value;
            }
        }
        private IList<Metadata> metadata;
        
        public virtual IList<Reference> References
        {
            get
            {
                return reference ?? (reference = new List<Reference>());
            }
            set
            {
                reference = value;
            }
        }
        private IList<Reference> reference;
    }
}
