using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class ModelToEntityTransformer
    {
        public List<TDbModel> GetList<TDbModel, TModel>(IList<TModel> modelList, Func<TModel, TDbModel> transformation)
        {
            var list = new List<TDbModel>(modelList.Count);
            foreach (var item in modelList)
            {
                list.Add(transformation(item));
            }
            return list.ToList();
        }

        public Release GetRelease(AndrewD.RecordLabel.ReleaseSlim model)
        {
            return new Release
            {
                Id = model.Id,
                ArtistId = model.ArtistId,
                CatalogueNumber = model.CatalogueNumber,
                Date = model.Date,
                MediaId = model.MediaId,
                Metadata = GetList(model.MetadataIds, GetMetadata),
                PrintStatus = model.PrintStatus,
                References = GetList(model.References, GetReference),
                Text = model.Text,
                Length = model.Length,
                Title = model.Title,
                Tracks = GetList(model.Tracks, GetTrack)
            };
        }
        
        public Metadata GetMetadata(AndrewD.RecordLabel.Metadata model)
        {
            return new Metadata
            {
                Id = model.Id,
                Text = model.Text,
                Type = model.Type
                //Targets TODO?
            };
        }

        public Metadata GetMetadata(int id)
        {
            return new Metadata
            {
                Id = id
            };
        }

        public Reference GetReference(AndrewD.RecordLabel.Reference model)
        {
            return new Reference
            {
                Id = model.Id,
                Order = model.Order,
                Target = model.Target,
                Type = model.Type
                //Owner TODO?
            };
        }

        public Track GetTrack(AndrewD.RecordLabel.Track model)
        {
            return new Track
            {
                Id = model.Id,
                Reference = model.Reference,
                Title = model.Title
                //Release, TODO?
                //ReleaseId
            };
        }
    }
}