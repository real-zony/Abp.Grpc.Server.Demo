using Abp.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Abp.Grpc.Server.Demo.Controllers
{
    public class HealthController : AbpController
    {
        /// <summary>
        /// 健康检查接口
        /// </summary>
        public IActionResult Check()
        {
            return Ok("OJBK");
        }
    }
}
