namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_activity_members")]
    public partial class ob_activity_members
    {
        public int id { get; set; }

        public int activity_id { get; set; }

        [Required]
        [StringLength(200)]
        public string name { get; set; }

        [Required]
        [StringLength(30)]
        public string phone { get; set; }

        [Required]
        [StringLength(200)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string company_name { get; set; }

        [Required]
        [StringLength(100)]
        public string position { get; set; }

        public int is_pay { get; set; }

        public DateTime create_time { get; set; }

        public virtual ob_activity_list ob_activity_list { get; set; }
    }
}
