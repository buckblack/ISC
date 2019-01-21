using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace todoapi.Models
{
    [Table("Todos")]
    public class TodoItem
    {
        
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }

}
