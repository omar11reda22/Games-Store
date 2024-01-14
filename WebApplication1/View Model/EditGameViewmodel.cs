namespace Games.View_Model
{
    public class EditGameViewmodel:GameviewModel
    {
        public int id { get; set; }
        public string? currentcover { get; set; }
        public IFormFile? Cover { get; set; } = default!;
    }
}
