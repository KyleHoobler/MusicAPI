using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.Models
{
    public abstract class MusicBase
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
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }

        [ForeignKey("Artist")]
        public int ArtistID { get; set; }

        [Required]
        [JsonIgnore]
        public ArtistModel Artist { get; set; }

    }
}
