using GBCE.StockCalculator.DataStore;
using System.Collections.Generic;

namespace GBCE.StockCalculator.Service
{
    /// <summary>
    /// Interface for Service methods
    /// </summary>
    public interface IStockCalculator
    {
        double CalculateDividendYieldForStock(Stock objStock);


        double CalculatePERatioForStock(Stock objStock);

        double CalculateStockPrice(List<Trade> objtrades);
    }
}
