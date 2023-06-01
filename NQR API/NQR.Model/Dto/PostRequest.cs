using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public class PostRequest<T>
    {
        public string Url { get; set; }

        public string? client_id { get; set; }

        public string? scope { get; set; }

        public string? client_secret { get; set; }

        public string? grand_type { get; set; }

        public T Data { get; set; }
    }

    public class AuthPostRequest<T>
    {
        public string Url { get; set; }
        public string authorization { get; set; }
        public T Data { get; set; }
    }
}
