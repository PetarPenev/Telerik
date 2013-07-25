using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11.UserDatabaseContext;
using System.Diagnostics;
using System.Transactions;

namespace _11.UserDatabaseClient
{
    public class Program
    {
        public static void AddAdmin(string username)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope()){
                    using (UserGroupsEntities context = new UserGroupsEntities())
                    {
                        int? adminGroupId = (from userGroup in context.Groups
                                             where userGroup.GroupName.ToLower() == "admins"
                                             select userGroup.GroupId).Cast<int?>().FirstOrDefault();

                        int adminGroupCount = ((from userGroup in context.Groups
                                                where userGroup.GroupName.ToLower() == "admins"
                                                select userGroup.GroupId).Count());

                        Debug.Assert(adminGroupId == null || adminGroupCount <= 1,
                            "Error in database : cannot have more than one groups with the same name; check your constraints");

                        if (adminGroupId == null)
                        {
                            Group group = new Group
                            {
                                GroupName = "Admins",
                                Users = new HashSet<User>()
                            };
                            context.Groups.Add(group);
                            context.SaveChanges();
                            adminGroupId = group.GroupId;
                        }

                        User user = new User
                        {
                            UserName = username,
                            GroupId = adminGroupId
                        };

                        context.Users.Add(user);
                        context.SaveChanges();

                        scope.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Main()
        {
            string username = "LinuxAdmin";
            AddAdmin(username);
        }
    }
}