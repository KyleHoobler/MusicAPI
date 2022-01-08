using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    [Table("Artists")]
    public class ArtistModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public List<AlbumModel> Albums { get; set; }

    }
}
