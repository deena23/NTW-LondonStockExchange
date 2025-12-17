namespace LondonStockExchange.Models
{
    public class TradeDetails
    {
        public string TickerCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal NumberOfShares { get; set; }
        public int BrokerId { get; set; }
    }
}
