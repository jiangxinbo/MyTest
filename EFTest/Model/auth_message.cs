namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.auth_message")]
    public partial class auth_message
    {
        public int id { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string message { get; set; }

        public virtual auth_user auth_user { get; set; }
    }
}
