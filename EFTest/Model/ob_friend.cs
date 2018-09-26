namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_friend")]
    public partial class ob_friend
    {
        public int id { get; set; }

        public int? main_user_id { get; set; }

        public int? friend_user_id { get; set; }

        public int? state { get; set; }

        [StringLength(200)]
        public string name_note { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_user ob_user { get; set; }

        public virtual ob_user ob_user1 { get; set; }
    }
}
