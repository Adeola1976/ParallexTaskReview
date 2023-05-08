namespace ParallexTask1.Interface
{
    public interface IServiceManager
    {
        IAuthenticationServices AuthenticationService { get; }

        IAccoutDetailsService AccoutDetailsService { get; }
    }
}
