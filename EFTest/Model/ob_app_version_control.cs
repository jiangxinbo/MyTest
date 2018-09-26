namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_app_version_control")]
    public partial class ob_app_version_control
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string app_type { get; set; }

        [Required]
        [StringLength(100)]
        public string app_version { get; set; }

        [StringLength(500)]
        public string desc { get; set; }

        [StringLength(100)]
        public string minimum_support { get; set; }

        [StringLength(500)]
        public string redirect_url { get; set; }

        public DateTime create_time { get; set; }
    }
}
