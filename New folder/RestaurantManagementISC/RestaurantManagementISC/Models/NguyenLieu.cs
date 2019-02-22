using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("NguyenLieu")]
    public class NguyenLieu
    {
        [Column("id_nguyenlieu")]
        public int Id { get; set; }

        [Column("nl_ten")]
        public string tennguyenlieu { get; set; }

        [Column("nl_donvitinh")]
        public string donvitinh { get; set; }

        [Column("nl_soluong")]
        public double soluong { get; set; }
    }
}
