using System;
using System.Collections.Generic;

namespace Bitdid.Core.Models {

    public class Currency {

        public Currency() {
            Metadata = new HashSet<CurrencyMetadata>();
            CurrencyTags = new HashSet<CurrencyTag>();
        }

        #region Properties

        public long Id { get; set; }

        public string Title { get; set; }

        public string AltTitle { get; set; }

        /// <summary>
        /// Symbol for crypto-currency. ex: BTC for bitcoin.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// Specify a Slug used in any Crypto-currency related URLs.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Crypto-currency logo url.
        /// </summary>
        public string Logo { get; set; }

        public DateTime? DateAdded { get; set; }

        public int? CategoryId { get; set; }

        public string Description { get; set; }

        public string WebsiteUrl { get; set; }

        public string SourceCodeUrl { get; set; }

        public string DocsUrl { get; set; }

        public int OrderNumber { get; set; }

        public int Rank { get; set; }

        #endregion

        #region Navigations

        public Category Category { get; set; }

        public ICollection<CurrencyTag> CurrencyTags { get; set; }

        public ICollection<CurrencyMetadata> Metadata { get; set; }


        #endregion
    }
}
