using ASM2.Models;
using System.Reflection;

namespace ASM2.Helpers
{
    public class LoginHelper
    {
        public static bool LoginProxy<T>(T loginUser, string password)
        {
            PropertyInfo passwordProperty = typeof(T).GetProperty("password");
            if (loginUser != null)
            {
                if (string.Equals(passwordProperty.GetValue(loginUser), password))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
    }
}
