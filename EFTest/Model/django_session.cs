namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.django_session")]
    public partial class django_session
    {
        [Key]
        [StringLength(40)]
        public string session_key { get; set; }

        [Required]
        [StringLength(1073741823)]
        public string session_data { get; set; }

        public DateTime expire_date { get; set; }
    }
}
