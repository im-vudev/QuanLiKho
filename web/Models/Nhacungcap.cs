using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class NCC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_ID { get; set; }

        [Required(ErrorMessage ="Mã Nhà Cung Cấp không được để trống")]
        [MaxLength(100)]
        public string Ma_NCC { get; set; }

        [Required(ErrorMessage = "Tên Nhà Cung Cấp Không được để trống")]
        [MaxLength(100)]
        public string Ten_NCC { get; set; }

        public string? Ghi_Chu { get; set; }

        public ICollection<NhapKho> NhapKhos { get; set; } = new List<NhapKho>();
    }
}