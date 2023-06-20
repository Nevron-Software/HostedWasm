using HostedWasm.Server.Model;
using Microsoft.EntityFrameworkCore;

namespace HostedWasm.Server.Services
{
    public class NOrderBl : INOrderBlService
    {
        #region Constructor

        public NOrderBl(NDbContext dbContext) 
        {
            m_NdbContext = dbContext;
        }

        #endregion

        public async Task<List<Order>> GetOrdersAsync()
        {
            if (m_NdbContext.Database.CanConnect()) 
                return await m_NdbContext.Orders.ToListAsync();
            else
                return new List<Order>();
        }

        NDbContext m_NdbContext;
    }
}
