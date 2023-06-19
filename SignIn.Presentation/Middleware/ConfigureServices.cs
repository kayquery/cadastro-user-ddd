using SignIn.Application.Interfaces;
using SignIn.Application.Services;
using SignIn.Infra.ExternalServices;
using SignIn.Infra.Interfaces;
using SignIn.Infra.Repository;

namespace SignIn.Presentation.Middleware
{
    public static class ConfigureServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IAddressService, AddressService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}