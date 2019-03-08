using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoMinhTienFinal.Models
{
    [Table("MEMBERS")]
    public class Member
    {
        [Key]
        public int MEM_ID { get; set; }
        public string ACCOUNT { get; set; }
        public string PASSWORD { get; set; }
        public string FULLNAME { get; set; }
        public Boolean GENDER { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        public DateTime CREATEDDATE { get; set; }
        public int CREATEDBY { get; set; }
    }
}
