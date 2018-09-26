namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.django_site")]
    public partial class django_site
    {
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string domain { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
