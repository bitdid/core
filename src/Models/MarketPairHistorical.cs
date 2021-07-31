using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models
{
    /// <summary>
    /// This will keep OHLCV Historical data for any <see cref="MarketPair"/> currencies.
    /// </summary>
    [Table("Bitdid.MarketPair_Historical")]
    public class MarketPairHistorical {

        public MarketPairHistorical() { }

        #region Properties

        public long Id { get; set; }

        public int? ExchangeId { get; set; }

        public long MarketPairId { get; set; }

        public DateTime TimeOpen { get; set; }

        public DateTime TimeHigh { get; set; }
        
        public DateTime TimeLow { get; set; }

        public DateTime TimeClose { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public decimal Volume { get; set; }

        public decimal MarketCap { get; set; }

        #endregion

        #region Navigations

        public Exchange Exchange { get; set; }

        public MarketPair MarketPair { get; set; }

        #endregion
    }

    public class MarketPairHistoricalConfiguration : IEntityTypeConfiguration<MarketPairHistorical> {

        public void Configure(EntityTypeBuilder<MarketPairHistorical> builder) {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.Exchange)
                .WithMany(__ => __.MarketPairHistorical)
                .HasForeignKey(_ => _.ExchangeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(_ => _.MarketPair)
                .WithMany(__ => __.MarketPairHistorical)
                .HasForeignKey(_ => _.MarketPairId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
