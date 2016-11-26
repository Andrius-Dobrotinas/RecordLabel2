using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AndrewD.RecordLabel
{
    public class ReleaseSlim : ContentSlim
    {
        [Range(0, int.MaxValue, ErrorMessage = "Artist is required")]
        public int ArtistId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Media is required")]
        public int MediaId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Text { get; set; }

        // Validate in controller due to dynamic nature of constrains of this value
        public short Date { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Length is required")]
        public short Length { get; set; }

        [Required]
        public string CatalogueNumber { get; set; }

        // Validate in controller
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
