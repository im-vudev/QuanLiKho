using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class XuatKhoRawData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Required(ErrorMessage ="Tên Phiếu Xuất không được để trống")]
        public int XuatKhoId { get; set; }
        [ForeignKey("XuatKhoId")]
        public XuatKho XuatKho { get; set; }

        [Required(ErrorMessage ="Sản phẩm không được để trống")]
        public int SanPhamId { get; set; }
        [ForeignKey("SanPhamId")]
        public SanPham SanPham { get; set; }

        [Required]
        public int SLXuat { get; set; }

        [Required]
        public decimal DonGiaXuat { get; set; }

        [NotMapped]
        public decimal TriGia => SLXuat * DonGiaXuat;
    }
}
