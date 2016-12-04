using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel.Data.EF.Access
{
    public class EntityToModelTransformer
    {
        private Func<IList<Metadata>, int[]> ExtractMetadataIds = metadata => metadata.Select(x => x.Id).ToArray();

        public TModel[] GetList<TModel, TDbModel>(IList<TDbModel> dbModelList, Func<TDbModel, TModel> transformation)
        {
            var list = new List<TModel>(dbModelList.Count);
            foreach (var item in dbModelList)
            {
                list.Add(transformation(item));
            }
            return list.ToArray();
        }

        public AndrewD.RecordLabel.MediaType GetMediaType(MediaType dbModel)
        {
            return new AndrewD.RecordLabel.MediaType
            {
                Id = dbModel.Id,
                Text = dbModel.Text
            };
        }

        public AndrewD.RecordLabel.Reference GetReference(Reference dbModel)
        {
            if (dbModel == null) return null;
            return new AndrewD.RecordLabel.Reference
            {
                Id = dbModel.Id,
                Order = dbModel.Order,
                Target = dbModel.Target,
                Type = dbModel.Type
            };
        }

        public AndrewD.RecordLabel.Metadata GetMetadata(Metadata dbModel)
        {
            return new AndrewD.RecordLabel.Metadata
            {
                Id = dbModel.Id,
                Text = dbModel.Text,
                Type = dbModel.Type
            };
        }

        public AndrewD.RecordLabel.Track GetTrack(Track dbModel)
        {
            return new AndrewD.RecordLabel.Track
            {
                Id = dbModel.Id,
                Reference = dbModel.Reference,
                Title = dbModel.Title
            };
        }

        public AndrewD.RecordLabel.Artist GetArtistComplete(Artist dbModel)
        {
            return new AndrewD.RecordLabel.Artist
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text,
                References = GetList(dbModel.References, GetReference),
                Metadata = GetList(dbModel.Metadata, GetMetadata)
            };
        }

        public AndrewD.RecordLabel.ArtistSlim GetArtistSlim(Artist dbModel)
        {
            return new AndrewD.RecordLabel.ArtistSlim
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text,
                References = GetList(dbModel.References, GetReference),
                MetadataIds = ExtractMetadataIds(dbModel.Metadata)
            };
        }

        public AndrewD.RecordLabel.ArtistBarebones GetArtistBareBones(Artist dbModel)
        {
            return new AndrewD.RecordLabel.ArtistBarebones
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text
            };
        }

        public AndrewD.RecordLabel.Release GetReleaseComplete(Release dbModel)
        {
            return new AndrewD.RecordLabel.Release
            {
                Id = dbModel.Id,
                CatalogueNumber = dbModel.CatalogueNumber,
                Date = dbModel.Date,
                Length = dbModel.Length,
                PrintStatus = dbModel.PrintStatus,
                References = GetList(dbModel.References, GetReference),
                Text = dbModel.Text,
                Title = dbModel.Title,
                Tracks = GetList(dbModel.Tracks, GetTrack),
                Artist = GetArtistComplete(dbModel.Artist),
                Media = GetMediaType(dbModel.Media),
                Metadata = GetList(dbModel.Metadata, GetMetadata)
            };
        }

        public AndrewD.RecordLabel.ReleaseSlim GetReleaseSlim(Release dbModel)
        {
            return new AndrewD.RecordLabel.ReleaseSlim
            {
                Id = dbModel.Id,
                CatalogueNumber = dbModel.CatalogueNumber,
                Date = dbModel.Date,
                Length = dbModel.Length,
                PrintStatus = dbModel.PrintStatus,
                References = GetList(dbModel.References, GetReference),
                Text = dbModel.Text,
                Title = dbModel.Title,
                Tracks = GetList(dbModel.Tracks, GetTrack),
                ArtistId = dbModel.ArtistId,
                MediaId = dbModel.MediaId,
                MetadataIds = ExtractMetadataIds(dbModel.Metadata)
            };
        }
    }
}