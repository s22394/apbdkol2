using kol2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IDBService
    {
        Task<AlbumDTO> GetAlbumAsync(int id);
    }
}
