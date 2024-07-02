using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
   public class SanPham
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Auto_ID { get; set; }

    [Required(ErrorMessage ="Mã Sản Phẩm không được để trống")]
    [MaxLength(100)]
    public string Ma_San_Pham { get; set; }

    [Required(ErrorMessage ="Tên Sản phẩm không được để trống")]
    [MaxLength(100)]
    public string Ten_San_Pham { get; set; }

    [Required]
    public int Loai_San_Pham_ID { get; set; }
    [ForeignKey("Loai_San_Pham_ID")]
    public LoaiSanPham LoaiSanPham { get; set; }

    [Required]
    public int Don_Vi_Tinh_ID { get; set; }
    [ForeignKey("Don_Vi_Tinh_ID")]
    public DonViTinh DonViTinh{ get; set; }

    public string? Ghi_Chu { get; set; }

        public ICollection<NhapKhoRawData> ChiTietNhapKhos { get; set; } = new List<NhapKhoRawData>();
        public ICollection<XuatKhoRawData> ChiTietXuatKhos { get; set; } = new List<XuatKhoRawData>();
    }
}
