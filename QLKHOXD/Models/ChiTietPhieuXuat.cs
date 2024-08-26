using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class ChiTietPhieuXuat
{
    public int MaPx { get; set; }

    public string MaVt { get; set; } = null!;

    public int? SoLuong { get; set; }

    public virtual PhieuXuat MaPxNavigation { get; set; } = null!;

    public virtual VatTu MaVtNavigation { get; set; } = null!;
}
