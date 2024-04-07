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
        void CreateUser(int id,  DateOnly DOB, string fullName, string email, string phone, string gender);
    }

    public class Admin : User
    {
        public int id { get; set; }
        public DateOnly DOB { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public void CreateUser(int id, DateOnly DOB, string fullName, string email, string phone, string gender)
        {
            this.id = id;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
            this.DOB = DOB;
        }
    }

    public class Teacher : User
    {
        public int id { get; set; }
        public DateOnly DOB { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public void CreateUser(int id, DateOnly DOB, string fullName, string email, string phone, string gender)
        {
            this.id = id;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
            this.DOB = DOB;
        }
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
        public void CreateUser(int id, DateOnly DOB, string fullName, string email, string phone, string gender)
        {
            this.id = id;
            this.fullName = fullName;
            this.email = email;
            this.phone = phone;
            this.gender = gender;
            this.major = major;
            this.DOB = DOB;
        }
    }
}
