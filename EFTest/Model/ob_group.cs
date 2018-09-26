namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_group")]
    public partial class ob_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_group()
        {
            ob_group_member = new HashSet<ob_group_member>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        public int? group_number { get; set; }

        public int? main_user_id { get; set; }

        [StringLength(1024)]
        public string logo { get; set; }

        public int describe { get; set; }

        public int? state { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_group_member> ob_group_member { get; set; }

        public virtual ob_user ob_user { get; set; }
    }
}
