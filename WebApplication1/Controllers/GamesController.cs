using Games.Data;
using Games.Services;
using Games.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace Games.Controllers
{
    public class GamesController : Controller
    {
       // private readonly Applicationcontext context;
        private readonly ICategoryservice categoryService;
        private readonly IDeviceService deviceService;
        private readonly IGameService _gameService;

        public GamesController(ICategoryservice categoryService, IDeviceService deviceService, IGameService gameService)
        {

            this.categoryService = categoryService;
            this.deviceService = deviceService;
            this._gameService = gameService;
        }

        public IActionResult Index()
        {

            return View();
        }
        // open form to add a new game just form
        [HttpGet]
        public IActionResult Create()
        {
            CreateformaddedGameVM vm = new()
            {
                Categories = categoryService.Getcategories(),


                Devices = deviceService.Getalldevices(),



            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateformaddedGameVM Model) 
        {
            if(ModelState.IsValid == true)
            {
               await _gameService.Create(Model);
                // saving data to database
                // saving cover to server
                return RedirectToAction(nameof(Index));
            }
            else if(!ModelState.IsValid)
            {
                Model.Categories = categoryService.Getcategories();
                Model.Devices = deviceService.Getalldevices();
                return View(Model);

            }

            return View();
        }
    }
}
