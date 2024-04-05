namespace ASM2.Models
{
    public interface User
    {
        int id { get; set; }
        DateOnly DOB { get; set; }
        string fullName { get; set; }
        string email { get; set; }
        string phone { get; set; }
        string gender { get; set; }
    }

    public class Admin : User
    {
        public int id { get; set; }
        public DateOnly DOB { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
    }

    public class Teacher : User
    {
        public int id { get; set; }
        public DateOnly DOB { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
    }

    public class Student : User
    {
        public int id { get; set; }
        public DateOnly DOB { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public string major { get; set; }
    }
}
