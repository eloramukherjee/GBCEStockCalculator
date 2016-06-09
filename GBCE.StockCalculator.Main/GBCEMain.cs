using GBCE.StockCalculator.DataStore;
using GBCE.StockCalculator.Service;
using System;
using System.Collections.Generic;



namespace GBCE.StockCalculator.Main
{

    /// <summary>
    /// Main calling method for all the stock and trade data and displays them as well
    /// Accepts Stock Name and Stock Price as command line arguments for all stock and trade data calculation and storage for a given stock
    /// </summary>
    public class GBCEMain
    {

        public static int Main(string[] args)
        {
            double priceForStock = 0;
            double dividendYield = 0;
            double stockPERatio = 0;
            double stockPrice = 0;
            double allShareIndexes = 0;
            string errMsg = "";
            List<Stock> stocks = new List<Stock>();
            List<Trade> trades = new List<Trade>();
            Stock objSTockPopulated = new Stock();
            StockCalculatorImplement objStockCalculatorImplement = new StockCalculatorImplement();

            try
            {

                //check to see if command line argument was supplied
                if (args.Length == 0)
                {
                    System.Console.WriteLine("Please enter a proper input.");
                    return 1;
                }

                //numeric argument validation
                if (!(double.TryParse(args[1], out priceForStock)))
                {
                    System.Console.WriteLine("Please enter a numeric argument.");
                    return 1;
                }

                //Main Operations on Stocks and Trades

                if (objStockCalculatorImplement != null)

                {
                    //Populate Stock Values

                    stocks = objStockCalculatorImplement.PopulateStockValues();
                    objSTockPopulated = objStockCalculatorImplement.PopulateSpecificStockData(stocks, args[0], priceForStock);

                    // Record a Trade                

                    trades = objStockCalculatorImplement.RecordTrade(stocks, args[0]);

                    //Calculate Stock Price

                    stockPrice = objStockCalculatorImplement.CalculateStockPrice(trades);

                    //Calculate ShareIndexes

                    allShareIndexes = objStockCalculatorImplement.CalculateAllShareIndexes(stocks);

                    //Calculate Dividend Yield for a given stock and price as input

                    dividendYield = objStockCalculatorImplement.CalculateDividendYieldForStock(objSTockPopulated);

                    // Calculate PE Ratio for a given stock and price as input

                    stockPERatio = objStockCalculatorImplement.CalculatePERatioForStock(objSTockPopulated);

                }


                //Display the values in command prompt

                if (stockPrice == -1)
                    System.Console.WriteLine("Please input a correct and valid price for the stock");
                else
                    System.Console.WriteLine("The StockPrice of the trades for the Stock {0} is ${1}.", objSTockPopulated.StockName, stockPrice);


                if (allShareIndexes == -1)
                    System.Console.WriteLine("Please input a correct and valid price for the stock");
                else
                    System.Console.WriteLine("The SharedIndexes of the stocks is ${0}.", allShareIndexes);



                if (dividendYield == -1)
                    System.Console.WriteLine("Please input a correct and valid price for the stock");
                else
                    System.Console.WriteLine("The dividendYield of Stock {0} is ${1}.", objSTockPopulated.StockName, dividendYield);


                if (stockPERatio == -1)
                    System.Console.WriteLine("Please input a correct and valid price for the stock");
                else
                    System.Console.WriteLine("The PE Ratio of Stock {0} is ${1}.", objSTockPopulated.StockName, stockPERatio);
            }
            catch (Exception ex)
            {
                errMsg = ex.InnerException.Message;
                Console.WriteLine(errMsg);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            return 0;
        }
    }
}
