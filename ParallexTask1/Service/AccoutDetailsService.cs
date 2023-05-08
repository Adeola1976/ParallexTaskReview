using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ParallexTask1.Dto;
using ParallexTask1.Entities;
using ParallexTask1.Interface;

namespace ParallexTask1.Service
{
   
        internal sealed class AccoutDetailsService : IAccoutDetailsService
    {
            private readonly IMapper _mapper;
            private readonly UserManager<User> _userManager;
            private readonly IConfiguration _configuration;
            private User? _user;
            public readonly IHttpService _httpService;
       
            //private readonly IOptions<JwtConfiguration> _configuration;


            public AccoutDetailsService(IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration, IHttpService httpService)
            {
                _mapper = mapper;
                _userManager = userManager;
                _configuration = configuration;
                 _httpService = httpService;
                //_jwtConfiguration = configuration.Value;
              
            }

            public async Task<GetResponseAccount> AccountDetails(AccountDetailsDto accountDetailsDto)
            {
            var res = new GetResponseAccount();
            try
            {
                var data = new LoginDto
                {
                    username = _configuration.GetSection("LoggingCredentials")["username"],
                    password = _configuration.GetSection("LoggingCredentials")["password"],
                };

                var req = new PostRequest<LoginDto>
                {
                    Url = _configuration.GetSection("ExternalApis")["AuthUrl"],
                    Data = data
                };
                var authresponse = await _httpService.SendPostRequest<LoginResponse, LoginDto>(req);
                if (authresponse.responseCode == "00")
                {

                    var req2 = new PostRequest2<AccountDetailsDto>
                    {
                        Url = _configuration.GetSection("ExternalApis")["CIBValidatorUrl"],
                        authorization = authresponse.token,
                        Data = accountDetailsDto
                    };
                    res = await _httpService.SendAuthPostRequest<GetResponseAccount, AccountDetailsDto>(req2);
                    if(res.responseCode == "00")
                    {
                        res.message = "data retrieved successful";
                        res.data.validateCustomer = true;
                    }
                   else
                    {
                        res.message = "no record found";                  
                    }
                }


                else
                {
                    res.message = "unauthorized";
                }

                return res;
            }

            catch (Exception ex)
            {
                res.message = $"internal server error occured while fetching dat.  Error message {ex.Message}";
                return res;
            }


                    

            }
        } 
}
