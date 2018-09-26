namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_currency")]
    public partial class ob_currency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_currency()
        {
            ob_asset_log = new HashSet<ob_asset_log>();
            ob_wallet = new HashSet<ob_wallet>();
            ob_extract_currency = new HashSet<ob_extract_currency>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(1024)]
        public string logo { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        public decimal min_coin { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_asset_log> ob_asset_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_wallet> ob_wallet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_extract_currency> ob_extract_currency { get; set; }
    }
}
