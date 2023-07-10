using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Spartial_String_arrangement_and_detection
{
    internal class Users_Authorization
    {

    }

    public class Permission
    {
        public Permission() { }
        public Permission(String role, String name, bool active)
        {
            this.Role = role;
            this.Name = name;
            this.Active = active;
        }

        public String Role { get; set; }
        public String Name { get; set; }
        public bool Active { get; set; }
    }

    public class User
    {
        public User() { }
        public User(int id, String name, List<String> roles)
        {
            this.Id = id;
            this.Name = name;
            this.Roles = roles;
        }
        public int Id { get; set; }
        public String Name { get; set; }
        public List<String> Roles { get; set; }
    }

    // see graphic in instructions for visual explanation of the permission and user data structures
    class Authorization
    {
        public List<Permission> Permissions { get; set; }
        public List<User> Users { get; set; }

        public Authorization(List<Permission> permissions, List<User> users)
        {
            this.Permissions = permissions;
            this.Users = users;
        }

        //   @rtype: list of strings
        //   @returns: a list of all the active permission names that the user with the corresponding user_id has
        //   @note: The order in which the permission names are returned is not important
        //   @example: listPermissions(1) ➡ ["View Orders", "Block User Account"]
        //  (purchased widgets not included since it is not active)


        public List<String> ListPermissions(int userId)
        {
            List<string> result = new List<string>();   
            //get the user whose user id corresponds to the Id from list of users in permissins.
            var Current_User = Users.Where(a => a.Id == userId).First();

            //return null if a user with this userId is not found
            if (Current_User == null) return null;

            //return all roles for this current user
            List<Permission> ActiveRoles = Permissions.Where(a=>a.Active).ToList();
            List<string> roles  = new List<string>();   
        }

        // @rtype: boolean value
        // @returns: true or false based on if the user with the corresponding user_id has the role that corresponds with the specific permission_name and that particular permission is active
        // @example: Example (Based on data from graphic)
        // checkPermitted("scooters near me", 2) ➡ true
        // checkPermitted("scooters near me", 1) ➡ false


        public bool CheckPermitted(String permissionName, int userId)
        {
            // get all roles from this current userId of a specific user
            string[] roles = Users.Where(a => a.Id == userId).First().Roles.ToArray();

            // return false if no user is found.
            if (roles.Length == 0) return false;

            // return true if a roles maps to the permission name parameter.
            if (roles.Contains(permissionName)) return true;

            //false is returned at the end indicating that not permssion mapped to this user matched the parameter @permissionname
            return false;

        }
    }
}
