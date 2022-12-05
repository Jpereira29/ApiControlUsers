using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiControlUsers.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(30)]
        [StringLength(30, MinimumLength = 3)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(300)]
        [StringLength(300, MinimumLength = 15)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(80)]
        public string? RepositoryUrl { get; set; }

        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
    }
}
