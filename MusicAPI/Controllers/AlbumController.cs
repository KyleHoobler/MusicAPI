#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Contexts;
using MusicAPI.Exceptions;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly MusicContext MusicContext;

        public AlbumController(MusicContext context)
        {
            MusicContext = context;
        }

        // GET: api/Album
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumModel>>> GetAlbums()
        {
            return await MusicContext.Albums.ToListAsync();
        }

        // GET: api/Album/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumModel>> GetAlbum(int id)
        {
            var albumModel = await MusicContext.Albums.FindAsync(id);

            if (albumModel == null)
            {
                return NotFound();
            }

            return albumModel;
        }

        // PUT: api/Album/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, AlbumModel albumModel)
        {
            if (id != albumModel.Id)
            {
                return BadRequest();
            }

            MusicContext.Entry(albumModel).State = EntityState.Modified;

            try
            {
                await MusicContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Album
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{ArtistID}")]
        public async Task<ActionResult<AlbumModel>> PostAlbum(int ArtistID, AlbumModel albumModel)
        {

            if (!MusicContext.Artists.Any(x => x.Id == ArtistID))
                throw new InvalidArtistException("Selected ArtistID does not exist.");

            albumModel.ArtistID = ArtistID;
            albumModel.Songs.ForEach((x) =>
            {
                if(x.ArtistID is null)
                    x.ArtistID = ArtistID;
            });

            MusicContext.Albums.Add(albumModel);
            await MusicContext.SaveChangesAsync();

            return CreatedAtAction("GetAlbumModel", new { id = albumModel.Id }, albumModel);
        }

        // DELETE: api/Album/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var albumModel = await MusicContext.Albums.FindAsync(id);
            if (albumModel == null)
            {
                return NotFound();
            }

            MusicContext.Albums.Remove(albumModel);
            await MusicContext.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumModelExists(int id)
        {
            return MusicContext.Albums.Any(e => e.Id == id);
        }
    }
}
