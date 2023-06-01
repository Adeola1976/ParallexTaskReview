using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class DynamicQRCodeRequest
    {
        public string? mch_no { get; set; }

        public string? sub_mch_no { get; set; }

        public string? amount { get; set; }
    }
}
