using EmployeeDatabaseFinal.Context;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EmployeeDatabaseFinal
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (DBContextEmployee db = new DBContextEmployee())
            {
                var user = db.Employee.FirstOrDefault(u => u.Username.Equals(username));

                var roles = from r in db.Employee
                            where r.Username == username
                            select r.Position.PositionName;

                if (db != null)
                {
                    string[] ret = new string[1];
                    ret[0] = user.Position.PositionName;
                    return ret;
                }
                else
                {

                    return null;
                }
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (DBContextEmployee db = new DBContextEmployee())
            {
                var user = db.Employee.FirstOrDefault(u => u.Username.Equals(username));

                var roles = from r in db.Employee
                            where r.Username == username
                            select r.Position.PositionName;


                if (user != null)
                    return user.Position.PositionName.Any(r => r.Equals(roleName));
                else
                    return false;
            }
        }

        

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}