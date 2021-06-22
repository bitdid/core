using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Exchange_MarketPairs")]
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

    public class ExchangeMarketPairConfiguration : IEntityTypeConfiguration<ExchangeMarketPair> {

        public void Configure(EntityTypeBuilder<ExchangeMarketPair> builder) {
            builder.HasKey(_ => new { 
                _.ExchangeId, 
                _.MarketPairId 
            });

            builder.Property(_ => _.ExchangeSymbol)
                .HasMaxLength(50)
                .IsUnicode();

            builder.HasOne(_ => _.Exchange)
                .WithMany(__ => __.ExchangeMarketPairs)
                .HasForeignKey(_ => _.ExchangeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(_ => _.MarketPair)
                .WithMany(__ => __.ExchangeMarketPairs)
                .HasForeignKey(_ => _.MarketPairId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
