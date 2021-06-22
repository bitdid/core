using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitdid.Core.Models {

    [Table("Bitdid.Category")]
    public class Category {

        public Category() {
            Currencies = new HashSet<Currency>();

        }

        #region Properties

        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public int? ParentId { get; set; }

        #endregion

        #region Navigations

        public ICollection<Currency> Currencies { get; set; }

        #endregion
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category> {

        public void Configure(EntityTypeBuilder<Category> builder) {
            builder.HasKey(_ => _.Id);
            
            builder.Property(_ => _.Title)
                .HasMaxLength(255)
                .IsUnicode()
                .IsRequired();

            builder.Property(_ => _.Slug)
                .HasMaxLength(500)
                .IsUnicode()
                .IsRequired();
        }
    }
}
