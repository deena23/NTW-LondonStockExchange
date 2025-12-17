using Dapper;
using LondonStockExchange.Models;
using LondonStockExchange.Models.UDTModel;
using LondonStockExchange.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace LondonStockExchange.Repositories
{
    public class StockRepository : IStockRepository
    {
        #region Private Properties
        private readonly ConfigurationItem _configuration;
        #endregion

        #region Constructor
        public StockRepository(IOptions<ConfigurationItem> options) 
        {
            _configuration = options.Value;
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Get Stock Details By Ticker Code
        /// </summary>
        /// <param name="ticker"></param>
        /// <returns>Return stock details for ticker code</returns>
        public async Task<StockDetails?> GetStockPriceByTicker(string ticker)
        {
            string procedureName = StackExchangeConstants.SP_GetStockPriceByTicker;

            DynamicParameters parameters = new();
            parameters.Add("@TickerCode", ticker);

            using var connection = new SqlConnection(_configuration.ConnectionString);

            StockDetails? stockDetails = await connection.QueryFirstOrDefaultAsync<StockDetails>(procedureName, parameters, null, null, CommandType.StoredProcedure);

            return stockDetails;
        }

        /// <summary>
        /// Get Stock Details By Listed Tickder Code
        /// </summary>
        /// <param name="stockSearchRequestTypes"></param>
        /// <returns>return all stocks if stockSearchRequestTypes is empty else return listed ticker details</returns>
        public async Task<IEnumerable<StockDetails>> GetStockPriceForTickers(List<StockSearchRequestType> stockSearchRequestTypes)
        {
            string procedureName = StackExchangeConstants.SP_GetStockPriceForTickers;

            DynamicParameters parameters = new();
            parameters.AddTable("@TickerList", StackExchangeConstants.UDT_SearchRequest, stockSearchRequestTypes);

            using var connection = new SqlConnection(_configuration.ConnectionString);

            var stockDetails = await connection.QueryAsync<StockDetails>(procedureName, parameters, null, null, CommandType.StoredProcedure);

            return stockDetails;
        }
        #endregion
    }
}
