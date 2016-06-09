using GBCE.StockCalculator.DataStore;
using System.Collections.Generic;

namespace GBCE.StockCalculator.Service
{
    /// <summary>
    /// Interface to define Service Methods for the stocks
    /// </summary>
    interface ITradeRecords
    {
        double CalculateStockPrice(List<Trade> trades);

        
        double CalculateAllShareIndexes(List<Stock> stocks);
    }
}
