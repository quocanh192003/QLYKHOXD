using System;
using System.Collections.Generic;

namespace QLKHOXD.Models;

public partial class VaiTro
{
    public int IdVaitro { get; set; }

    public string? TenVaitro { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
