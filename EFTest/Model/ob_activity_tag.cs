namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_activity_tag")]
    public partial class ob_activity_tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_activity_tag()
        {
            ob_activity_list_activity_tag = new HashSet<ob_activity_list_activity_tag>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_activity_list_activity_tag> ob_activity_list_activity_tag { get; set; }
    }
}
