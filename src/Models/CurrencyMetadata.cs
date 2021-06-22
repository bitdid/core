using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Currency_Metadata")]
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

    public class CurrencyMetadataConfiguration : IEntityTypeConfiguration<CurrencyMetadata> {

        public void Configure(EntityTypeBuilder<CurrencyMetadata> builder) {
            builder.HasKey(_ => _.Id);

            builder.HasOne(_ => _.Currency)
                .WithMany(__ => __.Metadata)
                .HasForeignKey(_ => _.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
