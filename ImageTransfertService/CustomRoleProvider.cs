using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using DataLib;

namespace ImageTransfertService
{
    class CustomRoleProvider : RoleProvider
    {
        public override String ApplicationName { get; set; }

        public override String[] GetRolesForUser(String username)
        {
            String[] roles;
            try
            {
                Connexion connex = new Connexion();
                User user = connex.getUser(username);
                String role = user.getRole();
                if (role.Equals("admin"))
                {
                    roles = new String[2];
                    roles[0] = "admin";
                    roles[1] = "user";
                }
                else
                {
                    roles = new String[1];
                    roles[0] = role;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return new String[] { /*XXXXXX.getRoles(username)*/ null };
        }

        public override bool IsUserInRole(String username, String roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
        }

        public override void AddUsersToRoles(String[] usernames, String[]
        roleNames)
        {
            throw new Exception("Unable to perform this action");
        }

        public override void CreateRole(String roleName)
        {
            throw new Exception("Unable to perform this action");
        }

        public override bool DeleteRole(String roleName, bool throwOnPopulatedRole)
        {
            throw new Exception("Unable to perform this action");
        }

        public override String[] FindUsersInRole(String roleName, String
        usernameToMatch)
        {
            throw new Exception("Unable to perform this action");
        }

        public override String[] GetAllRoles()
        {
            throw new Exception("Unable to perform this action");
        }

        public override String[] GetUsersInRole(String roleName)
        {
            throw new Exception("Unable to perform this action");
        }

        public override void RemoveUsersFromRoles(String[] usernames, String[]
        roleNames)
        {
            throw new Exception("Unable to perform this action");
        }

        public override bool RoleExists(String roleName)
        {
            throw new Exception("Unable to perform this action");
        }
    }
}