using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class NguoiDung
{
    public string MaNv { get; set; } = null!;

    public string? HoTen { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public int? IdVaitro { get; set; }

    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? TrangThai { get; set; }

    public DateOnly? NgayTao { get; set; }

    public virtual VaiTro? IdVaitroNavigation { get; set; }

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();

    public virtual ICollection<PhieuXuat> PhieuXuats { get; set; } = new List<PhieuXuat>();
}
