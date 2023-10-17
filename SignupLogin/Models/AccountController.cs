using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SignupLogin.Data;
using SignupLogin.Models.ViewModel;
using System.Security.Claims;

namespace SignupLogin.Models
{
    public class AccountController : Controller
    {
        public ApplicationdbContext context { get; }

        public AccountController( ApplicationdbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(LoginSignUpViewModel model)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginSignUpViewModel model)
        {
            if(ModelState.IsValid)
            {
                var data = context.Users.Where(e => e.UserName == model.UserName).SingleOrDefault();
                if(data !=null)
                {
                    bool IsValid = (data.UserName == model.UserName && data.Password == model.Password);
                    if(IsValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("UserName", model.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Invalid password";
                    }
                }
                else
                {
                    TempData["errorUserName"] = "User name not found!";
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            return View();
           
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach(var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login","Account");
        }


    }
}
