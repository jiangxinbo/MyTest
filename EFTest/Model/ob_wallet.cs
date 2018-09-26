namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_wallet")]
    public partial class ob_wallet
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public int? currency_id { get; set; }

        public decimal valuta { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_currency ob_currency { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
