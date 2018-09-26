namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_activity_topic")]
    public partial class ob_activity_topic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_activity_topic()
        {
            ob_activity_list = new HashSet<ob_activity_list>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(1024)]
        public string icon { get; set; }

        public int sort { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_activity_list> ob_activity_list { get; set; }
    }
}
