using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.DTO
{
    public class AlbumDTO
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }

        public IEnumerable<TrackDTO> Tracks { get; set; }

        
    }
}
