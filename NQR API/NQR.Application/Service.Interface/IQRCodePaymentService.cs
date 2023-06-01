using NQR.Common.Shared;
using NQR.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQR.Application.Service.Interface
{
    public  interface IQRCodePaymentService
    {
        Task<GenericResponse<QRCodePaymentResponse>> QRCodePayment(QRCodePaymentRequest qrcodePaymentRequest);
        Task<GenericResponse<PaymentStatusResponse>> QRCodePaymentStatus(QRCodePaymentStatusRequest qrcodePaymentStatusRequest);
    }
}
