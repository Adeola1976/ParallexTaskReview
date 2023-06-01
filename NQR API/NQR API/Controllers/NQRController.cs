using Microsoft.AspNetCore.Mvc;
using NQR.Application.Service.Interface;
using NQR.Model.Dto;

namespace NQR_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NQRController : ControllerBase
    {
        public IQRCodeService _qRCodeService;
        public IQRCodePaymentService _qRCodePaymentService;

        public NQRController(IQRCodeService qRcodeService, IQRCodePaymentService qRCodePaymentService)
        {
            _qRCodeService = qRcodeService;
            _qRCodePaymentService = qRCodePaymentService;
        }

        [HttpGet("getQrCodeInfromation")] 
        public IActionResult QrcodeInfromation (string qrcodedata) 
        {
            var response = _qRCodeService.GetQrFieldObject(qrcodedata);
            return Ok(response);
        }

        [HttpPost("generateQrcode")]
        public async Task<IActionResult> GenerateQrcode(DynamicQRCodeRequest dynamicQRCodeRequest)
        {
            var response = await _qRCodeService.GenerateDynamicQrCode(dynamicQRCodeRequest);
            return Ok(response);
        }


        [HttpPost("makePaymentWithQrcodeScanner")]
        public async Task<IActionResult> MakePaymentWithQrcodeScanner(QRCodePaymentRequest qrcodePaymentRequest)
        {
            var response = await _qRCodePaymentService.QRCodePayment(qrcodePaymentRequest);
            return Ok(response);
        }

        [HttpPost("getpaymentStatus")]
        public async Task<IActionResult> GetPaymentStatus(QRCodePaymentStatusRequest qrcodePaymentStatusRequest)
        {
            var response = await _qRCodePaymentService.QRCodePaymentStatus(qrcodePaymentStatusRequest);
            return Ok(response);
        }
    }
}
