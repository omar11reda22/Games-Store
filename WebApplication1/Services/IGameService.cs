using Games.View_Model;

namespace Games.Services
{
    public interface IGameService
    {
        Task Create(CreateformaddedGameVM game);
      
    }
}
