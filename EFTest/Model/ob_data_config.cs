namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_data_config")]
    public partial class ob_data_config
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string task_name { get; set; }

        public int daily_limit { get; set; }

        public int total_limit { get; set; }

        public int point { get; set; }

        public DateTime create_time { get; set; }
    }
}
