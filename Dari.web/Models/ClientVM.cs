using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dari.web.Models
{
    public class ClientVM
    {

        public int Id { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public String Telephone { get; set; }

        public String Email { get; set; }
        
        public string Password { get; set; }

        public string Image { get; set; }
        
    }
}