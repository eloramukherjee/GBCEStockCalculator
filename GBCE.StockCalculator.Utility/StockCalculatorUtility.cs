using GBCE.StockCalculator.DataStore;
using System;


namespace GBCE.StockCalculator.Utility
{
    /// <summary>
    /// Utility class for stock calculations - comprises of all the formulae
    /// </summary>
    public class StockCalculatorUtility
    {
        Stock objStock = new Stock();
        public double lastDividend = 0;
        public double fixedDividend = 0;
        public double dividendYieldForStock = 0;
        string errMsg = "";

        public double CalculateDYOnStockType(Stock.StockType stockType, Stock objStock)
        {

            try
            {
                if (objStock == null || objStock.StockPrice == 0)
                    return 0;
                if (stockType == Stock.StockType.COMMON)

                {
                    lastDividend = objStock.LastDividend;
                    dividendYieldForStock = lastDividend / objStock.StockPrice;
                }
                else
                {
                    fixedDividend = objStock.LastDividend;
                    dividendYieldForStock = (fixedDividend * objStock.ParValue) / objStock.StockPrice;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            return dividendYieldForStock;
        }

        public double CalculatePERatio(Stock objStock)
        {
            if (objStock == null || objStock.StockPrice == 0)
                return 0;
            else
                return (objStock.StockPrice / objStock.LastDividend);
        }

        public double CalculateStockPrice(double[] tradePrices, double[] tradesQuantities)
        {

            double pricePerQty = 0;
            double qty = 0;
            try
            {
                if (tradePrices == null || (tradePrices != null && tradePrices.Length == 0))
                {

                    return 0;
                }

                if (tradesQuantities == null || (tradesQuantities != null && tradesQuantities.Length == 0))
                {
                    return 0;
                }

                for (int i = 1; i < tradePrices.Length; i++)
                {

                    pricePerQty += tradePrices[i] * tradesQuantities[i];

                    qty += tradesQuantities[i];
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            return pricePerQty / qty;
        }

        public double CalculateGeometricMean(double[] tradesPrices)
        {

            if (tradesPrices == null || (tradesPrices != null && tradesPrices.Length == 0))
            {

                return 0d;
            }
            int n = 0;
            double geometricMean = tradesPrices[0];
            try
            {

                for (int i = 1; i < tradesPrices.Length; i++)
                {
                    if (tradesPrices[i] != 0)
                    {
                        geometricMean *= tradesPrices[i];
                    }
                }

                n = tradesPrices.Length;
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }
            return Math.Pow(geometricMean, 1.0 / (double)n);
        }


    }
}
