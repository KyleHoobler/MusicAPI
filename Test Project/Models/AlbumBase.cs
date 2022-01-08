using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class AlbumBase
    {
        /// <summary>
        /// ID For the album
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the album
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Release Date of the album
        /// </summary>
        public DateTime? ReleaseDate { get; set; }

        public AlbumModel ConvertToAlbumModel()
        {
            AlbumModel model = new AlbumModel();

            model.Id = Id;
            model.Name = Name;
            model.ReleaseDate = ReleaseDate;

            return model;
        }
    }
}
