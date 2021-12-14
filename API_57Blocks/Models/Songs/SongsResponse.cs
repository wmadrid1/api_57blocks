namespace API_57Blocks.Models.Songs
{
    public class SongsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public int? Year { get; set; }
        public string? Genre { get; set; }
    }
}
