using LondonStockExchange.Models;
using LondonStockExchange.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockExchange.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/trades")]
    public class TradeController : ControllerBase
    {
        #region Private Properties
        private readonly ITradeService _tradeService;
        private readonly ILogger<TradeController> _logger;
        #endregion

        #region Constructor
        public TradeController(ITradeService tradeService, ILogger<TradeController> logger) { 
            this._tradeService = tradeService;
            this._logger = logger;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Recieve trade details
        /// </summary>
        /// <param name="tradeDetails"></param>
        /// <returns></returns>
        [HttpPost("ReceiveTrade")]
        public async Task<ActionResult<bool>> ReceiveTrade([FromBody] TradeDetails tradeDetails)
        {
            _logger.LogInformation(string.Format("Started Trade Process with: {0}", tradeDetails.ToString()));
            bool isReceived = await _tradeService.ReceiveTrade(tradeDetails);
            return Ok(isReceived);
        }
        #endregion
    }
}
