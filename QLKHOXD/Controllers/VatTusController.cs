using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLKHOXD.Models;

namespace QLKHOXD.Controllers
{
    public class VatTusController : Controller
    {
        private readonly QlkhoxaydungContext _context;

        public VatTusController(QlkhoxaydungContext context)
        {
            _context = context;
        }

        // GET: VatTus
        public async Task<IActionResult> DSVatTu()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 2)
                {
                    return View(await _context.VatTus.ToListAsync());
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        // GET: VatTus/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatTu = await _context.VatTus
                .FirstOrDefaultAsync(m => m.MaVt == id);
            if (vatTu == null)
            {
                return NotFound();
            }

            return View(vatTu);
        }

        // GET: VatTus/Create
        public IActionResult Create()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 2)
                {
                    return View();
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        // POST: VatTus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaVt,TenVt,SoLuong,Donvitinh,Mota,TinhTrangVt")] VatTu vatTu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vatTu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vatTu);
        }

        // GET: VatTus/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatTu = await _context.VatTus.FindAsync(id);
            if (vatTu == null)
            {
                return NotFound();
            }
            return View(vatTu);
        }

        // POST: VatTus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaVt,TenVt,SoLuong,Donvitinh,Mota,TinhTrangVt")] VatTu vatTu)
        {
            if (id != vatTu.MaVt)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vatTu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VatTuExists(vatTu.MaVt))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vatTu);
        }

        // GET: VatTus/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatTu = await _context.VatTus
                .FirstOrDefaultAsync(m => m.MaVt == id);
            if (vatTu == null)
            {
                return NotFound();
            }

            return View(vatTu);
        }

        // POST: VatTus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vatTu = await _context.VatTus.FindAsync(id);
            if (vatTu != null)
            {
                _context.VatTus.Remove(vatTu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VatTuExists(string id)
        {
            return _context.VatTus.Any(e => e.MaVt == id);
        }
    }
}
