using System;
using System.Collections.Generic;
using System.Linq;
using AndrewD.EntityPlus.Persistence;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class ReleaseChangesMerger : DefaultEntityChangesMerger<Release>
    {
        public ReleaseChangesMerger(ReleaseContext dbContext, string modelsNamespace, string modelAssemblyName)
            : base(dbContext, modelsNamespace, modelAssemblyName)
        {
        }

        protected override void OnMergeChanges(Release updatedEntity, Release model)
        {
            MergeCollectionProperty<Track>(updatedEntity, model, x => x.Tracks, System.Data.Entity.Core.Metadata.Edm.OperationAction.Cascade, true);
        }
    }
}
