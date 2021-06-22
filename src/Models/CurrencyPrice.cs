using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Currency_Price")]
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

    public class CurrencyPriceConfiguration : IEntityTypeConfiguration<CurrencyPrice> {

        public void Configure(EntityTypeBuilder<CurrencyPrice> builder) {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.MarketPair)
                .WithMany(__ => __.Prices)
                .HasForeignKey(_ => _.MarketPairId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(_ => _.Exchange)
                .WithMany(__ => __.Prices)
                .HasForeignKey(_ => _.ExchangeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
