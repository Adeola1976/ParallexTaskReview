using Microsoft.AspNetCore.Identity;
using ParallexTask1.Dto;
using static ParallexTask1.Dto.TokenDtos;

namespace ParallexTask1.Interface
{
    public interface IAuthenticationServices
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
    }
}
