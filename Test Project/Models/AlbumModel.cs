using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    [Table("Albums")]
    public class AlbumModel : MusicBase
    {
        /// <summary>
        /// ID For the album
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Release Date of the album
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// List of songs on the album
        /// </summary>
        public List<SongModel> Songs { get; set; } = new List<SongModel>();

    }
}
