using NQR.Common.Shared;
using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Application.Service
{
     public  interface IAuthentication
    {
        Task<GenericResponse<TokenDto>>  GetToken();
    } 
}
