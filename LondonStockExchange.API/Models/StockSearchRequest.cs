namespace LondonStockExchange.Models
{
    public class StockSearchRequest
    {
        public string TickerCode { get; set; } = string.Empty;
        public List<string> TickerList { get; set; } = [];
    }
}
