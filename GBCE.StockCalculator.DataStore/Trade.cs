using System;

namespace GBCE.StockCalculator.DataStore
{
    /// <summary>
    /// Data object for storing Trade related data
    /// </summary>
    public class Trade
    {

        private Stock stockForTrade;
        private DateTime tradeTimeStamp = DateTime.Now;
        private int shareQty = 0;
        private double tradedPrice = 0;

        public Stock StockForTrade
        {
            get
            {
                return stockForTrade;
            }
            set
            {
                stockForTrade = value;
            }
        }

        public enum BuyOrSellInd
        {
            BUY, SELL
        }



        public DateTime TradeTimeStamp
        {
            get
            {
                return tradeTimeStamp;
            }
            set
            {
                tradeTimeStamp = value;
            }
        }

        public int ShareQty
        {
            get
            {
                return shareQty;
            }
            set
            {
                shareQty = value;
            }
        }

        public double TradedPrice
        {
            get
            {
                return tradedPrice;
            }
            set
            {
                tradedPrice = value;
            }
        }

        public Trade()
        { }
        public Trade(Stock stockForTrade,
                     BuyOrSellInd buyOrSell,
                     DateTime tradeTimeStamp,
                     int shareQty,
                     double tradedPrice)
        {

            this.StockForTrade = stockForTrade;
            this.TradeTimeStamp = tradeTimeStamp;
            this.ShareQty = shareQty;
            this.TradedPrice = tradedPrice;
        }
    }
}
