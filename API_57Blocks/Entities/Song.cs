using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_57Blocks.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year{ get; set; }
        public string Genre { get; set; }

        [JsonIgnore]
        public int? UserId { get; set; }

        //Public - Private
        [JsonIgnore]
        public string scope { get; set; }
    }
}
