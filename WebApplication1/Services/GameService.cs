using Games.Data;
using Games.Models;
using Games.View_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

      

        public async Task<Game?> Edit(EditGameViewmodel Model)
        {
            var item = context.games
                .Include(g => g.gamedevice)
                .SingleOrDefault(s => s.Id == Model.id); 
            if (item is null)
                return null;
            var hasnewcover = Model.Cover is not null;
            var oldcover = item.Cover;

            item.Name = Model.Name;
            item.categoryID = Model.categoryID;
            item.Discreption = Model.Discreption;
            item.gamedevice = Model.selecteddevices.Select(s => new GameDevice { deviceid = s}).ToList();

            if(hasnewcover)
            {
                // saving new pic in server when user change a pic 
                item.Cover = await SaveCover(Model.Cover!);
            }
            var effectedrow = context.SaveChanges();
            // > 0 if actually doing updating
            if(effectedrow > 0)
            {
                // if user doing edit check if add a new pic or not if add a new pic delete old pic 
                if(hasnewcover)
                {
                    // there user send in VM a new pic 
                    var cover = Path.Combine(imagepath, oldcover);
                    File.Delete(cover);
                }
                return item;
            }
            else
            {
                var cover = Path.Combine(imagepath, item.Cover);
                File.Delete(cover);
                return null;
            }
       

        }

        public List<Game> Getall()
        {
          return context.games.
                Include(g =>g.category)
                .Include(g =>g.gamedevice)
                .AsNoTracking().ToList();
        }

        public Game? Getbyid(int id)
        {
            var items = context.games.Include(g => g.category).Include(g => g.gamedevice).SingleOrDefault(g => g.Id == id);
            return items;
        }

        bool IGameService.Delete(int id)
        {
            var isDeleted = false;

            var item = context.games.Find(id);
            if (item is null)
                return isDeleted;
            context.games.Remove(item);
            var effected = context.SaveChanges();
            if(effected > 0)
            {
                // remove pic from server 
                var pic = Path.Combine(imagepath, item.Cover);
                File.Delete(pic);
                isDeleted = true;
            }

            return isDeleted;

        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(imagepath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }
    }

   
}
