namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_attenuation_pool")]
    public partial class ob_attenuation_pool
    {
        public int id { get; set; }

        public int news_id { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_news ob_news { get; set; }
    }
}
