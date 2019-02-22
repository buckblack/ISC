using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("PhieuNhapTra")]
    public class PhieuNhapTra
    {
        [Column("id_phieu")]
        public int Id { get; set; }

        [Column("pnt_ngaylap")]
        public DateTime ngaylap { get; set; }

        [Column("pnt_loaiphieu")]
        public string loaiphieu { get; set; }

        public int id_nhanvien { get; set; }

        public int id_nhacungcap { get; set; }

        [ForeignKey("id_nhanvien")]
        public virtual NhanVien NhanVien { get; set; }

        [ForeignKey("id_nhacungcap")]
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
