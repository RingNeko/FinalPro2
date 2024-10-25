using FinalPro1.Data;
using FinalPro1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using X.PagedList;

namespace FinalPro1.Controllers
{
    public class StoreController : Controller
    {
        private readonly CmsContext _context;

        public StoreController(CmsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var names = await (from p in _context.TableSTOREs1111757
                               orderby p.COU_CODE
                               select p.COU_CODE).Distinct().ToListAsync();

            ViewBag.Mylist = names;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StoreResult(string citys)
        {
            if (citys != null)
            {
                var users = await (from p in _context.TableSTOREs1111757
                                   where p.COU_CODE == citys
                                   orderby p.STORE_ID
                                   select p).ToListAsync();
                return View(users);
            }

            return View();
        }
        public async Task<IActionResult> Discount()
        {
            //判斷登入
            if (HttpContext.Session.GetString("MEM_ACCOUNT") == null)
            {
                TempData["message"] = "Please Login!";
                return RedirectToAction("Login", "Account");
            }
            var dis = await _context.TableDISCOUNTs1111757.ToListAsync();
            return View(dis);
        }
        public async Task<IActionResult> StoreResult(int? page = 1)
        {
            const int pageSize = 20;
            //處理頁數
            ViewBag.usersModel = GetPagedProcess(page, pageSize);
            //填入頁面資料
            return View(await _context.TableSTOREs1111757.Skip<Store>(pageSize * ((page ?? 1) - 1)).Take(pageSize).ToListAsync());

        }

        protected IPagedList<Store> GetPagedProcess(int? page, int pageSize)
        {
            // 過濾從client傳送過來有問題頁數
            if (page.HasValue && page < 1)
                return null;
            // 從資料庫取得資料
            var listUnpaged = GetStuffFromDatabase();
            IPagedList<Store> pagelist = listUnpaged.ToPagedList(page ?? 1, pageSize);
            // 過濾從client傳送過來有問題頁數，包含判斷有問題的頁數邏輯
            if (pagelist.PageNumber != 1 && page.HasValue && page > pagelist.PageCount)
                return null;
            return pagelist;
        }
        protected IQueryable<Store> GetStuffFromDatabase()
        {
            return _context.TableSTOREs1111757;
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("MEM_ACCOUNT") == null)
            {
                TempData["message"] = "Please Login!";
                return RedirectToAction("Login", "Account");
            }
            else if (HttpContext.Session.GetString("MEM_ACCOUNT") != "1111757")
            {
                TempData["message"] = "權限不夠!";
                return RedirectToAction("Discount", "Store");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DIS_ID,DIS_NAME,DIS_START,DIS_END")] Discount discount)
        {
            //用ModelState.IsValid判斷資料是否通過驗證
            if (ModelState.IsValid)
            {
                //將entity加入DbSet
                _context.TableDISCOUNTs1111757.Add(discount);
                //將資料異動儲存到資料庫
                await _context.SaveChangesAsync();
                //導向至Index動作方法
                return RedirectToAction(nameof(Discount));
            }

            return View(discount);
        }
        public async Task<IActionResult> Edit(string? ID)
        {
            if (HttpContext.Session.GetString("MEM_ACCOUNT") == null)
            {
                TempData["message"] = "Please Login!";
                return RedirectToAction("Login", "Account");
            }
            else if (HttpContext.Session.GetString("MEM_ACCOUNT") != "1111757")
            {
                TempData["message"] = "權限不夠!";
                return RedirectToAction("Discount", "Store");
            }

            var com = await _context.TableDISCOUNTs1111757.FindAsync(ID);
            if (com == null)
                return NotFound();

            return View(com);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string ID,
            [Bind("DIS_ID,DIS_NAME,DIS_START,DIS_END")] Discount discount)
        {
            if (ID != discount.DIS_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.TableDISCOUNTs1111757.Update(discount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DISExists(discount.DIS_ID))
                        return NotFound();
                    else
                        throw;
                }
            }
            return RedirectToAction(nameof(Discount));
        }
        private bool DISExists(string ID)
        {
            return _context.TableDISCOUNTs1111757.Any(e => e.DIS_ID == ID);
        }
        public async Task<IActionResult> Delete(string? ID)
        {
            if (HttpContext.Session.GetString("MEM_ACCOUNT") == null)
            {
                TempData["message"] = "Please Login!";
                return RedirectToAction("Login", "Account");
            }
            else if (HttpContext.Session.GetString("MEM_ACCOUNT") != "1111757")
            {
                TempData["message"] = "權限不夠!";
                return RedirectToAction("Discount", "Store");
            }

            var com = await _context.TableDISCOUNTs1111757.FindAsync(ID);

            if (com == null)
            {
                return NotFound();
            }
            return View(com);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string ID)
        {
            if (_context.TableDISCOUNTs1111757 == null)
            {
                return Problem("Entity set 'CmsContext.Table'  is null.");
            }

            //以Id找尋Entity，然後刪除
            var com = await _context.TableDISCOUNTs1111757.FindAsync(ID);

            if (com != null)
            {
                //將該筆資料移除
                _context.TableDISCOUNTs1111757.Remove(com);
                await _context.SaveChangesAsync();  //將資料異動儲存到資料庫
            }

            return RedirectToAction(nameof(Discount));
        }
    }
}
   
