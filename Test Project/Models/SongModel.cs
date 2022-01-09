using MusicAPI.Enum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.Models;

[Table("Songs")]
public class SongModel : MusicBase
{
    /// <summary>
    /// ID For the album
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public Genre Genre { get; set; }

    [ForeignKey("Album")]
    [JsonIgnore]
    public int? AlbumID { get; set; }

    [JsonIgnore]
    public AlbumModel? Album { get; set; }
}

