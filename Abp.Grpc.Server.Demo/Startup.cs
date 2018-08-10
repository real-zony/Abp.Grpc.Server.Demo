using Abp.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Abp.Grpc.Server.Demo
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // 添加 MVC
            services.AddMvc();
            // 添加 ABP 框架，注意更改 ConfigureServices 返回值为 IServiceProvider
            return services.AddAbp<AbpGrpcServerDemoModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // 启用 ABP 框架中间件
            app.UseAbp();
            // 启用 MVC 中间件
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}