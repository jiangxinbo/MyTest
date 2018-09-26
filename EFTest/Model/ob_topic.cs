namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_topic")]
    public partial class ob_topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_topic()
        {
            ob_draft_news = new HashSet<ob_draft_news>();
            ob_news = new HashSet<ob_news>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(1024)]
        public string icon { get; set; }

        public int sort { get; set; }

        public int topic_type { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_draft_news> ob_draft_news { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_news> ob_news { get; set; }
    }
}
