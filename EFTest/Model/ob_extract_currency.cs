namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_extract_currency")]
    public partial class ob_extract_currency
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(80)]
        public string only_num { get; set; }

        [StringLength(80)]
        public string txid { get; set; }

        public int? currency_id { get; set; }

        public decimal valuta { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        public int state { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_currency ob_currency { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
