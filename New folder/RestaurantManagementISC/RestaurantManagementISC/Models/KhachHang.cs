using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Column("id_khachhang")]
        public int Id { get; set; }

        [Column("kh_ho")]
        public string hokhachhang { get; set; }

        [Column("kh_ten")]
        public string tenkhachhang { get; set; }

        [Column("kh_email")]
        public string email { get; set; }

        [Column("kh_diachi")]
        public string diachi { get; set; }

        [Column("kh_dienthoai")]
        public string dienthoai { get; set; }

        [Column("kh_ghichu")]
        public string ghichu { get; set; }
    }
}
