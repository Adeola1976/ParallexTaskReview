using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ParallexTask1.Entities;
using ParallexTask1.Interface;

namespace ParallexTask1.Service
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IAuthenticationServices> _authenticationService;
        private readonly Lazy<IAccoutDetailsService> _accoutDetailsService;
        



        public ServiceManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration, IHttpService httpService)
        {

            _authenticationService = new Lazy<IAuthenticationServices>(() => new AuthenticationServices(mapper, userManager, configuration));
            _accoutDetailsService = new Lazy<IAccoutDetailsService>(() => new AccoutDetailsService(mapper, userManager, configuration,httpService   ));
        }


        public IAuthenticationServices AuthenticationService => _authenticationService.Value;
        public IAccoutDetailsService AccoutDetailsService => _accoutDetailsService.Value;
    }
}