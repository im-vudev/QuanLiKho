using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class NhapKho
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_Id { get; set; }

        [Required(ErrorMessage ="Số Phiếu Nhập Không được để trống")]
        [MaxLength(100)]
        public string SoPhieuNhapKho { get; set; }

        [Required (ErrorMessage ="Kho không được để trống ")]
        public int KhoId { get; set; }
        [ForeignKey("KhoId")]
        public Kho Kho { get; set; }

        [Required(ErrorMessage ="Nhà cung cấp không được để trống")]
        public int NCC_Id { get; set; }
        [ForeignKey("NCC_Id")]
        public NCC NCC { get; set; }

        [Required(ErrorMessage = "Ngày tháng không được để trống ")]
        public DateTime NgayNhapKho { get; set; }

        public string? GhiChu { get; set; }

        public ICollection<NhapKhoRawData> ChiTietNhapKhos { get; set; } = new List<NhapKhoRawData>();

    }
}
