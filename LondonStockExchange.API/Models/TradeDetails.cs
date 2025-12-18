namespace LondonStockExchange.Models
{
    public class TradeDetails
    {
        public string TickerCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal NumberOfShares { get; set; }
        public int BrokerId { get; set; }
        public override string ToString()
        {
            string requestedDetails = string.Format("TickerCode: {0}, Price: {1}, NumberOfShares: {2} and BrokerId: {3}", TickerCode, Price, NumberOfShares, BrokerId);
            return requestedDetails;
        }
    }
}
