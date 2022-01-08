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
        // GET: api/<SongController>
        [HttpGet]
        public IEnumerable<AlbumModel> Get()
        {
            using (AlbumContext context = new AlbumContext())
            {
                List<AlbumModel> albums = context.Albums.Include((x) => x.Songs).ToList();

                return albums;
            }
        }

        [HttpGet("{id}")]
        public AlbumModel Get(int id)
        {
            using (AlbumContext context = new AlbumContext())
            {
                return context.Albums.Where((x) => x.Id == id).FirstOrDefault() ?? new AlbumModel();
            }
        }

        //[HttpPost(Name ="Add Album")]
        //public void AddAlbum([FromBody] AlbumBase value)
        //{
        //    using (AlbumContext context = new AlbumContext())
        //    {
        //        context.Albums.Add(value.ConvertToAlbumModel());
        //        context.SaveChanges();
        //    }
        //}

        [HttpPost(Name ="Add Full Album")]
        public bool AddFullAlbum(AlbumModel value)
        {
            using (AlbumContext context = new AlbumContext())
            {
                context.Albums.Add(value);
                context.SaveChanges();
            }

            return true;
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (AlbumContext context = new AlbumContext())
            {
                context.Albums.Remove(context.Albums.Where((x) => x.Id == id).SingleOrDefault());
                context.SaveChanges();
            }
        }
    }
}
