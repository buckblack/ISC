using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Column("id_nhanvien")]
        public int Id { get; set; }

        [Column("nv_ho")]
        public string honhanvien { get; set; }

        [Column("nv_ten")]
        public string tennhanvien { get; set; }

        [Column("nv_email")]
        public string email { get; set; }

        [Column("nv_password")]
        public string password { get; set; }

        [Column("nv_diachi")]
        public string diachi { get; set; }

        [Column("nv_trangthai")]
        public bool trangthai { get; set; }
    }
}
