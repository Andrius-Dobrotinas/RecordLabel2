﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class ReleaseService : IReleaseService
    {
        private IRepository repository;
        private EntityToModelTransformer entityTransformer;
        private ModelToEntityTransformer modelTransformer;

        private Func<int, int, int> CalculateBatchCount = 
            (total, perPage) => (int)Math.Ceiling((decimal)total / (decimal)perPage);

        public ReleaseService()
        {
            // TODO: DI these guys
            repository = new Repository();
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
                    repository.Dispose();
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
            var dbModel = repository.GetReleaseComplete(id);
            return dbModel != null ? entityTransformer.GetReleaseComplete(dbModel) : null;
        }

        public AndrewD.RecordLabel.ReleaseSlim GetReleaseSlim(int id)
        {
            var dbModel = repository.GetRelease(id);
            return dbModel != null ? entityTransformer.GetReleaseSlim(dbModel) : null;
        }

        public AndrewD.RecordLabel.Release[] GetReleases()
        {
            return TransformReleases(
                repository.GetAllReleases(q => q.OrderByDescending(x => x.Date)));
        }

        public BatchedResult<AndrewD.RecordLabel.Release> GetReleases(int batch, int itemsPerBatch)
        {
            var releases = TransformReleases(
                repository.GetAllReleases(batch, itemsPerBatch, q => q.OrderByDescending(x => x.Date)));
            var total = repository.TotalReleaseCount();
            var batchCount = CalculateBatchCount(total, itemsPerBatch);

            return new BatchedResult<RecordLabel.Release>
            {
                Entries = releases,
                BatchCount = batchCount
            };
        }

        private AndrewD.RecordLabel.Release[] TransformReleases(Release[] releases)
        {
            return entityTransformer.GetList(releases, entityTransformer.GetReleaseComplete);
        }

        public AndrewD.RecordLabel.ArtistBarebones[] GetArtistBarebonesList()
        {
            var dbModel = repository.GetArtistList();
            return dbModel != null ? entityTransformer.GetList(dbModel, entityTransformer.GetArtistBareBones) : null;
        }

        public AndrewD.RecordLabel.MediaType[] GetMediaTypeList()
        {
            var dbModel = repository.GetMediaTypeList();
            return entityTransformer.GetList(dbModel, entityTransformer.GetMediaType);
        }

        public AndrewD.RecordLabel.Metadata[] GetMetadataList()
        {
            var dbModel = repository.GetMetadataList();
            return entityTransformer.GetList(dbModel, entityTransformer.GetMetadata);
        }

        public void Save(AndrewD.RecordLabel.ReleaseSlim model)
        {
            var dbModel = modelTransformer.GetRelease(model);
            SaveModel(dbModel);
        }

        private void SaveModel<TModel>(TModel dbModel) where TModel : class
        {
            repository.SaveModel<TModel>(dbModel);
        }
    }
}