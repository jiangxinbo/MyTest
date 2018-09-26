namespace EFTest.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("obchain_mode.ob_media")]
    public partial class ob_media
    {
        public int id { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(1024)]
        public string icon { get; set; }

        public int volume { get; set; }

        public DateTime create_time { get; set; }
    }
}
