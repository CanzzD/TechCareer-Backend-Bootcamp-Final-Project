using System.Security.Claims;
using FinalProject.Data.Abstract;
using FinalProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{

    public class UsersController : Controller
    {

        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated){
                return RedirectToAction("Index","Products");
            }
            return View();
        }
        public IActionResult Register(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model){

            if(ModelState.IsValid){

                var user = await _userRepository.Users.FirstOrDefaultAsync(x=>x.Name == model.Name || x.Email == model.Email);
                if(user == null){
                    _userRepository.CreateUser(new Entity.User{
                        Name = model.Name,
                        Surname = model.Surname,
                        Email = model.Email,
                        Password = model.Password,
                    });
                    return RedirectToAction("Login");
                }else{
                    ModelState.AddModelError("","UserName ya da Email adresi kullanımda.");
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isUser =  await _userRepository.Users.FirstOrDefaultAsync(x => x.Email == model.Email && x.Password == model.Password);
                if (isUser != null)
                {
                    var userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUser.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUser.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUser.Surname ?? ""));

                    if(isUser.Email == "info@ahmetkaya.com"){
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }

                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties{
                        IsPersistent = true
                    };
                    
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                        return RedirectToAction("Index","Products");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı!");
                }
            }
            return View(model);
        }

        public IActionResult Profile(string username){
            if(string.IsNullOrEmpty(username)){
                return NotFound();
            }
            var user = _userRepository
                       .Users
                       .Include(x=>x.Orders)
                       .FirstOrDefault(x=>x.Name == username);

            if(user == null){
                return NotFound();
            }
            return View(user);
        }
    }
}