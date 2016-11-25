using AndrewD.RecordLabel.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class RepositoryProxy : IRepositoryProxy
    {
        private Repository context;
        private EntityToModelTransformer entityTransformer;
        private ModelToEntityTransformer modelTransformer;

        public RepositoryProxy()
        {
            // TODO: DI these guys
            context = new Repository();
            entityTransformer = new EntityToModelTransformer();
            modelTransformer = new ModelToEntityTransformer();
        }

        private bool isDisposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public AndrewD.RecordLabel.Release GetReleaseComplete(int id)
        {
            var dbModel = context.GetReleaseComplete(id);
            return dbModel != null ? entityTransformer.GetReleaseComplete(dbModel) : null;
        }

        public AndrewD.RecordLabel.ReleaseSlim GetReleaseSlim(int id)
        {
            var dbModel = context.GetRelease(id);
            return dbModel != null ? entityTransformer.GetReleaseSlim(dbModel) : null;
        }

        public AndrewD.RecordLabel.Release[] GetReleases()
        {
            var dbModel = context.GetAllReleases();           
            return entityTransformer.GetList(dbModel, entityTransformer.GetReleaseComplete);
        }

        public AndrewD.RecordLabel.ArtistBarebones[] GetArtistBarebonesList()
        {
            var dbModel = context.GetArtistList();
            return dbModel != null ? entityTransformer.GetList(dbModel, entityTransformer.GetArtistBareBones) : null;
        }

        public AndrewD.RecordLabel.MediaType[] GetMediaTypeList()
        {
            var dbModel = context.GetMediaTypeList();
            return entityTransformer.GetList(dbModel, entityTransformer.GetMediaType);
        }

        public AndrewD.RecordLabel.Metadata[] GetMetadataList()
        {
            var dbModel = context.GetMetadataList();
            return entityTransformer.GetList(dbModel, entityTransformer.GetMetadata);
        }

        public void Save(AndrewD.RecordLabel.ReleaseSlim model)
        {
            var dbModel = modelTransformer.GetRelease(model);
            context.SaveModel<Release>(dbModel);
        }
    }
}