using System;
using System.Collections.Generic;

namespace GBCE.StockCalculator.DataStore
{

    /// <summary>
    /// Populates Stock data and records trades for a given stock as input
    /// </summary>
    public class DataProviderForStockAndTrade
    {
        List<Stock> stocks = new List<Stock>();
        List<Trade> trades = new List<Trade>();
        Stock objSTockPopulated = new Stock();
        public string errMsg = "";
        public List<Stock> PopulateStockValues()
        {
            try
            {
                Stock objStockTEA = new Stock("TEA", Stock.StockType.COMMON, 0, 0, 100, 110);
                Stock objStockPOP = new Stock("POP", Stock.StockType.COMMON, 8, 0, 100, 120);
                Stock objStockALE = new Stock("ALE", Stock.StockType.COMMON, 23, 0, 60, 55);
                Stock objStockGIN = new Stock("GIN", Stock.StockType.PREFERRED, 8, 2, 100, 100);
                Stock objStockJOE = new Stock("JOE", Stock.StockType.COMMON, 13, 0, 250, 216.12);


                stocks.Add(objStockTEA);
                stocks.Add(objStockPOP);
                stocks.Add(objStockALE);
                stocks.Add(objStockGIN);
                stocks.Add(objStockJOE);


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
                foreach (Stock stock in stocks)
                {
                    if (stock.StockName == stockName)
                    {
                        objSTockPopulated.StockName = stock.StockName;
                        objSTockPopulated.StockPrice = stockPrice;
                        objSTockPopulated.LastDividend = stock.LastDividend;
                        objSTockPopulated.FixedDividend = stock.FixedDividend;
                        objSTockPopulated.ParValue = stock.ParValue;

                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            return objSTockPopulated;

        }

        public List<Trade> RecordTrade(List<Stock> stocks, string stockName)
        {
            Trade tradeForStock = null;
            Random rand = new Random();
            bool isOdd;
            foreach (Stock stockForTrade in stocks)
            {

                if (stockForTrade.StockName == stockName)
                {
                    //Recording 5 trades for a given stock as input
                    for (int i = 0; i <= 4; i++)
                    {
                        isOdd = IsOddOrEven(i);
                        tradeForStock = new Trade(stockForTrade, isOdd ? Trade.BuyOrSellInd.BUY : Trade.BuyOrSellInd.SELL, DateTime.Now, rand.Next(), (rand.NextDouble() * 1000d + 50d));
                        trades.Add(tradeForStock);
                    }
                }

            }
            return trades;
        }

        public Boolean IsOddOrEven(int i)
        {
            if (i % 2 == 0)
                return false;
            else
                return true;
        }


    }
}
