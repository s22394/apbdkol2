using kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IDBService service;
        public AlbumController(IDBService service)
        {
            this.service = service;
        }
        [HttpGet("albums/{id}")]
        public async Task<IActionResult> GetAlbums([FromRoute] int id)
        {
            var result = await service.GetAlbumAsync(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
