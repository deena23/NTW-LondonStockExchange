CREATE TABLE [StockExchange].[Trades] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [TickerCode]     NVARCHAR (16)   NOT NULL,
    [Price]          DECIMAL (18, 4) NOT NULL,
    [NumberOfShares] DECIMAL (18, 4) NOT NULL,
    [BrokerId]       INT             NOT NULL,
    [TradeDate]      DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IDX_TickerCode_Ticker]
    ON [StockExchange].[Trades]([TickerCode] ASC);

