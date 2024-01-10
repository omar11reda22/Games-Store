namespace Games.Models
{
    public class Category:Baseentity
    {
        public ICollection<Game> games { get; set; } = new List<Game>();
    }
}
