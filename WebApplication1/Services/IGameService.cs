using Games.Models;
using Games.View_Model;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Games.Services
{
    public interface IGameService
    {
        Task Create(CreateformaddedGameVM game);
        Task Delete(int id);
        Task<List<Game>> Getall();
        Task<Game> Getbyid(int id);
        Task Edit(int id, CreateformaddedGameVM game);
      
    }
}
