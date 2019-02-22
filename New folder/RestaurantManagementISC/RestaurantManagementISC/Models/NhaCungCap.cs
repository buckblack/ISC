using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Column("id_nhacungcap")]
        public int Id { get; set; }

        [Column("ncc_ten")]
        public string ten { get; set; }

        [Column("ncc_email")]
        public string email { get; set; }

        [Column("ncc_dienthoai")]
        public string dienthoai { get; set; }

        [Column("ncc_diachi")]
        public string diachi { get; set; }
    }   
}
