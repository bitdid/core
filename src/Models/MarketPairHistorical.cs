using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bitdid.Core.Models
{
    /// <summary>
    /// This will keep OHLCV Historical data for any <see cref="MarketPair"/> currencies.
    /// </summary>
    [Table("Bitdid.MarketPair_Historical")]
    public class MarketPairHistorical {

        public long Id { get; set; }

        public int? ExchangeId { get; set; }

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
    }
}
