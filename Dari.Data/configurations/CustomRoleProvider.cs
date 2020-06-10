using System;
using System.Security.Principal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Dari.Data.configurations
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                return "";
            }

            set
            {
                
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override void CreateRole(string roleName)
        {
            
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            return true ;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles() { using (var db = new DariContext()) { return db.Roles.Select(r => r.Title).ToArray(); } }




        public override string[] GetRolesForUser(string nom) { using (var db = new DariContext()) { var personne = db.Clients.SingleOrDefault(u => u.Nom == nom); if (personne == null) return new string[] { }; return personne.Roles == null ? new string[] { } : personne.Roles.Select(u => u.Title).ToArray(); } }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string nom, string title)
        {
            using (var db = new DariContext())
            {
                var personne = db.Clients.SingleOrDefault(u => u.Nom == nom); if (personne == null) return false;
                var role = (from r in db.Roles where r.Title.Equals(title) && r.Clients.Any(u => u.Nom == nom) select r).First(); return role != null;
            }
        

    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override bool RoleExists(string roleName)
        {
            return true;
        }
    }

}
