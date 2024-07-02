using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_ID { get; set; }

        [Required(ErrorMessage ="Mã Loại Sản Phẩm không được để trống")]
        [MaxLength(100)]
        public string Ma_LSP { get; set; }

        [Required (ErrorMessage ="Tên Loại Sản Phẩm không được để trống")]
        [MaxLength(100)]
        public string Ten_LSP { get; set; }

        public string? Ghi_Chu { get; set; }

        //
        public ICollection<SanPham> SanPhams { get; set; }
    }
}
