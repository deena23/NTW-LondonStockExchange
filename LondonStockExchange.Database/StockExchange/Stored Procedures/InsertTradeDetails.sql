CREATE   PROCEDURE [StockExchange].[InsertTradeDetails]
(
@TickerCode NVARCHAR(16),
@Price DECIMAL(18,4),
@NumberOfShares DECIMAL(18,4),
@BrokerId INT,
@TradeDate DATETIME
)
AS
BEGIN
SET NOCOUNT ON;

	--Insert Trades
	INSERT INTO [StockExchange].[Trades](TickerCode, Price, NumberOfShares, BrokerId, TradeDate)
	VALUES (@TickerCode, @Price, @NumberOfShares, @BrokerId, @TradeDate);

	DECLARE @StockPrice DECIMAL(18,4);

	--Calculate Average Price for Stock
	SELECT @StockPrice = (SUM(Price * NumberOfShares) / SUM(NumberOfShares))
	FROM Trades
	WHERE TickerCode = @TickerCode;

	--Insert or Update Stock Price
	MERGE INTO [StockExchange].[Stocks] AS TAR
	USING (SELECT @TickerCode AS TickerCode, @StockPrice AS StockPrice) AS SRC
	ON TAR.TickerCode = SRC.TickerCode
	WHEN MATCHED THEN 
		UPDATE SET TAR.StockPrice = SRC.StockPrice
	WHEN NOT MATCHED THEN
		INSERT (TickerCode, StockPrice)
		VALUES (SRC.TickerCode, SRC.StockPrice);

SET NOCOUNT OFF;
END;