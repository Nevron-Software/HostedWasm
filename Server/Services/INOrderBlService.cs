using HostedWasm.Server.Model;

namespace HostedWasm.Server.Services
{
    public interface INOrderBlService
    {
        Task<List<Order>> GetOrdersAsync();
    }
}
