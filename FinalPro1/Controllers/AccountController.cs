using FinalPro1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalPro1.Controllers
{
    public class AccountController : Controller
    {
        private readonly CmsContext _context;
        public AccountController(CmsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(string MEM_ACCOUNT, string MEM_PASSWORD)
        {
            if (MEM_ACCOUNT == null && MEM_PASSWORD == null)
            {
                TempData["message"] = "Please enter account and password!";
                return RedirectToAction("Login", "Account");
            }

            var mains = await (from p in _context.TableMEMBERSs1111757
                               where p.MEM_ACCOUNT == MEM_ACCOUNT && p.MEM_PASSWORD == MEM_PASSWORD
                               orderby p.MEM_PASSWORD
                               select p).ToListAsync();
            if (mains.Count != 0)
            {
                HttpContext.Session.SetString("MEM_ACCOUNT", MEM_ACCOUNT);
                TempData["message"] = "Login in!";
                return RedirectToAction("Discount", "Store");
            }
            else
            {
                TempData["message"] = "Login failed!";
                return RedirectToAction("Login", "Account");
            }

        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("MEM_ACCOUNT") == null)
            {
                TempData["message"] = "Please Login!";
                return RedirectToAction("Login", "Account");
            }

            TempData["message"] = "You have been logged out!";
            HttpContext.Session.Remove("MEM_ACCOUNT");
            return RedirectToAction("Login", "Account");
        }
    }
}
