using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class DonViTinh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_ID { get; set; }

        [Required(ErrorMessage = "Đơn Vị Tính Không được để trống")]
        [MaxLength(100)]
        public string Ten_Don_Vi_Tinh { get; set; }

        public string? Ghi_Chu { get; set; }

        //
        public ICollection<SanPham> SanPhams { get; set; }

    }
}
