namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_user")]
    public partial class ob_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ob_user()
        {
            ob_asset_log = new HashSet<ob_asset_log>();
            ob_asset_safe = new HashSet<ob_asset_safe>();
            ob_charge_editor = new HashSet<ob_charge_editor>();
            ob_editor = new HashSet<ob_editor>();
            ob_enshrine = new HashSet<ob_enshrine>();
            ob_error_pwd_log = new HashSet<ob_error_pwd_log>();
            ob_extract_currency = new HashSet<ob_extract_currency>();
            ob_friend = new HashSet<ob_friend>();
            ob_friend1 = new HashSet<ob_friend>();
            ob_group = new HashSet<ob_group>();
            ob_group_member = new HashSet<ob_group_member>();
            integral = new HashSet<integral>();
            integral_log = new HashSet<integral_log>();
            ob_invitation = new HashSet<ob_invitation>();
            ob_login_record = new HashSet<ob_login_record>();
            ob_share_record = new HashSet<ob_share_record>();
            ob_wallet = new HashSet<ob_wallet>();
            ob_user_record = new HashSet<ob_user_record>();
        }

        public int id { get; set; }

        [StringLength(200)]
        public string nickname { get; set; }

        [StringLength(1024)]
        public string avatar { get; set; }

        public int? sex { get; set; }

        [StringLength(30)]
        public string city { get; set; }

        [StringLength(30)]
        public string country { get; set; }

        [StringLength(30)]
        public string province { get; set; }

        public int? user_type { get; set; }

        public int lock_expires { get; set; }

        [StringLength(200)]
        public string refresh_token { get; set; }

        public DateTime create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_asset_log> ob_asset_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_asset_safe> ob_asset_safe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_charge_editor> ob_charge_editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_editor> ob_editor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_enshrine> ob_enshrine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_error_pwd_log> ob_error_pwd_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_extract_currency> ob_extract_currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_friend> ob_friend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_friend> ob_friend1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_group> ob_group { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_group_member> ob_group_member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<integral> integral { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<integral_log> integral_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_invitation> ob_invitation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_login_record> ob_login_record { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_share_record> ob_share_record { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_wallet> ob_wallet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_user_record> ob_user_record { get; set; }
    }
}
