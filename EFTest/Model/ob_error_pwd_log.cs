namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_error_pwd_log")]
    public partial class ob_error_pwd_log
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(20)]
        public string payment_num { get; set; }

        [Column(TypeName = "date")]
        public DateTime day { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
