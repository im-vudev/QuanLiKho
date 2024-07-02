using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class XuatKho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SoPhieuXuatKho { get; set; }

        [Required(ErrorMessage =" Chưa chọn Kho")]
        public int KhoId { get; set; }
        [ForeignKey("KhoId")]
        public Kho Kho { get; set; }

        [Required(ErrorMessage ="Chọn ngày")]
        public DateTime NgayXuatKho { get; set; }

        public string? GhiChu { get; set; }

        public ICollection<XuatKhoRawData> ChiTietXuatKhos { get; set; } = new List<XuatKhoRawData>();
    }
}
