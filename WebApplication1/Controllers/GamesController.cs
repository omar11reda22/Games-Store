using Games.Data;
using Games.Models;
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

        // gett all games from db
        public IActionResult Index()
        {
            var games =  _gameService.Getall();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gameService.Getbyid(id);
            if(game == null)
            {
                return NotFound("no games");
            }
            return View(game);
        }

        // open form view to doing updateing  
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _gameService.Getbyid(id);
            if (item == null)
                return NotFound();
            EditGameViewmodel editGameViewmodel = new()
            {
               id = item.Id,
               Name = item.Name,
               Discreption = item.Discreption,
               categoryID = item.categoryID,
               selecteddevices = item.gamedevice.Select(s => s.deviceid).ToList(),
               Categories = categoryService.Getcategories(),
               Devices = deviceService.Getalldevices(),
               currentcover = item.Cover

            };
                     

            return View(editGameViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit( EditGameViewmodel gameVM)
        {
            if (!ModelState.IsValid)
            {
                gameVM.Categories = categoryService.Getcategories();
                gameVM.Devices = deviceService.Getalldevices();
                return View(gameVM);

            }
            var game = await _gameService.Edit(gameVM);
            if (game is null)
                return BadRequest();
            return RedirectToAction(nameof(Index));


        
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
       
        public  IActionResult Delete(int id)
        {
            var isdeleted = _gameService.Delete(id);
            if (isdeleted == false)
                return BadRequest();
            return RedirectToAction(nameof(Index));
        }
    }
}
