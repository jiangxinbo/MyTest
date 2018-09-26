namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_user_record")]
    public partial class ob_user_record
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public int new_id { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_news ob_news { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
