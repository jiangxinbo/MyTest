namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_activity_list_activity_tag")]
    public partial class ob_activity_list_activity_tag
    {
        public int id { get; set; }

        public int activitylist_id { get; set; }

        public int activitytag_id { get; set; }

        public virtual ob_activity_list ob_activity_list { get; set; }

        public virtual ob_activity_tag ob_activity_tag { get; set; }
    }
}
