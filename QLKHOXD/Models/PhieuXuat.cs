using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class PhieuXuat
{
    public int MaPx { get; set; }

    public DateOnly? NgayXuatHang { get; set; }

    public string? GhiChu { get; set; }

    public string? MaNv { get; set; }

    public string? MaNguoiNhan { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = new List<ChiTietPhieuXuat>();

    public virtual NguoiDung? MaNvNavigation { get; set; }
}
