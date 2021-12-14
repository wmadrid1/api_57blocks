using System.ComponentModel.DataAnnotations;

namespace API_57Blocks.Models.Songs
{
    public class SongRequest
    {
        [Required]
        public string Name { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public int? Year { get; set; }
        public string? Genre { get; set; }
    }
}
