namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_banner")]
    public partial class ob_banner
    {
        public int id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(300)]
        public string pic { get; set; }

        public int position_type { get; set; }

        public int in_site { get; set; }

        [StringLength(200)]
        public string url { get; set; }

        public int sort { get; set; }

        public int show { get; set; }

        public DateTime create_time { get; set; }
    }
}
