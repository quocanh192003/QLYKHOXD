using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class PhieuNhap
{
    public int MaPn { get; set; }

    public DateOnly? NgayNhap { get; set; }

    public string? GhiChu { get; set; }

    public string? MaNv { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NguoiDung? MaNvNavigation { get; set; }
}
