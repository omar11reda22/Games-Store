using Games.Models;
using Games.View_Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Games.Services
{
    public interface IGameService
    {
        Task Create(CreateformaddedGameVM game);
        bool Delete(int id);
        List<Game> Getall();
        Game? Getbyid(int id);
        Task<Game?> Edit(EditGameViewmodel game);
      
    }
}
