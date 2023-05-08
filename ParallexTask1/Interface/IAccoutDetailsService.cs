using ParallexTask1.Dto;

namespace ParallexTask1.Interface
{
    public interface IAccoutDetailsService
    {
        Task<GetResponseAccount> AccountDetails(AccountDetailsDto accountDetailsDto);
    }
}
