using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portal.Models;

namespace Portal.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr)
    {
        userManager = userMgr;
        signInManager = signInMgr;

        IdentitySeedData.EnsurePopulated(userMgr).Wait();
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        if (ModelState.IsValid)
        {
            var user =
                await userManager.FindByNameAsync(loginModel.Email);
            if (user != null)
            {
                await signInManager.SignOutAsync();
                if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                {
                    return Redirect("/Home/Index");
                }
            }
        }

        ModelState.AddModelError("", "Invalid name or password");
        return View(loginModel);
    }


    [AllowAnonymous]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(UserRegisterModel userModel)
    {
        if (ModelState.IsValid)
        {
            return View(userModel);
        }

        var user = new IdentityUser { UserName = userModel.Email, Email = userModel.Email };
        var result = await userManager.CreateAsync(user, userModel.Password);
        
        if (result.Succeeded)
        {
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        return View();
    }



    public async Task<RedirectResult> Logout()
    {
        await signInManager.SignOutAsync();
        return Redirect("/Home/Index");
    }

    public async Task<IActionResult> AccessDenied(string returnUrl)
    {
        return View();
    }

}