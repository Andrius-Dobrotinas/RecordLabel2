using System;
using System.Collections.Generic;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public interface IRepository : IDisposable
    {
        void SaveModel<TModel>(TModel model) where TModel : class;

        Release[] GetAllReleases(OrderByFunc<Release> orderBy);
        Release[] GetAllReleases(int batch, int itemsPerBatch, OrderByFunc<Release> orderBy);

        int TotalReleaseCount();

        Release GetReleaseComplete(int id);

        Release GetRelease(int id);

        Artist[] GetArtistList();

        MediaType[] GetMediaTypeList();

        Metadata[] GetMetadataList();
    }
}