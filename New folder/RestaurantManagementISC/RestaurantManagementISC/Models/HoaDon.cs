using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("HoaDon")]
    public class HoaDon
    {
        [Column("id_hoadon")]
        public int Id { get; set; }

        [Column("hd_ngaydat")]
        public DateTime ngaydat { get; set; }

        [Column("hd_trangthai")]
        public bool trangthai { get; set; }

        [Column("hd_ghichu")]
        public string ghichu { get; set; }

        public int id_nhanvien { get; set; }

        public int id_ban { get; set; }

        public int id_khachhang { get; set; }

        [ForeignKey("id_nhanvien")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("id_ban")]
        public virtual Ban Ban { get; set; }

        [ForeignKey("id_khachhang")]
        public virtual KhachHang KhachHang { get; set; }

        [NotMapped]
        public double tongtien { get; set; }
    }
}
