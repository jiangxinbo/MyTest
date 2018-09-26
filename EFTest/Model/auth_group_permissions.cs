namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.auth_group_permissions")]
    public partial class auth_group_permissions
    {
        public int id { get; set; }

        public int group_id { get; set; }

        public int permission_id { get; set; }

        public virtual auth_group auth_group { get; set; }

        public virtual auth_permission auth_permission { get; set; }
    }
}
