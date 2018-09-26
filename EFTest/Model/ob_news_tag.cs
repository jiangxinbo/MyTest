namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_news_tag")]
    public partial class ob_news_tag
    {
        public int id { get; set; }

        public int news_id { get; set; }

        public int tag_id { get; set; }

        public virtual ob_news ob_news { get; set; }

        public virtual ob_tags ob_tags { get; set; }
    }
}
