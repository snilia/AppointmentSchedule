using AppointmentSchedule.DAL;
using AppointmentSchedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace AppointmentSchedule.Infrastructure
{
    public class UsersRoleProvider : RoleProvider
    {
        //private AppSchContext db = new AppSchContext();
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
            using (var context = new AppSchContext())
            {
                var users = context.Users.Where(u => usernames.Contains(u.Username)).ToList();
                var roles = context.Roles.Where(r => roleNames.Contains(r.RoleName)).ToList();

                foreach (var user in users)
                {
                    foreach (var role in roles)
                    {
                        if (!context.UserRoleMaps.Any(urm => urm.UserID == user.ID && urm.RoleID == role.ID))
                        {
                            context.UserRoleMaps.Add(new UserRoleMap { UserID = user.ID, RoleID = role.ID });
                        }
                    }
                }
                context.SaveChanges();
            }
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
            /*    var userRoles = (from user in db.Users ////////// second should be better ///////////////////
                                 join roleMapping in db.UserRoleMaps
                                 on user.ID equals roleMapping.UserID
                                 join role in db.Roles
                                 on roleMapping.RoleID equals role.ID
                                 where user.Username == username
                                 select role.RoleName).ToArray();
                return userRoles; */
            using (var context = new AppSchContext()) 
            {
                var user = context.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    return user.UserRoleMaps.Select(ur => ur.Role.RoleName).ToArray();
                }
                return new string[] { };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            using (var context = new AppSchContext()) 
            {
                var user = context.Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                {
                    return user.UserRoleMaps.Any(ur => ur.Role.RoleName.Equals(roleName, StringComparison.OrdinalIgnoreCase));
                }
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            using (var context = new AppSchContext())
            {
                var users = context.Users.Where(u => usernames.Contains(u.Username)).ToList();
                var roles = context.Roles.Where(r => roleNames.Contains(r.RoleName)).ToList();

                foreach (var user in users)
                {
                    foreach (var role in roles)
                    {
                        var userRoleMap = context.UserRoleMaps.FirstOrDefault(urm => urm.UserID == user.ID && urm.RoleID == role.ID);
                        if (userRoleMap != null)
                        {
                            context.UserRoleMaps.Remove(userRoleMap);
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}