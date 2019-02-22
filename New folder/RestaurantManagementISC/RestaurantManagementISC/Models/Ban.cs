using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("Ban")]
    public class Ban
    {
        [Column("id_ban")]
        public int Id { get; set; }

        [Column("b_soban")]
        public int soban { get; set; }

        [Column("b_trangthai")]
        public bool trangthai { get; set; }

        [Column("b_hoadon_phucvu")]
        public Nullable<int> hoadonphucvu { get; set; }
    }
}
