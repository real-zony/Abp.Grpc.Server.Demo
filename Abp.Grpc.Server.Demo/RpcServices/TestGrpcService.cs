using MagicOnion;
using MagicOnion.Server;

namespace Abp.Grpc.Server.Demo.RpcServices
{
    public interface ITestGrpcService : IService<ITestGrpcService>
    {
        UnaryResult<int> Sum(int x, int y);
    }

    public class TestGrpcService : ServiceBase<ITestGrpcService>, ITestGrpcService
    {
        public UnaryResult<int> Sum(int x, int y)
        {
            return UnaryResult(x + y);
        }
    }
}