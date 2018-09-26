namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_draft_news")]
    public partial class ob_draft_news
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_draft_news()
        {
            ob_draft_news_tag = new HashSet<ob_draft_news_tag>();
        }

        public int id { get; set; }

        public int user_id { get; set; }

        [StringLength(200)]
        public string title { get; set; }

        [StringLength(200)]
        public string subhead { get; set; }

        [Column("abstract")]
        [StringLength(1073741823)]
        public string abstractx { get; set; }

        public int new_type { get; set; }

        public int? editor_id { get; set; }

        [StringLength(100)]
        public string new_editor { get; set; }

        public int content_type { get; set; }

        public int? topic_id { get; set; }

        [StringLength(1024)]
        public string figure { get; set; }

        [StringLength(1073741823)]
        public string content { get; set; }

        public bool audit { get; set; }

        public int sort { get; set; }

        public bool original { get; set; }

        public int read_num { get; set; }

        public int share_num { get; set; }

        public int? charge_editor_id { get; set; }

        [StringLength(100)]
        public string reprint_title { get; set; }

        [StringLength(300)]
        public string reprint_url { get; set; }

        public int share_level { get; set; }

        public int current_integral { get; set; }

        [StringLength(100)]
        public string media_str { get; set; }

        public int create_hours { get; set; }

        public DateTime create_time { get; set; }

        public virtual auth_user auth_user { get; set; }

        public virtual ob_charge_editor ob_charge_editor { get; set; }

        public virtual ob_editor ob_editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_draft_news_tag> ob_draft_news_tag { get; set; }

        public virtual ob_topic ob_topic { get; set; }
    }
}
