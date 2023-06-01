using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class AuthRequest
    {
        public string? client_id { get; set; }

        public string? scope { get; set; }

        public string? client_secret { get; set; }

        public string? grand_type { get; set; }
    }
}
