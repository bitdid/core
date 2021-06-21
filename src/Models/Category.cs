using System.Collections.Generic;

namespace Bitdid.Core.Models
{

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
}
