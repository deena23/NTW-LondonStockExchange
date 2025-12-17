using LondonStockExchange.Models;

namespace LondonStockExchange.Repositories
{
    public interface ITradeRepository
    {
        Task<bool> InsertTradeDetails(TradeDetails tradeDetails);
    }
}
