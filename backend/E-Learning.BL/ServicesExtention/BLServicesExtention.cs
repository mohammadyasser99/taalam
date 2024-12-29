using E_Learning.BL.Managers.AccountManager;
using E_Learning.BL.Managers.AuthenticationManager;
using E_Learning.BL.Managers.CategoryManager;

using E_Learning.BL.Managers.Mailmanager;

using E_Learning.BL.Managers.CourseManager;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using E_Learning.BL.Managers.CartManager;
using E_Learning.BL.Managers.WishListManager;
using E_Learning.BL.Managers.RatingManager;
using E_Learning.BL.Managers.PaymentManager;
using E_Learning.BL.Managers.AnnouncementManager;

namespace E_Learning.BL.ServicesExtention
{
    public static class BLServicesExtention
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<ICourseManager, CourseManager>();
            services.AddScoped<ICartManager, CartManager>();
            services.AddScoped<IWishListManager, WishListManager>();
            services.AddScoped<IRatingManager, RatingManager>();
            services.AddScoped<IPaymentManager, PaymentManager>();

            services.AddScoped<IAnnouncementManager , AnnouncementManager>();   
            services.AddScoped<IUserManager, UserManager>();
            services.AddTransient<IJwtManager, JwtManager>();
            services.AddTransient<IAccountManager,AccountManager>();
            services.AddTransient<IMailManager,MailManager>();

        }
    }
}
