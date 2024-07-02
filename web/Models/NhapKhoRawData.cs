using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class NhapKhoRawData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Required(ErrorMessage ="Số Phiếu Nhập không được để trống")]
        public int NhapKhoId { get; set; }
        [ForeignKey("NhapKhoId")]
        public NhapKho NhapKho { get; set; }

        [Required]
        public int SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        public SanPham SanPham { get; set; }

        [Required]
        public int SLNhap { get; set; }

        [Required]
        public decimal DonGiaNhap { get; set; }

       
        public decimal TriGia => SLNhap * DonGiaNhap;

        [NotMapped]
        public int TempId { get; set; }
    }
}
