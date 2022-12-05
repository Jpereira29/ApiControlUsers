using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiControlUsers.Models
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(30, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Url { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
