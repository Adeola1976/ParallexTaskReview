using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Common.Shared.HttpService
{
    public interface IHttpService
    {
        Task<T> SendPostRequest<T, U>(PostRequest<U> request);
        Task<T> SendAuthPostRequest<T, U>(AuthPostRequest<U> request);
        Task<T> SendAuthGetRequest<T, U>(GetRequest<U> request);
    }
}
