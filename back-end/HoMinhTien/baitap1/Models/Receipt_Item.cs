using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace baitap1.Models
{
    [Table("Receipt_Items")]
    public class Receipt_Item
    {
        [Column("ReceiptItem_ID")]
        public long Id { get; set; }

        [Column("ProductQuantity")]
        public int Quantity { get; set; }

        [Column("ProductPrice")]
        public decimal Price { get; set; }

        public long Product_ID { get; set; }
        [ForeignKey("Product_ID")]
        public virtual Product Product { get; set; }

        public long Receipt_ID { get; set; }
        [ForeignKey("Receipt_ID")]
        public virtual Receipt Receipt { get; set; }

    }
}
