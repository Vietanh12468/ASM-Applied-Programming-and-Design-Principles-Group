using ASM2.Models;

namespace ASM2.Helpers
{
    public class UserSearchHelper<T> : SearchHelper<T> where T : User
    {
        protected override bool Compare(T user, string keyword)
        {
            if (user.fullName != null && user.fullName.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
        protected override bool Compare(T user, string keyword, string type)
        {
            if (user.fullName != null && user.fullName.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
