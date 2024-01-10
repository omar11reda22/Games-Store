using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Games.Models
{
    public class Game:Baseentity
    {
        [MaxLength(3000)]
        [Required]
        public string Discreption { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public int categoryID { get; set; }
        [ForeignKey("categoryID")]
        public Category category { get; set; } = default!;
        public ICollection<GameDevice> gamedevice { get; set; } = new List<GameDevice>();
    }
}
