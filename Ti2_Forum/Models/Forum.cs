using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ti2_Forum.Models
{
    public class Forum
    {
        [Key]
        public int idForum { get; set; }


        public virtual ICollection<Mensagem> ListaDeMensagem { get; set; }
    }
}