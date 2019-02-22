using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("ChiTietPhieu")]
    public class ChiTietPhieu
    {
        [Column("id_ctphieu")]
        public int Id { get; set; }

        [Column("ctp_soluong")]
        public int soluong { get; set; }

        [Column("ctp_gia")]
        public int gia { get; set; }

        public int id_phieu { get; set; }

        public int id_nguyenlieu { get; set; }

        [ForeignKey("id_phieu")]
        public virtual PhieuNhapTra PhieuNhapTra { get; set; }

        [ForeignKey("id_nguyenlieu")]
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
