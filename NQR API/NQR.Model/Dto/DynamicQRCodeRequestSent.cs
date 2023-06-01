using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class DynamicQRCodeRequestSent
    {
        public string? channel { get; set; }

        public string? institution_number { get; set; }

        public string? mch_no { get; set; }

        public string? sub_mch_no { get; set; }

        public string? code_type { get; set; }

        public string? amount { get; set; }

        public string? order_no { get; set; }

        public string? order_type { get; set; }

        public string? timestamp { get; set; }

        public string? sign { get; set; }
    }
}
