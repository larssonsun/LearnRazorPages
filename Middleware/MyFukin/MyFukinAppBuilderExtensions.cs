using System;
using Microsoft.AspNetCore.Builder;

namespace MyMiddleware.MyFukin
{
    public static class MyFukinAppBuilderExtensions
    {
        public static IApplicationBuilder UseMyFukin(this IApplicationBuilder app)
        {

            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<MyFuckinMiddleware>();
        }
    }
}
