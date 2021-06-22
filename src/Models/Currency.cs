using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Currency")]
    public class Currency {

        public Currency() {
            Metadata = new HashSet<CurrencyMetadata>();
            CurrencyTags = new HashSet<CurrencyTag>();
            BaseCurrencyMarketPairs = new HashSet<MarketPair>();
            VsCurrencyMarketPairs = new HashSet<MarketPair>();
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

        public ICollection<MarketPair> BaseCurrencyMarketPairs { get; set; }

        public ICollection<MarketPair> VsCurrencyMarketPairs { get; set; }

        #endregion
    }

    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency> {

        public void Configure(EntityTypeBuilder<Currency> builder) {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.AltTitle)
                .HasMaxLength(255)
                .IsUnicode();

            builder.Property(_ => _.Description)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.Property(_ => _.DocsUrl)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.Property(_ => _.Logo)
                .HasMaxLength(1000)
                .IsUnicode();

            builder.Property(_ => _.Slug)
                .HasMaxLength(500)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.SourceCodeUrl)
                .HasMaxLength(500)
                .IsUnicode();

            builder.Property(_ => _.Symbol)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.Title)
                .HasMaxLength(255)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.WebsiteUrl)
                .HasMaxLength(500)
                .IsUnicode();

            builder.HasOne(_ => _.Category)
                .WithMany(__ => __.Currencies)
                .HasForeignKey(_ => _.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
