using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace codefirst.Models.respone
{
    public class PagingInfo
    {
        public long TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 20;//mặc định
        public int CurrentPage { get; set; } = 1;
    }
}
