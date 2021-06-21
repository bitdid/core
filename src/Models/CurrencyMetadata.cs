using System;

namespace Bitdid.Core.Models {

    public class CurrencyMetadata {
        

        public CurrencyMetadata() {

        }

        #region Properties

        public long Id { get; set; }

        public long CurrencyId { get; set; }

        /// <summary>
        /// Number of coins that can be traded for each other on an exchange.
        /// </summary>
        public int MarketPairCount { get; set; }

        public long MaxSupply { get; set; }

        public long CirculatingSupply { get; set; }

        public long TotalSupply { get; set; }

        public int Rank { get; set; }

        public DateTime LastUpdated { get; set; }

        #endregion

        #region Navigations 

        public Currency Currency { get; set; }

        #endregion
    }
}
