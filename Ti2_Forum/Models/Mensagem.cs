using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ti2_Forum.Models
{
    public class Mensagem
    {
        [Key]
        public int idMsg { get; set; }

        public string mensagem { get; set; }

        [Required]
        [ForeignKey("ForumId")]
        public int ForumIdFk { get; set; }
        public Forum ForumId { get; set; }
    }
}