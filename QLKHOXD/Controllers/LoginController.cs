using Microsoft.AspNetCore.Mvc;
using QLKHOXD.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
namespace QLKHOXD.Controllers;

public class LoginController : Controller
{
    private readonly QlkhoxaydungContext _context;
    public LoginController(QlkhoxaydungContext context) => _context = context;
   
    public IActionResult Login(){
        return View();
    }

    [HttpPost]
    public IActionResult Login(string taikhoan, string password){
        var user = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == taikhoan && x.MatKhau == password);
        if(user != null && user.IdVaitro == 1){
            HttpContext.Session.SetString("taikhoan", user.TaiKhoan);
            HttpContext.Session.SetString("manv", user.MaNv);
            HttpContext.Session.SetString("hoten", user.HoTen);
                      
            return RedirectToAction("Index", "Home");
        }
        if(user != null && user.IdVaitro == 2){
            HttpContext.Session.SetString("taikhoan", user.TaiKhoan);
            HttpContext.Session.SetString("manv", user.MaNv);
            HttpContext.Session.SetString("hoten", user.HoTen);
           
            return RedirectToAction("Index", "Home");
        }
        if(user != null && user.IdVaitro == 3){
            HttpContext.Session.SetString("taikhoan", user.TaiKhoan);
            HttpContext.Session.SetString("manv", user.MaNv);
            HttpContext.Session.SetString("hoten", user.HoTen);
            
            return RedirectToAction("Index", "Home");
        }
        return RedirectToAction("Login", "Login");
    }

    public ActionResult LogOut()
    {   
        if(HttpContext.Session.GetString("taikhoan") != null){
            HttpContext.Session.Remove("taikhoan");
        }
        if(HttpContext.Session.GetString("taikhoan") != null){
            HttpContext.Session.Remove("taikhoan");
        }
        
        HttpContext.SignOutAsync();
        return RedirectToAction("Login", "Login");  
    }
}
