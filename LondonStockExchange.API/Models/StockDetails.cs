namespace LondonStockExchange.Models
{
    public class StockDetails
    {
        public string TickerCode { get; set; } = string.Empty;
        public decimal StockPrice { get; set; }
    }
}
