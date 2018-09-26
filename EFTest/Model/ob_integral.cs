namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_integral")]
    public partial class integral
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public decimal valuta { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
