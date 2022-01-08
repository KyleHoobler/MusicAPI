using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class AlbumModel : AlbumBase
    {

        /// <summary>
        /// List of songs on the album
        /// </summary>
        public List<SongModel> Songs { get; set; } = new List<SongModel>();

    }
}
