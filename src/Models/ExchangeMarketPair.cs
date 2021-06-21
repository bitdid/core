using System;

namespace Bitdid.Core.Models {

    public class ExchangeMarketPair {

        public ExchangeMarketPair() {

        }

        #region Properties

        public int ExchangeId { get; set; }

        public long MarketPairId { get; set; }

        public string ExchangeSymbol { get; set; }

        public DateTime? ListDate { get; set; }

        #endregion

        #region Navigations

        public Exchange Exchange { get; set; }

        public MarketPair MarketPair { get; set; }

        #endregion
    }
}
