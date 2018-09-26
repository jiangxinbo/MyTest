namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.auth_user_user_permissions")]
    public partial class auth_user_user_permissions
    {
        public int id { get; set; }

        public int user_id { get; set; }

        public int permission_id { get; set; }

        public virtual auth_permission auth_permission { get; set; }

        public virtual auth_user auth_user { get; set; }
    }
}
