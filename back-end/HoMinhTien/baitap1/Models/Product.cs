using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace baitap1.Models
{
    [Table("Products")]
    public class Product
    {
        [Column("Product_ID")]
        public long Id { get; set; }

        public string ProductID { get; set; }

        [Column("ProductName")]
        public String Name { get; set; }

    }
}
