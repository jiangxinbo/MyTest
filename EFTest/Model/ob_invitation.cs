namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_invitation")]
    public partial class ob_invitation
    {
        public int id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string code { get; set; }

        public int total_num { get; set; }

        [StringLength(200)]
        public string share_img { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
