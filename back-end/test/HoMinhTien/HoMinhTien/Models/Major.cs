using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoMinhTien.Models
{
    [Table("Majors")]
    public class Major
    {
        [Key]
        public int MajorID { get; set; }
        public string Name { get; set; }
    }
}
