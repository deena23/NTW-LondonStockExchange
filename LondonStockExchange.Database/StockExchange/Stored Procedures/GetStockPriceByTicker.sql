CREATE   PROCEDURE [StockExchange].[GetStockPriceByTicker]
(
@TickerCode NVARCHAR(16)
)
AS
BEGIN
SET NOCOUNT ON;
	
	SELECT TickerCode, StockPrice FROM [StockExchange].[Stocks] WHERE TickerCode = @TickerCode;
	
SET NOCOUNT OFF;
END;