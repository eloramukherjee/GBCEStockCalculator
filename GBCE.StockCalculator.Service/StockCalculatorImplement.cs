using GBCE.StockCalculator.DataStore;
using GBCE.StockCalculator.Utility;
using System;
using System.Collections.Generic;


namespace GBCE.StockCalculator.Service
{

    /// <summary>
    /// Implementation class for all Trade and Stock related methods
    /// </summary>
    public class StockCalculatorImplement : IStockCalculator, ITradeRecords
    {
        Stock objStock = new Stock();
        List<Stock> stocks = new List<Stock>();
        List<Trade> trades = new List<Trade>();
        StockCalculatorUtility objStockCalculatorUtility = new StockCalculatorUtility();
        DataProviderForStockAndTrade objDataProvider = new DataProviderForStockAndTrade();
        public double dividendYield = 0;
        public double stockPERatio = 0;
        public string errMsg = "";


        public double CalculateDividendYieldForStock(Stock objStock)
        {
            try
            {
                if (objStock.StockName == "TEA" || objStock.StockName == "POP" || objStock.StockName == "ALE" || objStock.StockName == "JOE")

                    dividendYield = objStockCalculatorUtility.CalculateDYOnStockType(Stock.StockType.COMMON, objStock);

                else

                    dividendYield = objStockCalculatorUtility.CalculateDYOnStockType(Stock.StockType.PREFERRED, objStock);
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            return dividendYield;
        }

        public double CalculatePERatioForStock(Stock objStock)
        {
            if (objStock != null)
            {
                try
                {
                    stockPERatio = objStockCalculatorUtility.CalculatePERatio(objStock);
                }
                catch (Exception ex)
                {
                    errMsg = ex.InnerException.Message;
                    Console.WriteLine(errMsg);
                }
            }
            return stockPERatio;
        }

        public double CalculateStockPrice(List<Trade> trades)
        {
            if (trades == null)
            {

                return 0;
            }
            double[] tradePrices = new double[trades.Capacity];
            double[] tradesQuantities = new double[trades.Capacity];
            int i = 0;
            try
            {
                foreach (Trade trade in trades)
                {

                    tradePrices[i] = trade.TradedPrice;
                    tradesQuantities[i] = trade.ShareQty;
                    i++;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }
            return objStockCalculatorUtility.CalculateStockPrice(tradePrices, tradesQuantities);

        }

        public double CalculateAllShareIndexes(List<Stock> stocks)
        {
            double[] tradesPrices = new double[stocks.Capacity];

            double totalParValues = 0;
            double geometricMean = 0;

            int i = 0;
            try
            {
                foreach (Stock stock in stocks)
                {

                    totalParValues += stock.ParValue;

                    tradesPrices[i] = stock.StockPrice;
                    i++;

                }



                geometricMean = objStockCalculatorUtility.CalculateGeometricMean(tradesPrices);
            }

            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            return geometricMean / totalParValues;
        }

        public List<Stock> PopulateStockValues()
        {

            try
            {
                if (objDataProvider != null)
                {
                    stocks = objDataProvider.PopulateStockValues();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }
            return stocks;
        }


        public Stock PopulateSpecificStockData(List<Stock> stocks, string stockName, double stockPrice)
        {

            try
            {
                if (objDataProvider != null)
                {
                    objStock = objDataProvider.PopulateSpecificStockData(stocks, stockName, stockPrice);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }
            return objStock;
        }

        public List<Trade> RecordTrade(List<Stock> stocks, string StockName)
        {

            return objDataProvider.RecordTrade(stocks, StockName);

        }




    }
}
