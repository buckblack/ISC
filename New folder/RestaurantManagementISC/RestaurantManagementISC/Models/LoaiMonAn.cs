using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("LoaiMonAn")]
    public class LoaiMonAn
    {
        [Column("id_loaimonan")]
        public int Id { get; set; }

        [Column("lma_ten")]
        public string tenloai { get; set; }

        [Column("lma_mota")]
        public string mota { get; set; }
    }
}
