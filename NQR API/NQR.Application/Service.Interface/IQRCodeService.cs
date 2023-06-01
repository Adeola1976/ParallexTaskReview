using NQR.Common.Shared;
using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Application.Service.Interface
{
    public interface IQRCodeService
    {
        GenericResponse<QrObjects> GetQrFieldObject(string qrdata);

        Task<GenericResponse<DynamicQRCodeResponse>> GenerateDynamicQrCode(DynamicQRCodeRequest dynamicQRCodeRequest);
    }
}
