using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class DynamicQRCodeResponse
    {
        public string? ReturnCode { get; set; }

        public string? OrderSn { get; set; }

        public string? CodeUrl { get; set; }

        public string? ReturnMsg { get; set; }
    }
}
