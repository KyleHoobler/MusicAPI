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
    public class SongController : ControllerBase
    {
        private readonly MusicContext MusicContext;

        public SongController(MusicContext context)
        {
            MusicContext = context;
        }

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongModel>>> GetSongs()
        {
            return await MusicContext.Songs.ToListAsync();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongModel>> GetSongModel(int id)
        {
            var songModel = await MusicContext.Songs.FindAsync(id);

            if (songModel == null)
            {
                return NotFound();
            }

            return songModel;
        }

        // PUT: api/Song/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongModel(int id, SongModel songModel)
        {
            if (id != songModel.Id)
            {
                return BadRequest();
            }

            MusicContext.Entry(songModel).State = EntityState.Modified;

            try
            {
                await MusicContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongModelExists(id))
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

        // POST: api/Song
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SongModel>> PostSongModel(int ArtistID, int AlbumID, SongModel songModel)
        {
            if (!MusicContext.Artists.Any(x => x.Id == ArtistID))
                throw new InvalidArtistException("Selected ArtistID does not exist.");

            if (!MusicContext.Albums.Any(x => x.Id == AlbumID))
                throw new InvalidAlbumException("Selected AlbumID does not exist.");

            songModel.ArtistID = ArtistID;
            songModel.AlbumID = AlbumID;
            MusicContext.Songs.Add(songModel);
            await MusicContext.SaveChangesAsync();

            return CreatedAtAction("GetSongModel", new { id = songModel.Id }, songModel);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongModel(int id)
        {
            var songModel = await MusicContext.Songs.FindAsync(id);
            if (songModel == null)
            {
                return NotFound();
            }

            MusicContext.Songs.Remove(songModel);
            await MusicContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SongModelExists(int id)
        {
            return MusicContext.Songs.Any(e => e.Id == id);
        }
    }
}
