using Microsoft.AspNetCore.Mvc;
using QLKHOXD.Models;
using System.Diagnostics;
using System.Linq;

namespace QLKHOXD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QlkhoxaydungContext _context;
        public HomeController(ILogger<HomeController> logger, QlkhoxaydungContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var countemployee = _context.NguoiDungs.Where(x => x.IdVaitro == 2);
            var countbuilder = _context.NguoiDungs.Where(x => x.IdVaitro ==3);
            var countPN = _context.PhieuNhaps.Count(x => x.TrangThai == "Pending Approval" || x.TrangThai== "Approval");
            var countPX = _context.PhieuXuats.Count(x => x.TrangThai == "Pending Approval" || x.TrangThai == "Approval");
            List<VatTu> vatTus = _context.VatTus.ToList();

            var vt = HttpContext.Session.GetString("hoten");
            ViewBag.vt = vt;

            ViewBag.countemployee = countemployee.Count();
            ViewBag.countbuilder = countbuilder.Count();    
            ViewBag.countPN = countPN;
            ViewBag.countPX = countPX;
            return View(vatTus);
        }

        public IActionResult TaoPhieuNhap()
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

        public IActionResult TaoPhieuXuat()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 3)
                {
                    return View();
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        public IActionResult BaoCaoVT()
        {
            var vt = HttpContext.Session.GetString("taikhoan");
            if (vt == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (vt != null)
            {
                var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == vt);
                if (user.IdVaitro == 3)
                {
                    return View();
                }
            }
            return RedirectToAction("ErrorQTC", "Home");
        }
        public IActionResult XacNhanDaNhap()
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
                    List<PhieuNhap> pn = _context.PhieuNhaps.Where(x => x.TrangThai == "Approval").ToList();
                    List<NguoiDung> nv = _context.NguoiDungs.ToList();

                    ViewBag.nv = nv;
                    return View(pn);
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        public IActionResult XacNhanDaXuat()
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
                    List<PhieuXuat> px = _context.PhieuXuats.Where(x => x.TrangThai == "Approval").ToList();
                    List<NguoiDung> nv = _context.NguoiDungs.ToList();
                    ViewBag.nv = nv;
                    return View(px);
                }
            }
            return RedirectToAction("ErrorQTC", "Home");

        }

        public IActionResult ErrorQTC() 
        {         
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
