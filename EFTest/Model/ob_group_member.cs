namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_group_member")]
    public partial class ob_group_member
    {
        public int id { get; set; }

        public int group_id { get; set; }

        public int? member_id { get; set; }

        [StringLength(200)]
        public string name_note { get; set; }

        public int? level { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_group ob_group { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
