using Games.Data;
using Games.Models;
using Games.View_Model;

namespace Games.Services
{
    public class GameService : IGameService
    {
        private readonly Applicationcontext context;
        private readonly IWebHostEnvironment env;
        private readonly string imagepath;
        public GameService(Applicationcontext context, IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
            imagepath = $"{env.WebRootPath}/images/Games";
        }

        public async Task Create(CreateformaddedGameVM game)
        {
            var covername = $"{Guid.NewGuid()}{Path.GetExtension(game.Cover.FileName)} ";
            var path = Path.Combine(imagepath, covername);
            using var stream = File.Create(path);
            await game.Cover.CopyToAsync(stream);
            stream.Dispose();

            Game gg = new()
            {
                Name = game.Name,
                Discreption = game.Discreption,
                Cover = covername,
                gamedevice = game.selecteddevices.Select(s => new GameDevice { deviceid = s}).ToList(),
                categoryID = game.categoryID,

            };
            context.games.Add(gg);
            context.SaveChanges();

        }
    }
}
