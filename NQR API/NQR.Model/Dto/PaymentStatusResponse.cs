using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class PaymentStatusResponse
    {
        public string? ReturnCode { get; set; }

        public string? order_no { get; set; }

        public string? order_sn { get; set; }

        public string? ReturnMsg { get; set; }
    }
}
