using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoMinhTienFinal.Models
{
    [Table("BOOKs")]
    public class Book
    {
        [Key]
        public long BOO_ID { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public int CREATEDBY { get; set; }
        public string BARCODE { get; set; }
        public int STATUS { get; set; }

        public int TIT_ID { get; set; }
        [ForeignKey("TIT_ID")]
        public virtual Title Title { get; set; }

    }
}
