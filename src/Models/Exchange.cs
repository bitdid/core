using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Exchanges")]
    public class Exchange {

        public Exchange() {
            ExchangeMarketPairs = new HashSet<ExchangeMarketPair>();
            Prices = new HashSet<CurrencyPrice>();
            MarketPairHistorical = new HashSet<MarketPairHistorical>();
        }

        #region Properties

        public int Id { get; set; }

        public string Title { get; set; }

        public string AltTitle { get; set; }

        public string Slug { get; set; }

        public string WebsiteUrl { get; set; }

        public string Description { get; set; }

        #endregion

        #region Navigations

        public ICollection<ExchangeMarketPair> ExchangeMarketPairs { get; set; }

        public ICollection<CurrencyPrice> Prices { get; set; }

        public ICollection<MarketPairHistorical> MarketPairHistorical { get; set; }

        #endregion
    }


    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange> {

        public void Configure(EntityTypeBuilder<Exchange> builder) {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Title)
                .HasMaxLength(255)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.AltTitle)
                .HasMaxLength(255)
                .IsUnicode();

            builder.Property(_ => _.Slug)
                .HasMaxLength(500)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.WebsiteUrl)
                .HasMaxLength(500)
                .IsUnicode();

            builder.Property(_ => _.Description)
                .HasMaxLength(1000)
                .IsUnicode();


        }
    }
}
