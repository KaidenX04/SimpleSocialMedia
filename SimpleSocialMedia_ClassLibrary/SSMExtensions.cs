using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleSocialMedia_ClassLibrary.BLL;
using SimpleSocialMedia_ClassLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSocialMedia_ClassLibrary
{
    public static class SSMExtensions
    {
        public static void SSMEtensions(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<SimpleSocialMediaContext>(options);

            services.AddTransient<AccountServices>(serviceProvider =>
            {
                return new AccountServices(serviceProvider.GetService<SimpleSocialMediaContext>());
            });

            services.AddTransient<PostServices>(serviceProvider =>
            {
                return new PostServices(serviceProvider.GetService<SimpleSocialMediaContext>());
            });

            services.AddTransient<CommentServices>(serviceProvider =>
            {
                return new CommentServices(serviceProvider.GetService<SimpleSocialMediaContext>());
            });

            services.AddTransient<LikeServices>(serviceProvider =>
            {
                return new LikeServices(serviceProvider.GetService<SimpleSocialMediaContext>());
            });
        }
    }
}
