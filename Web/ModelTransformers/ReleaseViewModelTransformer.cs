using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AndrewD.RecordLabel.Web
{
    public class ReleaseViewModelTransformer
    {
        public ReleaseViewModel Transform(Release model)
        {
            var youtubeRefs = model.References?.Where(x => x.Type == ReferenceType.Youtube).ToArray();

            if (model.References != null && youtubeRefs.Length > 0)
            {
                model.References = model.References.Except(youtubeRefs).ToArray();
            }

            return new ReleaseViewModel
            {
                Release = model,
                YoutubeReferences = youtubeRefs
            };
        }
    }
}