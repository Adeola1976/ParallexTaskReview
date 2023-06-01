using NQR.Application;
using NQR.Application.Service;
using NQR.Application.Service.Interface;
using NQR.Common.Shared.HttpService;

namespace NQR_API.Extension
{
    public static class ServiceExtensions
    {
        public static void ConfigureAuthSerice(this IServiceCollection services) => 
        services.AddScoped<IAuthentication,Authentication>();

        public static void ConfigureHttpService(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpService, HttpService>().SetHandlerLifetime(TimeSpan.FromMinutes(5));
            services.AddScoped<IHttpService, HttpService>();
        }

        public static void ConfigureQRCodeGenerateService(this IServiceCollection services)
        {
            services.AddScoped<IQRCodeService, QRCodeGenerateService> ();
        }

        public static void ConfigureQRCodePaymentService(this IServiceCollection services)
        {
            services.AddScoped<IQRCodePaymentService, QRCodePaymentService>();
        }
    }
}
