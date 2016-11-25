using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel
{
    public abstract class ContentSlim
    {
        public int Id { get; set; }

        public IList<int> MetadataIds
        {
            get
            {
                return metadataIds ?? (metadataIds = new List<int>());
            }
            set
            {
                metadataIds = value;
            }
        }
        private IList<int> metadataIds;

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
