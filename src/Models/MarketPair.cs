using System;
using System.Collections.Generic;

namespace Bitdid.Core.Models {

    public class MarketPair {

        public MarketPair() {
            ExchangeMarketPairs = new HashSet<ExchangeMarketPair>();
            Prices = new HashSet<CurrencyPrice>();
        }

        #region Properties

        public long Id { get; set; }

        public DateTime CreateDate { get; set; }

        public long BaseCurrencyId { get; set; }

        public string BaseSymbol { get; set; }

        public long VsCurrencyId { get; set; }

        public string VsSymbol { get; set; }

        #endregion

        #region Navigations

        public ICollection<ExchangeMarketPair> ExchangeMarketPairs { get; set; }

        public ICollection<CurrencyPrice> Prices { get; set; }

        #endregion
    }
}
