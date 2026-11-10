using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QLHH1.Models
{
    public partial class Phieuthue
    {
        [DisplayName("Mã phiếu thuê")]
        [Required(ErrorMessage = "Mã phiếu thuê không được để trống!")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mã phiếu thuê phải nhập đủ 10 ký tự!")]
        public string MaPt { get; set; } = null!;

        [DisplayName("Ngày thuê")]
        [Required(ErrorMessage = "Ngày thuê không được để trống!")]
        public DateTime NgayThue { get; set; }

        [DisplayName("Ngày trả")]
        [Required(ErrorMessage = "Ngày trả không được để trống!")]
        [AssertThat("NgayTra >= NgayThue", ErrorMessage = "Ngày trả phải lớn hơn hoặc bằng Ngày thuê!")]
        public DateTime NgayTra { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Giá không được để trống!")]
        public decimal Gia { get; set; }

        [DisplayName("Mã khách hàng")]
        [Required(ErrorMessage = "Mã khách hàng không được để trống!")]
        public string MaKh { get; set; } = null!;

        public virtual Khachhang? MaKhNavigation { get; set; }

        [DisplayName("Số ngày thuê")]
        public int SoNgayThue => (NgayTra - NgayThue).Days + 1;

        [DisplayName("Thành tiền")]
        public decimal ThanhTien => SoNgayThue * Gia;
    }
}