namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_asset_log")]
    public partial class ob_asset_log
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(80)]
        public string onley_num { get; set; }

        public int? currency_id { get; set; }

        public bool plus { get; set; }

        public decimal valuta { get; set; }

        public int? operation_type_id { get; set; }

        public int? state { get; set; }

        [StringLength(500)]
        public string cause { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_currency ob_currency { get; set; }

        public virtual ob_asset_operation_type ob_asset_operation_type { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
