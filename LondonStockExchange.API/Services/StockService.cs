using LondonStockExchange.Models;
using LondonStockExchange.Models.UDTModel;
using LondonStockExchange.Repositories;
using LondonStockExchange.Utility;

namespace LondonStockExchange.Services
{
    public class StockService : IStockService
    {
        #region Private Properties
        private readonly IStockRepository _stockrepository;
        #endregion

        #region Constructor
        public StockService(IStockRepository stockRepository)
        {
            _stockrepository = stockRepository;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Get Stock Details By Tickder Code
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<StockDetails> GetStockPriceByTicker(string ticker)
        {
            if(string.IsNullOrWhiteSpace(ticker))
                throw new ArgumentNullException(null, StackExchangeConstants.TickerMandatoryMessage);

            StockDetails? stockPrice = await _stockrepository.GetStockPriceByTicker(ticker) 
                                                ?? throw new KeyNotFoundException(string.Format(StackExchangeConstants.StockPriceNotFoundMessageForTicker, ticker));

            return stockPrice;
        }

        /// <summary>
        /// Get All Stock Details
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<StockDetails>> GetStockPriceForAllTicker()
        {
            IEnumerable<StockDetails> stockDetails = await _stockrepository.GetStockPriceForTickers([]);

            if (stockDetails == null || !stockDetails.Any())
                throw new KeyNotFoundException(StackExchangeConstants.NoStockFoundMessage);

            return stockDetails.ToList();
        }

        /// <summary>
        /// Get Listed Ticker Stock Details
        /// </summary>
        /// <param name="stockSearchRequest"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<StockDetails>> GetStockPriceForTickers(StockSearchRequest stockSearchRequest)
        {
            if (stockSearchRequest == null || stockSearchRequest.TickerList.Count == 0)
                throw new ArgumentNullException(null, StackExchangeConstants.TickerMandatoryMessage);

            List<StockSearchRequestType> stockSearchRequestTypes = stockSearchRequest.TickerList.Select(ticker => new StockSearchRequestType() { Name = ticker }).ToList();

            IEnumerable<StockDetails> stockDetails = await _stockrepository.GetStockPriceForTickers(stockSearchRequestTypes);

            if(stockDetails == null || !stockDetails.Any())
                throw new KeyNotFoundException(string.Format(StackExchangeConstants.StockPriceNotFoundMessageForTicker, string.Join(", ", stockSearchRequest.TickerList)));

            return stockDetails.ToList();
        }

        #endregion
    }
}
