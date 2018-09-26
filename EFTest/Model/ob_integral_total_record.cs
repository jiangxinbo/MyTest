namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.integral_total_record")]
    public partial class integral_total_record
    {
        public int id { get; set; }

        public decimal add_val { get; set; }

        public decimal sub_val { get; set; }

        [Column(TypeName = "date")]
        public DateTime? day { get; set; }
    }
}
