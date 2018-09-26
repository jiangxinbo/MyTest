namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_news_flash")]
    public partial class ob_news_flash
    {
        public int id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        public int flash_type { get; set; }

        [StringLength(1073741823)]
        public string content { get; set; }

        public bool audit { get; set; }

        public int sort { get; set; }

        [StringLength(100)]
        public string reprint_title { get; set; }

        [StringLength(300)]
        public string reprint_url { get; set; }

        public int create_hours { get; set; }

        public DateTime create_time { get; set; }
    }
}
