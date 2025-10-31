

using DevApi.BAL;
using DevApi.Models.Common;
using Microsoft.Extensions.DependencyInjection;
using MyApp.BAL;

namespace DevApi
{
    public static class Register
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<JWTFunction>();
            services.AddTransient<LoginService>();
            services.AddTransient<MenuService>();
            services.AddTransient<DropDownService>();
            services.AddTransient<UserService>();
            services.AddTransient<IncommingPaymentService>();
            services.AddTransient<OutgoingPaymentService>();
            services.AddTransient<PlotService>();
            services.AddTransient<DashboardService>();
            services.AddTransient<LocationService>();
            services.AddTransient<EnquiryService>();


        }
    }
}
