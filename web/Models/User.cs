using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Auto_ID { get; set; }

        [Required (ErrorMessage ="Mã Đăng nhập không được để trống")]
        [MaxLength(100)]
        public string Ma_Dang_Nhap { get; set; }

        [Required(ErrorMessage =" Mật Khẩu không được để trống")]
        [MaxLength(100)]
        public string Mat_Khau { get; set; }

        [Required(ErrorMessage ="Họ Tên không được để trống")]
        [MaxLength(200)]
        public string Ho_Ten { get; set; }

        public string? Ghi_Chu { get; set; }

        public ICollection<KhoUser> KhoUsers { get; set; }
    }
}

