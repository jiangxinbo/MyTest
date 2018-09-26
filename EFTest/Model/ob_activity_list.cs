namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_activity_list")]
    public partial class ob_activity_list
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_activity_list()
        {
            ob_activity_members = new HashSet<ob_activity_members>();
            ob_activity_list_activity_tag = new HashSet<ob_activity_list_activity_tag>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string title { get; set; }

        [Required]
        [StringLength(500)]
        public string address { get; set; }

        public DateTime start_time { get; set; }

        public int topic_id { get; set; }

        public DateTime end_time { get; set; }

        [Required]
        [StringLength(200)]
        public string activity_poster { get; set; }

        public int members { get; set; }

        public int activity_type_id { get; set; }

        public int pay_type { get; set; }

        [Required]
        [StringLength(10)]
        public string amount { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string content { get; set; }

        public int sort { get; set; }

        public int finished { get; set; }

        public int is_delete { get; set; }

        public int create_hours { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_activity_members> ob_activity_members { get; set; }

        public virtual ob_activity_type ob_activity_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_activity_list_activity_tag> ob_activity_list_activity_tag { get; set; }

        public virtual ob_activity_topic ob_activity_topic { get; set; }
    }
}
