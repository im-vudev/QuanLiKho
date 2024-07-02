using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class KhoUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }

        [Required (ErrorMessage ="Mã Đăng Nhập Không được để trống")]
        [MaxLength(100)]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required (ErrorMessage ="Kho không được để trống")]
        public int KhoId { get; set; }

        [ForeignKey("KhoId")]
        public Kho Kho { get; set; }
    }
}
