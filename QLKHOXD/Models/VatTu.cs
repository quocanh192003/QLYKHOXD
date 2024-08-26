using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class VatTu
{
    public string MaVt { get; set; } = null!;

    public string? TenVt { get; set; }

    public int? SoLuong { get; set; }

    public string? Donvitinh { get; set; }

    public string? Mota { get; set; }

    public string? TinhTrangVt { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; } = new List<ChiTietPhieuXuat>();
}
