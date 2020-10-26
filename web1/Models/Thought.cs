namespace web1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Thought")]
    public partial class Thought
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Thoughts { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
