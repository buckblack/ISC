using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("ChiTietDatBan")]
    public class ChiTietDatBan
    {
        [Column("id_ctdatban")]
        public int Id { get; set; }

        [Column("ctdb_soluong")]
        public int soluong { get; set; }

        [Column("ctdb_dongia")]
        public double dongia { get; set; }

        public int id_monan { get; set; }

        public int id_hoadon { get; set; }

        [ForeignKey("id_monan")]
        public virtual MonAn MonAn { get; set; }

        [ForeignKey("id_hoadon")]
        public virtual HoaDon HoaDon { get; set; }
    }
}
