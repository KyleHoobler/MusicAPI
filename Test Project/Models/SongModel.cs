using MusicAPI.Enum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicAPI.Models;

[Table("Songs")]
public class SongModel : MusicBase
{
    public Genre Genre { get; set; }

    [ForeignKey("Album")]
    [JsonIgnore]
    public int? AlbumID { get; set; }

    [JsonIgnore]
    public AlbumModel? Album { get; set; }
}

