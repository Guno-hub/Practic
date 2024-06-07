using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    public static class Registration
    {
        public static bool IsUsernameAvailable(string username)
        {
            using (DataBaseContext context = new DataBaseContext())
                return context.Set<User>().Any(u => u.Username == username);
        }   

        public static bool IsPasswordValid(string password)
        {
            return password.Length >= 6 && password.Any(char.IsDigit) && password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) && password.All(char.IsLetterOrDigit);
        }
    }

    public static class Login
    {
        public static bool IsCredentialsValid(string username, string password)
        {
            using (DataBaseContext context = new DataBaseContext())
                return context.Set<User>().Any(u => u.Username == username && u.Password == password);
        }
    }
}
