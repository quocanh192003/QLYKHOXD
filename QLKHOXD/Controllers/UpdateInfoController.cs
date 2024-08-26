using Microsoft.AspNetCore.Mvc;
using QLKHOXD.Models;

namespace QLKHOXD.Controllers
{
    public class UpdateInfoController : Controller
    {
        private readonly QlkhoxaydungContext _context;
        public UpdateInfoController(QlkhoxaydungContext context)
        {
            _context = context;
        }
        public IActionResult UpdateInformation()
        {
            var userid = HttpContext.Session.GetString("taikhoan");
            if(userid == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var nguoidung = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == userid);
            if (nguoidung == null)
            {
                return NotFound();
            }
            var vaiTro = _context.VaiTros.FirstOrDefault(x => x.IdVaitro == nguoidung.IdVaitro);
            ViewBag.vaitro = vaiTro.TenVaitro;
            return View(nguoidung);
        }

        [HttpPost]
        public IActionResult UpdateInformation(NguoiDung model, string oldPassword, string newPassword, string confirmPassword)
        {
            var userid = HttpContext.Session.GetString("taikhoan");
            if (userid == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var nguoidung = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == userid);
            if (nguoidung == null)
            {
                return NotFound();
            }

            // Cập nhật thông tin người dùng
            nguoidung.HoTen = model.HoTen;
            nguoidung.GioiTinh = model.GioiTinh;
            nguoidung.DienThoai = model.DienThoai;
            nguoidung.Email = model.Email;
            nguoidung.DiaChi = model.DiaChi;

            // Kiểm tra mật khẩu cũ và cập nhật mật khẩu mới nếu cần
            if (!string.IsNullOrEmpty(oldPassword) && !string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(confirmPassword))
            {
                if (nguoidung.MatKhau == oldPassword)
                {
                    if (newPassword == confirmPassword)
                    {
                        nguoidung.MatKhau = newPassword;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Mật khẩu mới và xác nhận mật khẩu không khớp.";

                        var vaiTro = _context.VaiTros.FirstOrDefault(x => x.IdVaitro == nguoidung.IdVaitro);
                        
                        return View(model);
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Mật khẩu cũ không đúng.";
                    var vaiTro = _context.VaiTros.FirstOrDefault(x => x.IdVaitro == nguoidung.IdVaitro);
                    
                    return View(model);
                }
            }

            _context.SaveChanges();
            TempData["SuccessMessage"] = "Thông tin đã được cập nhật thành công.";
            return RedirectToAction("UpdateInformation");
        }
    }
}
