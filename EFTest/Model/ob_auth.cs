namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_auth")]
    public partial class ob_auth
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        public int? identity_type { get; set; }

        [Required]
        [StringLength(200)]
        public string identifier { get; set; }

        [Required]
        [StringLength(200)]
        public string credential { get; set; }

        [StringLength(200)]
        public string union_id { get; set; }

        public DateTime create_time { get; set; }
    }
}
