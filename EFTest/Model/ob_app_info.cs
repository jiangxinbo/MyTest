namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_app_info")]
    public partial class ob_app_info
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string app_name { get; set; }

        [Required]
        [StringLength(200)]
        public string app_key { get; set; }

        [Required]
        [StringLength(200)]
        public string app_secret { get; set; }

        [StringLength(300)]
        public string white_ip { get; set; }

        [StringLength(300)]
        public string white_org { get; set; }

        public int app_permission { get; set; }

        public DateTime create_time { get; set; }
    }
}
