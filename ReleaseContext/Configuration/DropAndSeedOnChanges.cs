using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AndrewD.RecordLabel.Data.EF.Configuration
{
    public class DropAndSeedOnChanges<T> : DropCreateDatabaseIfModelChanges<T> where T : ReleaseContext
    {
        protected override void Seed(T db)
        {
            ContextSeed.Seed(db);
            base.Seed(db);
        }
    }
}
