using System.Collections.Generic;

namespace Bitdid.Core.Models
{

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

    public class CurrencyTag { 

        public long CurrencyId { get; set; }

        public long TagId { get; set; }

        public Currency Currency { get; set; }

        public Tag Tag { get; set; }
    }
}
