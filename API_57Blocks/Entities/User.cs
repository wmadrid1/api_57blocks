using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_57Blocks.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
