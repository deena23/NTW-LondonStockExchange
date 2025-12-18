using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.Controllers
{
    [ApiController]
    [Route("api/stocks")]
    public class StockController : ControllerBase
    {
        #region Private Properties
        private readonly IStockService _stockService;
        #endregion

        #region Constructor
        public StockController(IStockService stockService) 
        { 
            this._stockService = stockService;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get Stock Price For Single Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStockPriceByTicker/{ticker}")]
        public async Task<ActionResult<StockDetails>> GetStockPriceByTicker(string ticker) 
        {
            StockDetails stockDetails = await _stockService.GetStockPriceByTicker(ticker);

            return Ok(stockDetails);
        }

        /// <summary>
        /// Get Stock Price For All Ticker
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStockPriceForAllTicker")]
        public async Task<ActionResult<List<StockDetails>>> GetStockPriceForAllTicker()
        {
            List <StockDetails> stockPriceDetails = await _stockService.GetStockPriceForAllTicker();

            return Ok(stockPriceDetails);
        }

        /// <summary>
        /// Get Stock Details For Listed Ticker
        /// </summary>
        /// <param name="stockSearchRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetStockPriceForTickers")]
        public async Task<ActionResult<List<StockDetails>>> GetStockPriceForTickers(StockSearchRequest stockSearchRequest)
        {
            List<StockDetails> stockDetails = await _stockService.GetStockPriceForTickers(stockSearchRequest);

            return Ok(stockDetails);
        }

        #endregion
    }
}
