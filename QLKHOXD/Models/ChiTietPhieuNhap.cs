using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class ChiTietPhieuNhap
{
    public int MaPn { get; set; }

    public string MaVt { get; set; } = null!;

    public int? SoLuong { get; set; }

    public DateOnly? NgaySx { get; set; }

    public virtual PhieuNhap MaPnNavigation { get; set; } = null!;

    public virtual VatTu MaVtNavigation { get; set; } = null!;
}
