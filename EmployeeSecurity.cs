using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BasicAuth.Models;

namespace BasicAuth
{
    public class EmployeeSecurity
    {
        public static bool Login(string userName, string password)
        {
            using(AuthPracticeEntities entities = new AuthPracticeEntities())
            {
                return entities.Users.Any(user => user.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
                && user.Gender == password);
            }
        }
    }
}