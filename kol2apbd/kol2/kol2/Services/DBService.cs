using kol2.DTO;
using kol2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class DBService : IDBService
    {
        private readonly MainDbContext mainDbContext;
        public DBService(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public async Task<AlbumDTO> GetAlbumAsync(int id)
        {


            if (await mainDbContext.Albums.FindAsync(id) == null)
            {
                return null;
            }
            AlbumDTO albumDTO = await mainDbContext.Albums.Where(e => e.IdAlbum == id).Select(e => new AlbumDTO
            {
                AlbumName = e.AlbumName,
                PublishDate = e.PublishDate,
                Tracks = e.Tracks.Select(e => new TrackDTO
                {
                    TrackName = e.TrackName,
                    Duration = e.Duration
                })
            }).FirstAsync();
            return albumDTO;
        }
    }
}
