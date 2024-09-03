using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PociDelivery.Data;
using PociDelivery.Models;
using PociDelivery.ViewModels;
using System.Security.Claims;
using PociDelivery.Interfaces;
using PociDelivery.Repository;
using System.Data;

namespace PociDelivery.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPerdoruesiRepository _perdoruesiRepository;

        public AccountsController(ApplicationDbContext context,
            IPerdoruesiRepository perdoruesiRepository)
        {
            _context = context;
            _perdoruesiRepository = perdoruesiRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(PerdoruesitViewModel crd)
        {
            var user = _context.Perdoruesit
                .FirstOrDefault(x => x.Email == crd.Email && x.Fjalekalimi == crd.Fjalekalimi);

            if (user != null)
            {

                //merr rolet e perdoruesit 
                var roleName = _context.Rolet
            .Where(r => r.IDRoli == user.IDRoli)
            .Select(r => r.EmerRoli)
            .FirstOrDefault();

                // Create claims for the user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, roleName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in the user
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = false 
                    });

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Username or Password is incorrect");
            return View(); ;
        }

        [HttpPost]
        public ActionResult SignUp(Perdoruesi userInfo)
        {
            userInfo.CreatedOn = DateTime.UtcNow;
            _context.Perdoruesit.Add(userInfo);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult SignOut()
        {
            // Sign out the user
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
