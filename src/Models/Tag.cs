using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Tags")]
    public class Tag {

        public Tag() {
            CurrencyTags = new HashSet<CurrencyTag>();
        }

        public long Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        #region Navigations

        public ICollection<CurrencyTag> CurrencyTags { get; set; }

        #endregion
    }

    [Table("Bitdid.Currency_Tags")]
    public class CurrencyTag { 

        public long CurrencyId { get; set; }

        public long TagId { get; set; }

        public Currency Currency { get; set; }

        public Tag Tag { get; set; }
    }

    public class TagConfiguration : IEntityTypeConfiguration<Tag> {

        public void Configure(EntityTypeBuilder<Tag> builder) {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Title)
                .HasMaxLength(255)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.Slug)
                .HasMaxLength(300)
                .IsUnicode()
                .IsRequired();
        }
    }

    public class CurrencyTagConfiguration : IEntityTypeConfiguration<CurrencyTag> {

        public void Configure(EntityTypeBuilder<CurrencyTag> builder) {
            builder.HasKey(_ => new {
                _.CurrencyId,
                _.TagId
            });

            builder.HasOne(_ => _.Currency)
                .WithMany(__ => __.CurrencyTags)
                .HasForeignKey(_ => _.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(_ => _.Tag)
                .WithMany(__ => __.CurrencyTags)
                .HasForeignKey(_ => _.TagId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
