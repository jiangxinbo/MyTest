namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_integral_log")]
    public partial class integral_log
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public decimal valuta { get; set; }

        public decimal changed { get; set; }

        [StringLength(500)]
        public string cause { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
