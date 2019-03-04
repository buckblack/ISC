using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codefirst.Models.request
{
    public class PagingResquest
    {
        public int Size { get; set; } = 20;//mặc định
        public int Page { get; set; } = 1;
    }
}
