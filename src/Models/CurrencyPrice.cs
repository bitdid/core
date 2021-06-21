using System;

namespace Bitdid.Core.Models {

    public class CurrencyPrice {

        public CurrencyPrice() {

        }

        #region Properties

        public long Id { get; set; }

        public long MarketPairId { get; set; }

        public int? ExchangeId { get; set; }

        public decimal MarketCap { get; set; }

        public decimal Volume24h { get; set; }

        public decimal PercentChange1h { get; set; }

        public decimal PercentChange4h { get; set; }

        public decimal PercentChange24h { get; set; }

        public decimal PercentChange7d { get; set; }

        public DateTime LastUpdated { get; set; }

        #endregion

        #region Navigations

        public MarketPair MarketPair { get; set; }

        public Exchange Exchange { get; set; }


        #endregion
    }
}
