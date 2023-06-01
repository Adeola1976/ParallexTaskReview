using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public  class QRCodePaymentRequest
    {

        public string? reference { get; set; }
        
        public string? order_amount { get; set; }

        public string? user_account_number { get; set; }

        public string? user_gps { get; set; }

        public string? user_kyc_level { get; set; }

        public string? user_bank_no { get; set; }

        public string? user_bank_verification_number { get; set; }

    }
}
