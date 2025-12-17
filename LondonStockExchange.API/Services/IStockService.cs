using LondonStockExchange.Models;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.Services
{
    public interface IStockService
    {
        Task<StockDetails> GetStockPriceByTicker(string ticker);
        Task<List<StockDetails>> GetStockPriceForAllTicker();
        Task<List<StockDetails>> GetStockPriceForTickers(StockSearchRequest stockSearchRequest);
    }
}
