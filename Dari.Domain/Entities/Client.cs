using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
   public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public String Telephone { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Image { get; set; }
        public virtual List<Role> Roles { get; set; }

    }
}
