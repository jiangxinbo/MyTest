namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_tags")]
    public partial class ob_tags
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_tags()
        {
            ob_draft_news_tag = new HashSet<ob_draft_news_tag>();
            ob_news_tag = new HashSet<ob_news_tag>();
        }

        public int id { get; set; }

        public int tag_type { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_draft_news_tag> ob_draft_news_tag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_news_tag> ob_news_tag { get; set; }
    }
}
