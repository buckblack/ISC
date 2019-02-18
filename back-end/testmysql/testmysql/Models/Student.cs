using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testmysql.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Code { get; set; }
        [Column("StudentName")]
        [MaxLength(100)]
        public string Name { get; set; }
        public int MajorID { get; set; }
        [ForeignKey("MajorID")]
        public virtual Major Major { get; set; }
    }
}
