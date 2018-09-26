namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_news_recommend")]
    public partial class ob_news_recommend
    {
        public int id { get; set; }

        public int new_id { get; set; }

        [StringLength(200)]
        public string new_title { get; set; }

        public int position { get; set; }

        public DateTime new_time { get; set; }

        public DateTime create_time { get; set; }
    }
}
