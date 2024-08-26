using Microsoft.AspNetCore.Mvc;
using QLKHOXD.Models;
using System.Diagnostics;
using System.Linq;
namespace QLKHOXD.Controllers
{
    public class PheDuyetController : Controller
    {
        private readonly QlkhoxaydungContext _context;

        public PheDuyetController(QlkhoxaydungContext context)
        {
            _context = context;
        }
        public IActionResult PhieuNhap()
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
                    List<PhieuNhap> pn = _context.PhieuNhaps.Where(x => x.TrangThai == "Pending Approval").ToList();
                    List<NguoiDung> nv = _context.NguoiDungs.ToList();

                    ViewBag.nv = nv;
                    return View(pn);
                }
                
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        public IActionResult PhieuXuat()
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
                    List<PhieuXuat> px = _context.PhieuXuats.Where(x => x.TrangThai == "Pending Approval").ToList();
                    List<NguoiDung> nv = _context.NguoiDungs.ToList();
                    ViewBag.nv = nv;
                    return View(px);
                }
                
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        [HttpGet]
        public IActionResult ChiTietPN(int id)
        {
            List<ChiTietPhieuNhap> ctpn = _context.ChiTietPhieuNhaps.Where(x => x.MaPn == id).ToList();
            List<VatTu> vt = _context.VatTus.ToList();
            ViewBag.vt = vt;
            return View(ctpn);
        }
        [HttpPost]
        public IActionResult XacNhan(int maPn)
        {
            var phieuNhap = _context.PhieuNhaps.FirstOrDefault(p => p.MaPn == maPn);
            if (phieuNhap != null)
            {
                try
                {
                    phieuNhap.TrangThai = "Approval";
                    _context.SaveChanges();
                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    // Log lỗi
                    Debug.WriteLine($"Error updating record: {ex.Message}");
                    return Json(new { success = false, message = ex.Message });
                }
            }
            return Json(new { success = false, message = "Record not found" });
        }
    }
}
