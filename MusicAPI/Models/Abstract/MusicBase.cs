using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{
    public abstract class MusicBase
    {
        /// <summary>
        /// Name of the album
        /// </summary>
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [ForeignKey("Artist")]
        [JsonIgnore]
        public int? ArtistID { get; set; }

        [JsonIgnore]
        public ArtistModel? Artist { get; set; }

    }
}
