using Abp.Dependency;
using Abp.Grpc.Common.Runtime.Session;
using Abp.Runtime.Session;
using MagicOnion;
using MagicOnion.Server;
using System;

namespace Abp.Grpc.Server.Demo.RpcServices
{
    public interface ITestGrpcService : IService<ITestGrpcService>
    {
        // 普通的 Grpc 接口定义
        UnaryResult<int> Sum(int x, int y);

        // 带有 GrpcSession 的接口定义
        UnaryResult<long?> TestGrpcSession(GrpcSession session);
    }

    public class TestGrpcService : ServiceBase<ITestGrpcService>, ITestGrpcService
    {
        private readonly IAbpSession _abpSession;

        public TestGrpcService()
        {
            _abpSession = IocManager.Instance.Resolve<IIocManager>().Resolve<IAbpSession>();
        }

        public UnaryResult<int> Sum(int x, int y)
        {
            return UnaryResult(x + y);
        }

        public UnaryResult<long?> TestGrpcSession(GrpcSession session)
        {
            // 赋值前 Session 的值
            Console.WriteLine(_abpSession.UserId);

            // 临时改变 Session 值
            using (_abpSession.Use(session.TenantId, session.UserId))
            {
                Console.WriteLine(_abpSession.UserId);
            }

            // 离开 using 语句时 Session 的值
            Console.WriteLine(_abpSession.UserId);

            return new UnaryResult<long?>(1000);
        }
    }
}