namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_feedback")]
    public partial class ob_feedback
    {
        public int id { get; set; }

        [StringLength(1024)]
        public string content { get; set; }

        [StringLength(1024)]
        public string ci_type { get; set; }

        [StringLength(1024)]
        public string ci_number { get; set; }

        public int sort { get; set; }

        public DateTime create_time { get; set; }
    }
}
