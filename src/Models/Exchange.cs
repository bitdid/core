using System;
using System.Collections.Generic;
using System.Text;

namespace Bitdid.Core.Models {

    public class Exchange {

        public Exchange() {
            ExchangeMarketPairs = new HashSet<ExchangeMarketPair>();
            Prices = new HashSet<CurrencyPrice>();
        }

        #region Properties

        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; }

        #endregion

        #region Navigations

        public ICollection<ExchangeMarketPair> ExchangeMarketPairs { get; set; }

        public ICollection<CurrencyPrice> Prices { get; set; }

        #endregion
    }
}
