using System.ComponentModel;

namespace LondonStockExchange.Utility
{
    public static class StackExchangeConstants
    {
        #region Stored Procedure
        public static readonly string SP_InsertTradeDetails = "[StockExchange].[InsertTradeDetails]";
        public static readonly string SP_GetStockPriceByTicker = "[StockExchange].[GetStockPriceByTicker]";
        public static readonly string SP_GetStockPriceForTickers = "[StockExchange].[GetStockPriceForTickers]";
        #endregion

        #region Enum Validation
        public enum TradeDetailsValidationMessage
        {
            [Description("Trade details cannot be null.")]
            TradeNullMessage,
            [Description("Ticker Code is Mandatory.")]
            TickerCode,
            [Description("Trade price must be greater than zero.")]
            Price,
            [Description("Quantity must be greater than zero.")]
            NumberOfShares,
            [Description("Broker ID is mandatory.")]
            BrokerId
        }
        #endregion

        #region Common Validation Messages
        public static readonly string TickerMandatoryMessage = "Ticker should not be empty.";
        public static readonly string StockPriceNotFoundMessageForTicker = "Stock price was not found for: {0}";
        public static readonly string NoStockFoundMessage = "No stock found";
        #endregion

        #region UDT
        public static readonly string UDT_SearchRequest = "[StockExchange].[SearchRequest]";
        #endregion
    }
}
