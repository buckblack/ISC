using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementISC.Models.VewModels
{
    public class MonAnRequest
    {      
        public string tenmonan { get; set; }

        public double dongia { get; set; }

        public string hinhanh { get; set; }

        public string trangthai { get; set; }

        public string noidung { get; set; }

        public int id_loaimonan { get; set; }
    }
}
