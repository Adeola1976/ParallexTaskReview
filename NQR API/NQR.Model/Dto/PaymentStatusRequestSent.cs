using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public  class PaymentStatusRequestSent
    {
        public string? institution_number { get; set; }

        public string? order_no { get; set; }

        public string? order_sn { get; set; }

        public string? timestamp { get; set; }

        public string? sign { get; set; }
      
    }
}
