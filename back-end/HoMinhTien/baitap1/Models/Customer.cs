using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace baitap1.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Column("Customer_ID")]
        public long Id { get; set; }

        public string CustomerID { get; set; }

        [Column("CustomerName")]
        public string Name { get; set; }

        [Column("CustomerAddress")]
        public string Address { get; set; }
    }
}
