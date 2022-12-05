using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiControlUsers.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string? Email { get; set; }

        public ICollection<Project> Projects { get; set; } = new Collection<Project>();
        public ICollection<SocialMedia> SocialMedias { get; set; } = new Collection<SocialMedia>();
    }
}
