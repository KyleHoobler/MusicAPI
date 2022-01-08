using MusicAPI.Enum.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models;

public class SongModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string? Name { get; set; }

    public Genre Genre { get; set; }

    [ForeignKey("Album")]
    public int? AlbumID { get; set; }

    public AlbumModel? Album { get; set; }
}

