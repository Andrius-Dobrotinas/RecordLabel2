using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data
{
    public interface IRepositoryProxy : IDisposable
    {
        SuperModels.Release GetReleaseComplete(int id);
        SuperModels.ReleaseSlim GetReleaseSlim(int id);
        SuperModels.Release[] GetReleases();
        SuperModels.ArtistBarebones[] GetArtistBarebonesList();
        SuperModels.MediaType[] GetMediaTypeList();
        SuperModels.Metadata[] GetMetadataList();
        void Save(SuperModels.ReleaseSlim model);
    }
}
