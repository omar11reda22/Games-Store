namespace Games.Models
{
    public class GameDevice
    {
        public int gameid { get; set; }
        public Game game { get; set; } = default!;

        public int deviceid { get; set; }
        public Device Device { get; set; } = default!;
    }
}
