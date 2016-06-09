namespace GBCE.StockCalculator.DataStore
{
    /// <summary>
    /// Data object for storing stock data
    /// </summary>
    public class Stock
    {
        private string stockName = "";
        private double lastDividend = 0;
        private double fixedDividend = 0;
        private int parValue = 0;
        private double stockPrice = 0;

        public string StockName
        {
            get
            {
                return stockName;
            }
            set
            {
                stockName = value;
            }
        }

        public enum StockType
        {
            COMMON, PREFERRED
        }

        public double LastDividend
        {
            get
            {
                return lastDividend;
            }
            set
            {
                lastDividend = value;
            }
        }
        public double FixedDividend
        {
            get
            {
                return fixedDividend;
            }
            set
            {
                fixedDividend = value;
            }
        }

        public int ParValue
        {
            get
            {
                return parValue;
            }
            set
            {
                parValue = value;
            }
        }
        public double StockPrice
        {
            get
            {
                return stockPrice;
            }
            set
            {
                stockPrice = value;
            }
        }

        public Stock()
        { }
        public Stock(string stockName,
                     StockType stockType,
                     double lastDividend,
                     double fixedDividend,
                     int parValue,
                     double stockPrice)
        {

            this.StockName = stockName;
            this.LastDividend = lastDividend;
            this.FixedDividend = fixedDividend;
            this.ParValue = parValue;
            this.StockPrice = stockPrice;
        }

    }
}
