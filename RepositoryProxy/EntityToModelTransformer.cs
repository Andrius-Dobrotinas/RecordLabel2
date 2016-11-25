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

        public SuperModels.MediaType GetMediaType(MediaType dbModel)
        {
            return new SuperModels.MediaType
            {
                Id = dbModel.Id,
                Text = dbModel.Text
            };
        }

        public SuperModels.Reference GetReference(Reference dbModel)
        {
            if (dbModel == null) return null;
            return new SuperModels.Reference
            {
                Id = dbModel.Id,
                Order = dbModel.Order,
                Target = dbModel.Target,
                Type = dbModel.Type
            };
        }

        public SuperModels.Metadata GetMetadata(Metadata dbModel)
        {
            return new SuperModels.Metadata
            {
                Id = dbModel.Id,
                Text = dbModel.Text,
                Type = dbModel.Type
            };
        }

        public SuperModels.Track GetTrack(Track dbModel)
        {
            return new SuperModels.Track
            {
                Id = dbModel.Id,
                Reference = dbModel.Reference,
                Title = dbModel.Title
            };
        }

        public SuperModels.Artist GetArtistComplete(Artist dbModel)
        {
            return new SuperModels.Artist
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text,
                References = GetList(dbModel.References, GetReference),
                Metadata = GetList(dbModel.Metadata, GetMetadata)
            };
        }

        public SuperModels.ArtistSlim GetArtistSlim(Artist dbModel)
        {
            return new SuperModels.ArtistSlim
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text,
                References = GetList(dbModel.References, GetReference),
                MetadataIds = ExtractMetadataIds(dbModel.Metadata)
            };
        }

        public SuperModels.ArtistBarebones GetArtistBareBones(Artist dbModel)
        {
            return new SuperModels.ArtistBarebones
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Text = dbModel.Text
            };
        }

        public SuperModels.Release GetReleaseComplete(Release dbModel)
        {
            return new SuperModels.Release
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

        public SuperModels.ReleaseSlim GetReleaseSlim(Release dbModel)
        {
            return new SuperModels.ReleaseSlim
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