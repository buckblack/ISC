using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("MonAn")]
    public class MonAn
    {
        [Column("id_monan")]
        public int Id { get; set; }

        [Column("ma_ten")]
        public string tenmonan { get; set; }

        [Column("ma_dongia")]
        public double dongia { get; set; }

        [Column("ma_hinh")]
        public string hinhanh { get; set; }

        [Column("ma_trangthai")]
        public string trangthai { get; set; }

        [Column("ma_noidung")]
        public string noidung { get; set; }

        public int id_loaimonan { get; set; }

        [ForeignKey("id_loaimonan")]
        public virtual LoaiMonAn LoaiMonAn { get; set; }
    }
}
