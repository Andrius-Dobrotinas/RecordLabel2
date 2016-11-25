﻿using AndrewD.EntityPlus.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class Repository : IDisposable
    {
        private ReleaseContext context;
        private const string modelNamespace = "AndrewD.RecordLabel.Data.EF";
        private const string modelAssembly = "ReleaseContext";

        public Repository()
        {
            // TODO: DI
            context = new ReleaseContext("MainConnectionString");
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

        public void SaveModel<TModel>(TModel model) where TModel : class
        {
            IEntityChangesMerger<TModel> merger = null;
            if (typeof(TModel) == typeof(Release))
                merger = (IEntityChangesMerger<TModel>)new ReleaseChangesMerger(context, modelNamespace, modelAssembly);
            else
                merger = new DefaultEntityChangesMerger<TModel>(context, modelNamespace, modelAssembly);

            merger.MergeEntityChanges(model);

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                // TODO
            }
            // TODO: exception handling
        }
        
        public Release[] GetAllReleases()
        {
            context.MediaTypes.Load();
            context.Artists.Load();
            return context.Releases.ToArray();
        }

        public Release GetReleaseComplete(int id)
        {
            return context.Releases.Include(x => x.Artist).Include(x => x.Media).FirstOrDefault(x => x.Id == id);
        }

        public Release GetRelease(int id)
        {
            return context.Releases.FirstOrDefault(x => x.Id == id);
        }

        public Artist[] GetArtistList()
        {
            return context.Artists.ToArray();
        }

        public MediaType[] GetMediaTypeList()
        {
            return context.MediaTypes.ToArray();
        }

        public Metadata[] GetMetadataList()
        {
            return context.Metadata.ToArray();
        }      
    }
}