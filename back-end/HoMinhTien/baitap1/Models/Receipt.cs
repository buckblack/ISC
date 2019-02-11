using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace baitap1.Models
{
    [Table("Receipts")]
    public class Receipt
    {
        [Column("Receipt_ID")]
        public long Id { get; set; }

        public DateTime ReceiptDate { get; set; }

        public long Customer_ID { get; set; }
        [ForeignKey("Customer_ID")]//lệnh của lệnh phía dưới

        public virtual Customer Customer { get; set; }//lazy loading : virtual
    }
}
