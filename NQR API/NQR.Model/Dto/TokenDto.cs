using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class TokenDto
    {
        public string? token_type { get; set; }

        public string? expires_in { get; set; }

        public string? ext_expires_in { get; set; }

        public string? access_token { get; set; }

        public string? error { get; set; }

        public string? error_description { get; set; }

        //public ErrorCode error_codes { get; set; }

        public string trace_id { get; set; }

        public string correlation_id { get; set; }

        public string? timestamp { get; set; }

        public string? error_uri { get; set; }
    }

    public class ErrorCode
    {
        public int error_codes  { get; set; }
    }
}
