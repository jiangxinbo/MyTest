namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.auth_user")]
    public partial class auth_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public auth_user()
        {
            auth_message = new HashSet<auth_message>();
            auth_user_groups = new HashSet<auth_user_groups>();
            ob_draft_news = new HashSet<ob_draft_news>();
            django_admin_log = new HashSet<django_admin_log>();
            auth_user_user_permissions = new HashSet<auth_user_user_permissions>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string first_name { get; set; }

        [Required]
        [StringLength(30)]
        public string last_name { get; set; }

        [Required]
        [StringLength(75)]
        public string email { get; set; }

        [Required]
        [StringLength(128)]
        public string password { get; set; }

        public bool is_staff { get; set; }

        public bool is_active { get; set; }

        public bool is_superuser { get; set; }

        public DateTime last_login { get; set; }

        public DateTime date_joined { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_message> auth_message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_user_groups> auth_user_groups { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ob_draft_news> ob_draft_news { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<django_admin_log> django_admin_log { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_user_user_permissions> auth_user_user_permissions { get; set; }
    }
}
