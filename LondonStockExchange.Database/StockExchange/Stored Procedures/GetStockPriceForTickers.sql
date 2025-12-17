CREATE   PROCEDURE [StockExchange].[GetStockPriceForTickers]
(
@TickerList [StockExchange].[SearchRequest] READONLY
)
AS
BEGIN
SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM @TickerList)
	BEGIN
		SELECT TickerCode, StockPrice FROM [StockExchange].[Stocks];
	END
	ELSE
	BEGIN
		SELECT stock.TickerCode, stock.StockPrice FROM [StockExchange].[Stocks] stock 
		JOIN @TickerList udtStock ON stock.TickerCode = udtStock.Name;
	END
	
SET NOCOUNT OFF;
END;