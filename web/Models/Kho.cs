using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Kho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_ID { get; set; }

        [Required (ErrorMessage ="Tên Kho Không Được để trống ")]
        [MaxLength(100)]
        public string Ten_Kho { get; set; }

        public string? Ghi_Chu { get; set; }

        public ICollection<KhoUser> KhoUsers { get; set; }
        public ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();
        public ICollection<XuatKho> XuatKhos { get; set; } = new List<XuatKho>();
    }

}
