namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.auth_permission")]
    public partial class auth_permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public auth_permission()
        {
            auth_group_permissions = new HashSet<auth_group_permissions>();
            auth_user_user_permissions = new HashSet<auth_user_user_permissions>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int content_type_id { get; set; }

        [Required]
        [StringLength(100)]
        public string codename { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_group_permissions> auth_group_permissions { get; set; }

        public virtual django_content_type django_content_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<auth_user_user_permissions> auth_user_user_permissions { get; set; }
    }
}
