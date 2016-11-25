using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data
{
    public interface IRepositoryProxy : IDisposable
    {
        Release GetReleaseComplete(int id);
        ReleaseSlim GetReleaseSlim(int id);
        Release[] GetReleases();
        ArtistBarebones[] GetArtistBarebonesList();
        MediaType[] GetMediaTypeList();
        Metadata[] GetMetadataList();
        void Save(ReleaseSlim model);
    }
}
