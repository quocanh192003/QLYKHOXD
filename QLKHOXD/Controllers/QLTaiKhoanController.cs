using Microsoft.AspNetCore.Mvc;
using QLKHOXD.Models;

namespace QLKHOXD.Controllers
{
    public class QLTaiKhoanController : Controller
    {
        private readonly QlkhoxaydungContext _context;
        public QLTaiKhoanController(QlkhoxaydungContext context)
        {
            _context = context;
        }
        public IActionResult QLTaiKhoan()
        {
            return View();
        }
    }
}
