namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_invitation_record")]
    public partial class ob_invitation_record
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string inviter { get; set; }

        [Required]
        [StringLength(50)]
        public string invitee { get; set; }

        [Required]
        [StringLength(50)]
        public string sta_date { get; set; }

        public DateTime create_time { get; set; }
    }
}
