using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Model.Dto
{
    public  class GetRequest<T>
    {
        public string? Url { get; set; }

        public string? Authorization { get; set; }

        public T? Data { get; set; }
    }
}
