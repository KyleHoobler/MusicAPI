using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPI.Contexts;
using MusicAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private AlbumContext _albumContext;

        public AlbumController(AlbumContext context)
        {
            _albumContext = context;
        }

        // GET: api/<SongController>
        [HttpGet]
        public List<AlbumModel> GetAlbums()
        {
            List<AlbumModel> albums = _albumContext.Albums.Include((x) => x.Songs).ToList();

            return albums;
        }

        [HttpGet("{id}")]
        public AlbumModel GetAlbum(int id)
        {
            return _albumContext.Albums.Include((x) => x.Songs).Where((x) => x.Id == id).FirstOrDefault() ?? new AlbumModel();
        }

        [HttpPost(Name = "Add Full Album")]
        public void AddFullAlbum(AlbumModel value)
        {
            _albumContext.Albums.Add(value);
            _albumContext.SaveChanges();
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void DeleteAlbum(int id)
        {
            _albumContext.Albums.Remove(_albumContext.Albums.Where((x) => x.Id == id).SingleOrDefault());
            _albumContext.SaveChanges();

        }
    }
}
