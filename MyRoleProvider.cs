using StudentManagementSystem.Models.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace StudentManagementSystem
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            //missionDB db = new missionDB();
            //string rl = db.tblUsers.Where(u => u.UserName == username).FirstOrDefault().UserName;
            ////string rl1 = db.tblRoles.Where(u => u.RoleName == rl).FirstOrDefault().RoleName;
            //string[] rls = { rl };
            //return rls;

            //missionDB db = new missionDB();
            //string mUser = string.Empty;
            //string mRole = string.Empty;

            //var user = db.tblUsers.Where(a => a.UserName == username).FirstOrDefault();
            //    if (user!=null)
            //{
            //    mUser = user.UserName;
            //}
            //    var Role=db.tblRoles.Where(a=>a.tblUser=username)

            using (missionDB context = new missionDB())
            {
                var userRol = (from user in context.tblUsers
                               join roll in context.tblRoles
                               on user.UserId equals roll.UserId
                               where user.UserName == username
                               select roll.RoleName).ToArray();
                return userRol;
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
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