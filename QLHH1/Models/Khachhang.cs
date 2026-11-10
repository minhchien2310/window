using System;
using System.Collections.Generic;

namespace QLHH1.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Phieuthues = new HashSet<Phieuthue>();
        }

        public string MaKh { get; set; } = null!;
        public string TenKh { get; set; } = null!;
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<Phieuthue> Phieuthues { get; set; }
    }
}
