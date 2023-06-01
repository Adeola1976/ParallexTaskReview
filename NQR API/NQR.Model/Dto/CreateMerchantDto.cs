using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public  class CreateMerchantDto
    {
        public string? institution_number { get; set; }

        public string? name { get; set; }

        public string? tin { get; set; }

        public string? contact { get; set; }

        public string? phone { get; set; }

        public string? email { get; set; }

        public string? address { get; set; }

        public string? bank_no { get; set; }

        public string? account_name { get; set; }

        public string? account_number { get; set; }

        public string? m_fee_bearer { get; set; }

        public string? timestamp { get; set; }

        public string? sign { get; set; }
    }
}
