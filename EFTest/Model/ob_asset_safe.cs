namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_asset_safe")]
    public partial class ob_asset_safe
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(200)]
        public string payment_num { get; set; }

        [StringLength(20)]
        public string phone_num { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
