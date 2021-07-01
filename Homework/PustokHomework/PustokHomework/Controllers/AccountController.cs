using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pustok.ViewModels;
using PustokHomework.DAL;
using PustokHomework.Models;
using PustokHomework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PustokHomework.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(AppDbContext context,UserManager<AppUser> userManager,SignInManager<AppUser>signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser
        //    {
        //        UserName = "Admin",
        //        FullName = "Elman Hasanov"
        //    };

        //    //passsword: admin123
        //    await _userManager.CreateAsync(admin, "admin123");
        //    await _userManager.AddToRoleAsync(admin, "Admin");

        //    return Ok();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterModel registerModel)
        {
            //member register model yaradiriq viewdan bu type-de deyer goturecik. onun isvalid olub olmadigin yoxlayiriq ki 
            //mmeberregistermodelde verdiyimiz teleblere uygundumu ya yox. uygundusa existuser yaradiriq usermanagerden username-ine gore registermodelin
            //findbyname edirik. eger null deyilse exist user bu username bizde var demekdi artiq ona gore eror cixarib return edirik.
            //eger yene serte dusmese yeni user yoxdusa yeni appuser yaradiriq deyerlerine view-dan gelen modelin deyerlerin set edirik.
            //sonra useri ve passwordu usermanagerin create metoduna veririk ki user yaratsin bizimcun. ve bu zaman bize result neticesi qayidir.
            //hansi ki bu da bize Succeded metodu verir ki yoxlayaq ki yaradila bildimi ya yox. ve yarada bilmirse result.errors ile cixan errorlara catmaq olar.
            //ve biz errorlari dovre salib her erorun code-sini descriptionunu gore deyise bilerik. code-ye gore yoxlayib cixacaq erroru deyise bilerik descriptionu ile.
            //eger bunlarin hamiisindan kecdikse usermanagerin icinden addrole isledim useri ve rolu string kimi veririk role elave edir,
            //daha sonra ise signinManager-den gelen signIn metodunu islederek bura da useri ve true deyerini veririk ki sign olsun istifadeci,sonra ise hansisa sehifeye return edirik.
            if (!ModelState.IsValid) return View();

            AppUser existUser = await _userManager.FindByNameAsync(registerModel.UserName);

            if (existUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already taken");
                return View();
            }


            AppUser user = new AppUser
            {
                FullName = registerModel.FullName,
                UserName = registerModel.UserName
            };

            var result =await  _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    if (item.Code== "PasswordTooShort")
                    {
                        item.Description = "Passwordun uzunlugu 8-den kicik ola bilmez";
                    }
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user,true);




            return RedirectToAction("index","home");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginModel loginModel)
        {
            //burda demeli memberloginmodel yaradiriq ve bize login olanda hansi deyerler gelecek onlari bildiririk. burda persistant remember me hissesi hesab olunur.
            //demeli user olaraq usermanagerden findbyname isledim gelen modelin usernamein yoxlayiriqki null-a beraberdise ve ya is admini trudusa return ele view-a ve evvelce de eror elave et.
            //sonra result deyer tutub bunu da signinmanagerden gelen passwordsignin metodunu isledib useri gelen passwordu ispersistanti ve ve true veririk ki girsin.
            //gelen resultun icinden basxiriq ki succeded false-dirse error elave edib viewnu return edirik. eks halda burani kecse onsuz sign edecek ve biz home-nin indexine qaytara bilerik.
            AppUser user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user == null || user.IsAdmin)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, loginModel.IsPersistent, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Password is incorrect");
                return View();
            }

            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("login");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Edit()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            MemberEditModel member = new MemberEditModel
            {
                Address = user.Address,
                ContactPhone = user.ContactPhone,
                FullName = user.FullName,
                UserName = user.UserName,
            };
            return View(member);
        }

        [Authorize(Roles = "Member")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MemberEditModel member)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (_userManager.Users.Any(x => x.UserName == member.UserName && x.Id != user.Id))
            {
                ModelState.AddModelError("UserName", "UserName already taken!");
                return View();
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            user.UserName = member.UserName;
            user.FullName = member.FullName;
            user.ContactPhone = member.ContactPhone;
            user.Address = member.Address;


            if (!string.IsNullOrWhiteSpace(member.Password))
            {
                if (string.IsNullOrWhiteSpace(member.CurrentPassword))
                {
                    ModelState.AddModelError("CurrentPassword", "CurrentPassword can not be emtpy");
                    return View();
                }

                var result = await _userManager.ChangePasswordAsync(user, member.CurrentPassword, member.Password);
                if (!result.Succeeded)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                    return View();
                }
            }
            await _userManager.UpdateAsync(user);

            await _signInManager.SignInAsync(user, true);
            return RedirectToAction("index", "home");
        }





    }
}
