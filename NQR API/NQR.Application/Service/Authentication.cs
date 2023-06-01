using AutoMapper;
using Microsoft.Extensions.Configuration;
using NQR.Application.Service;
using NQR.Common.Shared;
using NQR.Common.Shared.HttpService;
using NQR.Model.Dto;

namespace NQR.Application
{
    public class Authentication : IAuthentication
    {
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public readonly IHttpService _httpService;

        public Authentication(IMapper mapper, IConfiguration configuration, IHttpService httpService)
        {
            _mapper = mapper;
            _configuration = configuration;
            _httpService = httpService;
        }

        public async Task<GenericResponse<TokenDto>> GetToken()
        {
            try
            {

               

                var req = new PostRequest<AuthRequest>
                {
                    Url = _configuration.GetSection("EndpointUrl")["Auth"],
                    client_id = _configuration.GetSection("Authentication")["Client_id"],
                    scope = $"{_configuration.GetSection("Authentication")["Client_id"]}/.default",
                    client_secret = _configuration.GetSection("Authentication")["Client_secret"],
                    grand_type = _configuration.GetSection("Authentication")["Grant_Type"],
                };

                var authresponse = await _httpService.SendPostRequest<TokenDto, AuthRequest>(req);
                if(!string.IsNullOrEmpty(authresponse.error))
                {
                    return new GenericResponse<TokenDto>
                    {
                        ResponseCode = "99",
                        ResponseMessage = $"{authresponse.error}",
                        IsSuccessful = false,
                        Data = authresponse
                    };
                }

                return new GenericResponse<TokenDto>
                {
                    ResponseCode = "00",
                    ResponseMessage = $"authenticate successfully",
                    IsSuccessful = true,
                    Data = authresponse
                };

            }

            catch (Exception ex)
            {
                //log implementation
                return new GenericResponse<TokenDto>
                {
                    ResponseCode = "99",
                    ResponseMessage = "An error occur, while trying to authenticate a user",
                    IsSuccessful = false,
                    Data = null
                };
            }
           
        }
    }
}