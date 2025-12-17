CREATE TABLE [StockExchange].[Stocks] (
    [TickerCode] NVARCHAR (16)   NOT NULL,
    [StockPrice] DECIMAL (18, 4) NOT NULL,
    PRIMARY KEY CLUSTERED ([TickerCode] ASC)
);

