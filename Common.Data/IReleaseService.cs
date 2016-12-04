using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data
{
    public interface IReleaseService : IDisposable
    {
        Release GetReleaseComplete(int id);
        ReleaseSlim GetReleaseSlim(int id);
        Release[] GetReleases();
        BatchedResult<Release> GetReleases(int batch, int itemsPerBatch);
        ArtistBarebones[] GetArtistBarebonesList();
        MediaType[] GetMediaTypeList();
        Metadata[] GetMetadataList();
        void Save(ReleaseSlim model);
    }
}
