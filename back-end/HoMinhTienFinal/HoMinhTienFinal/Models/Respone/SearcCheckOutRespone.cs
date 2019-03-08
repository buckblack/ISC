using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoMinhTienFinal.Models.Respone
{
    public class SearcCheckOutRespone
    {
        public long CheckOutID { get; set; }
        public DateTime CreateDate { get; set; }
        public string MemberName { get; set; }
        public string LibrarianName { get; set; }
        public int Book_borrowed { get; set; }
    }
}
