using LondonStockExchange.Models;
using LondonStockExchange.Utility;
using Microsoft.Extensions.Options;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LondonStockExchange.Repositories
{
    public class TradeRepository : ITradeRepository
    {
        #region Private Properties
        private readonly ConfigurationItem _configuration;
        #endregion

        #region Constructor
        public TradeRepository(IOptions<ConfigurationItem> options) 
        {
            _configuration = options.Value;    
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Insert validated trade details
        /// </summary>
        /// <param name="tradeDetails"></param>
        /// <returns></returns>
        public async Task<bool> InsertTradeDetails(TradeDetails tradeDetails)
        {
            string procedureName = StackExchangeConstants.SP_InsertTradeDetails;
 
            DynamicParameters parameters = new();

            parameters.Add("@TickerCode", tradeDetails.TickerCode);
            parameters.Add("@Price", tradeDetails.Price);
            parameters.Add("@NumberOfShares", tradeDetails.NumberOfShares);
            parameters.Add("@BrokerId", tradeDetails.BrokerId);
            parameters.Add("@TradeDate", DateTime.Now);

            using var connection = new SqlConnection(_configuration.ConnectionString);

            await connection.ExecuteAsync(procedureName, parameters, null, null, CommandType.StoredProcedure);

            return true;
        }
        #endregion
    }
}
