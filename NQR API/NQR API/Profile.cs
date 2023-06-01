using AutoMapper;
using NQR.Model.Dto;

namespace NQR_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DynamicQRCodeResponse, DynamicQRCodeRequest>().ReverseMap();
            CreateMap<QRCodePaymentRequestSent, QRCodePaymentRequest>().ReverseMap();
        }
    }
}
