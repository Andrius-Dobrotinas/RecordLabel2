using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public interface IRepository : IDisposable
    {
        void SaveModel<TModel>(TModel model) where TModel : class;

        Release[] GetAllReleases();

        Release GetReleaseComplete(int id);

        Release GetRelease(int id);

        Artist[] GetArtistList();

        MediaType[] GetMediaTypeList();

        Metadata[] GetMetadataList();
    }
}