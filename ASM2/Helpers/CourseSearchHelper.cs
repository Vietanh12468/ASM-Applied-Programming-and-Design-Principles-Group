using ASM2.Models;

namespace ASM2.Helpers
{
    public class CourseSearchHelper<T> : SearchHelper<T> where T : Course
    {
        protected override bool Compare(T course, string keyword)
        {
            if (course.name != null && course.name.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
        protected override bool Compare(T course, string keyword, string type)
        {
            if (course.name != null && course.name.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
