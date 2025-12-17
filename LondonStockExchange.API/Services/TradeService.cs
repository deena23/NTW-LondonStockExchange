using LondonStockExchange.Models;
using LondonStockExchange.Repositories;
using LondonStockExchange.Utility;
using System.Text;
using static LondonStockExchange.Utility.StackExchangeConstants;

namespace LondonStockExchange.Services
{
    public class TradeService : ITradeService
    {
        #region Private Properties
        private readonly ITradeRepository _tradeRespository;
        #endregion

        #region Constructor
        public TradeService(ITradeRepository tradeRepository) {
            _tradeRespository = tradeRepository;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Receive trade details for transaction
        /// </summary>
        /// <param name="tradeDetails"></param>
        /// <returns></returns>
        public async Task<bool> ReceiveTrade(TradeDetails tradeDetails)
        {
            ValidateTradeDetails(tradeDetails);

            bool isInserted = await _tradeRespository.InsertTradeDetails(tradeDetails);

            return isInserted;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Validate trade details which received from broker
        /// </summary>
        /// <param name="tradeDetails"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateTradeDetails(TradeDetails tradeDetails)
        {
            if (tradeDetails is null)
                throw new ArgumentNullException(nameof(tradeDetails), TradeDetailsValidationMessage.TradeNullMessage.GetDescription());

            StringBuilder errorMessage = new();

            if (string.IsNullOrWhiteSpace(tradeDetails.TickerCode))
                errorMessage.Append(TradeDetailsValidationMessage.TickerCode.GetDescription());

            if (tradeDetails.Price <= 0)
                errorMessage.Append(TradeDetailsValidationMessage.Price.GetDescription());

            if (tradeDetails.NumberOfShares <= 0)
                errorMessage.Append(TradeDetailsValidationMessage.NumberOfShares.GetDescription());

            if (tradeDetails.BrokerId <= 0)
                errorMessage.Append(TradeDetailsValidationMessage.BrokerId.GetDescription());


            if (errorMessage.Length > 0)
                throw new ArgumentException(errorMessage.ToString().Trim());

        }
        #endregion
    }
}
