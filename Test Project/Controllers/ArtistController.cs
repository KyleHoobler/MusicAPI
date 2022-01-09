#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Contexts;
using MusicAPI.Models;

namespace MusicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly MusicContext MusicContext;

        public ArtistController(MusicContext context)
        {
            MusicContext = context;
        }

        // GET: api/Artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistModel>>> GetArtists()
        {
            return await MusicContext.Artists.ToListAsync();
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistModel>> GetArtist(int id)
        {
            var artistModel = await MusicContext.Artists.FindAsync(id);

            if (artistModel == null)
                return NotFound();

            return artistModel;
        }

        // PUT: api/Artist/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, ArtistModel artistModel)
        {
            if (id != artistModel.Id)
                return BadRequest();

            MusicContext.Entry(artistModel).State = EntityState.Modified;

            try
            {
                await MusicContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArtistModel>> PostArtist(ArtistModel artistModel)
        {
            MusicContext.Artists.Add(artistModel);
            await MusicContext.SaveChangesAsync();

            return CreatedAtAction("GetArtistModel", new { id = artistModel.Id }, artistModel);
        }

        // DELETE: api/Artist/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artistModel = await MusicContext.Artists.FindAsync(id);
            if (artistModel == null)
            {
                return NotFound();
            }

            MusicContext.Artists.Remove(artistModel);
            await MusicContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(int id)
        {
            return MusicContext.Artists.Any(e => e.Id == id);
        }
    }
}
