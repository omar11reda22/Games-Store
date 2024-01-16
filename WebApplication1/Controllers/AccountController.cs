using Games.Data;
using Games.View_Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Games.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Applicationuser> userManager;
        private readonly SignInManager<Applicationuser> signInManager;
      
        public AccountController(UserManager<Applicationuser> userManager, SignInManager<Applicationuser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        // open form registration 
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        // saving data in db
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationViewModel model)
        {
            if (ModelState.IsValid)
            {

                // saving
                Applicationuser appuser = new()
                {
                    UserName = model.UserName,
                    Email = model.EMAIL,
                    PasswordHash = model.Password
                };
                 IdentityResult result =  await userManager.CreateAsync(appuser);
                if (result.Succeeded)
                {
                    // create cookie
                    await signInManager.SignInAsync(appuser, false);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    foreach (var item in result.Errors )
                    {
                        ModelState.AddModelError("password", item.Description);
                    }
                }
            }
            return View(model);
        }
        // expire cookie
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Homepage" , "Home");
        }
        // Login 
        [HttpGet]
        public  IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewmodel Model)
        {
            if (ModelState.IsValid)
            {
                var item = await userManager.FindByNameAsync(Model.UserName);
                if (item is null)
                {
                    ModelState.AddModelError("", "this user not found please register");
                }
                else
                {
                    var result = await signInManager.PasswordSignInAsync(Model.UserName, Model.Password, Model.RemmemberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "something is wrong please check");
                    }
                }



                //Applicationuser result = await userManager.FindByNameAsync(Model.UserName);
                //  if(result is not null)
                //  {
                //      // chech password 
                //   bool found =  await userManager.CheckPasswordAsync(result, Model.Password);
                //      if (found is true) 
                //      {
                //          // create cookie
                //          await signInManager.SignInAsync(result, Model.RemmemberMe);
                //          return RedirectToAction("Index", "Games");
                //      }
                //      else if(found is false)
                //      {
                //          ModelState.AddModelError("", "Email or password is wrong please check");
                //      }
                //  }
                //  else
                //  {
                //      ModelState.AddModelError("","sorry this email not found please register");
                //  }


            }
            return View(Model);
        }




    }
}
