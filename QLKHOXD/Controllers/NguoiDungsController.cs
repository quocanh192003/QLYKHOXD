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
    public class NguoiDungsController : Controller
    {
        private readonly QlkhoxaydungContext _context;

        public NguoiDungsController(QlkhoxaydungContext context)
        {
            _context = context;
        }

        // GET: NguoiDungs
        public async Task<IActionResult> NhanVien()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 1)
                {
                    var qlkhoxaydungContext = _context.NguoiDungs.Include(n => n.IdVaitroNavigation).Where(x =>x.IdVaitro == 2);
                    return View(await qlkhoxaydungContext.ToListAsync());
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        public async Task<IActionResult> ChuThau()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 1)
                {
                    var qlkhoxaydungContext = _context.NguoiDungs.Include(n => n.IdVaitroNavigation).Where(x =>x.IdVaitro == 3);
                    return View(await qlkhoxaydungContext.ToListAsync());
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        // GET: NguoiDungs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .Include(n => n.IdVaitroNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: NguoiDungs/Create
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
                if (user.IdVaitro == 1)
                {
                    ViewData["IdVaitro"] = new SelectList(_context.VaiTros, "IdVaitro", "IdVaitro");
                    return View();
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        // POST: NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNv,HoTen,TaiKhoan,MatKhau,IdVaitro,GioiTinh,DienThoai,Email,DiaChi,TrangThai,NgayTao")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVaitro"] = new SelectList(_context.VaiTros, "IdVaitro", "IdVaitro", nguoiDung.IdVaitro);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            ViewData["IdVaitro"] = new SelectList(_context.VaiTros, "IdVaitro", "IdVaitro", nguoiDung.IdVaitro);
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNv,HoTen,TaiKhoan,MatKhau,IdVaitro,GioiTinh,DienThoai,Email,DiaChi,TrangThai,NgayTao")] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.MaNv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungExists(nguoiDung.MaNv))
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
            ViewData["IdVaitro"] = new SelectList(_context.VaiTros, "IdVaitro", "IdVaitro", nguoiDung.IdVaitro);
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .Include(n => n.IdVaitroNavigation)
                .FirstOrDefaultAsync(m => m.MaNv == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDungs.Remove(nguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungExists(string id)
        {
            return _context.NguoiDungs.Any(e => e.MaNv == id);
        }
    }
}
