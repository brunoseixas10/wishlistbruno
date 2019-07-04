using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wishlist.Bo;
using Wishlist.Bo.Interfaces;
using Wishlist.Repository;
using Wishlist.Repository.Interfaces;

namespace Wishlist.IoC
{
    public sealed class ConteinerBuilder
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.TryAddScoped<IUserBo, UserBo>();
            services.TryAddScoped<IProductBo, ProductBo>();
            services.TryAddScoped<IWishlistBo, WishlistBo>();
            services.TryAddScoped<IUserRepository, UserRepository>();
            services.TryAddScoped<IProductRepository, ProductRepository>();
            services.TryAddScoped<IWishlistRepository, WishlistRepository>();
        }
    }
}
