using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.MarketPairs")]
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

        public Currency BaseCurrency { get; set; }

        public Currency VsCurrency { get; set; }

        public ICollection<ExchangeMarketPair> ExchangeMarketPairs { get; set; }

        public ICollection<CurrencyPrice> Prices { get; set; }

        #endregion
    }

    public class MarketPairConfiguration : IEntityTypeConfiguration<MarketPair> {

        public void Configure(EntityTypeBuilder<MarketPair> builder) {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.BaseSymbol)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.VsSymbol)
                .HasMaxLength(50)
                .IsUnicode()
                .IsRequired();

            builder.HasOne(_ => _.BaseCurrency)
                .WithMany(__ => __.BaseCurrencyMarketPairs)
                .HasForeignKey(_ => _.BaseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(_ => _.VsCurrency)
                .WithMany(__ => __.VsCurrencyMarketPairs)
                .HasForeignKey(_ => _.VsCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
