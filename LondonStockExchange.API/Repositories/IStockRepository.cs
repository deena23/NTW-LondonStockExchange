using LondonStockExchange.Models;
using LondonStockExchange.Models.UDTModel;

namespace LondonStockExchange.Repositories
{
    public interface IStockRepository
    {
        Task<StockDetails?> GetStockPriceByTicker(string ticker);
        Task<IEnumerable<StockDetails>> GetStockPriceForTickers(List<StockSearchRequestType> stockSearchRequestTypes);
    }
}
