using Abp.AspNetCore;
using Abp.Grpc.Server.Extensions;
using Abp.Modules;

namespace Abp.Grpc.Server.Demo
{
    [DependsOn(typeof(AbpAspNetCoreModule),
        typeof(AbpGrpcServerModule))]
    public class AbpGrpcServerDemoModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.UseGrpcService(option =>
            {
                // GRPC 服务绑定的 IP 地址
                option.GrpcBindAddress = "0.0.0.0";
                // GRPC 服务绑定的 端口号
                option.GrpcBindPort = 5001;
                // 启用 Consul 服务注册
                option.UseConsul(consulOption =>
                {
                    // Consul 服务注册地址
                    consulOption.ConsulAddress = "10.0.75.1";
                    // Consul 服务注册端口号
                    consulOption.ConsulPort = 8500;
                    // 注册到 Consul 的服务名称
                    consulOption.RegistrationServiceName = "TestGrpcService";
                    // 健康检查接口的地址
                    consulOption.ConsulHealthCheckAddress = "172.31.61.41";
                    // 健康检查接口的端口号
                    consulOption.ConsulHealthCheckPort = 5000;
                });
            })
            .AddRpcServiceAssembly(typeof(AbpGrpcServerDemoModule).Assembly); // 扫描当前程序集的所有 GRPC 服务
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AbpGrpcServerDemoModule).Assembly);
        }
    }
}