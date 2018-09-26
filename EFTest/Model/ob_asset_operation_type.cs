namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_asset_operation_type")]
    public partial class ob_asset_operation_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_asset_operation_type()
        {
            ob_asset_log = new HashSet<ob_asset_log>();
        }

        public int id { get; set; }

        [StringLength(80)]
        public string name { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_asset_log> ob_asset_log { get; set; }
    }
}
