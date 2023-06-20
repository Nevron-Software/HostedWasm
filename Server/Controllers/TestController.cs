using HostedWasm.Server.Model;
using HostedWasm.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HostedWasm.Server.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        #region Constructors

        
        public TestController(INOrderBlService orderService)
        {
            m_OrderService = orderService;
        }

        #endregion

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<Order>> GetOrdersAsync()
        {
            List<Order> orders = await m_OrderService.GetOrdersAsync();
            return orders;
        }
        [HttpGet]
        [AllowAnonymous]
        [Route("GetTest")]
        public string GetVarValue()
        {
            string? testVar = Environment.GetEnvironmentVariable("TEST");

            if (string.IsNullOrEmpty(testVar))
            {
                testVar = "Not Found";
            }

            return testVar;
        }

        #region Fields

        INOrderBlService m_OrderService;

        #endregion
    }

}
