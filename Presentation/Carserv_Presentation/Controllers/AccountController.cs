using Carserv_Domain;
using Carserv_Domain.Helper;
using Carserv_Domain.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Carserv_Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(RoleManager<IdentityRole> roleManager,SignInManager<User> signInManager,UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public async  Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = item.ToString(),
                });
            }
            return Ok();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm) 
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = new User()
            {
                Name=vm.Name,
                Email=vm.Email,
                Surname=vm.Surname,
                UserName=vm.UserName,
            };
            var result=await userManager.CreateAsync(user , vm.Password);
            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            await userManager.AddToRoleAsync(user,Role.Member.ToString());
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM,string? ReturnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user=new User();
            if (loginVM.UsernameorEmail.Contains("@"))
            {
                user=await userManager.FindByEmailAsync(loginVM.UsernameorEmail);
                if (user == null) 
                {
                    ModelState.AddModelError("", "Username ve ya email shefdir");
                    return View();
                }
                var resultl= await signInManager.CheckPasswordSignInAsync(user, loginVM.Password,true);
                if (resultl.IsLockedOut)
                {
                    ModelState.AddModelError("", "Birazdasn yeniden cehd edin");
                    return View();
                }
                if (!resultl.Succeeded)
                {
                    ModelState.AddModelError("", "Parol sehfdir");
                    return View();
                }
                await signInManager.SignInAsync(user, false);
                if (ReturnUrl!=null)
                {
                    return Redirect(ReturnUrl);
                }
            }
            user=await userManager.FindByNameAsync(loginVM.UsernameorEmail);
            if(user == null)
            {
                ModelState.AddModelError("", "user name or email sehfdir");
                return View();
            }
            var result = await signInManager.CheckPasswordSignInAsync(user,loginVM.Password,true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Birazdasn yeniden cehd edin");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Password shefdir");
                return View();
            }
            await signInManager.SignInAsync(user,false);
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
