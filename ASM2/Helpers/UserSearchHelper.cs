using ASM2.Models;

namespace ASM2.Helpers
{
    public class UserSearchHelper : SearchHelper<User>
    {
        protected override bool Compare(User user, string keyword)
        {
            if (user.fullName != null && user.fullName.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
        protected override bool Compare(User user, string keyword, string type)
        {
            if (user.fullName != null && user.fullName.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
