using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabaseContext _dbContext;
        public OrderService(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Order> GetOrder()
        {
            var order = await _dbContext.Orders
                .Where(o=>o.Id == _dbContext.Orders
                    .Select(o => new
                        {
                            MaxOrderPrice = o.Price * o.Quantity,
                            Id = o.Id
                        }).OrderByDescending(r => r.MaxOrderPrice).First().Id).FirstOrDefaultAsync();

            return order;
        }

        public async Task<List<Order>> GetOrders()
        {
            var orders = await _dbContext.Orders.Where(o => o.Quantity > 10).ToListAsync();

            return orders;
        }
    }
}
