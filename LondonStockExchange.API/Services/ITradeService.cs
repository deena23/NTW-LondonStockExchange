using LondonStockExchange.Models;

namespace LondonStockExchange.Services
{
    public interface ITradeService
    {
        Task<bool> ReceiveTrade(TradeDetails tradeDetails);
    }
}
