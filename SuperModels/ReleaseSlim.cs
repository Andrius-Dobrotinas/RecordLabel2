using System;
using System.Collections.Generic;
using System.Linq;

namespace AndrewD.RecordLabel
{
    public class ReleaseSlim : ContentSlim
    {
        public int ArtistId { get; set; }
        public int MediaId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
        
        public short Date { get; set; }

        public short Length { get; set; }

        public string CatalogueNumber { get; set; }
        
        public PrintStatus PrintStatus { get; set; }

        public virtual IList<Track> Tracks
        {
            get
            {
                return tracks ?? (tracks = new List<Track>());
            }
            set
            {
                tracks = value;
            }
        }
        private IList<Track> tracks { get; set; }
    }
}
