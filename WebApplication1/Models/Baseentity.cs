using System.ComponentModel.DataAnnotations;

namespace Games.Models
{
    public class Baseentity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
    }
}
