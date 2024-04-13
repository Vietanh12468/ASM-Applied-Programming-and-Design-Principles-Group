namespace ASM2.Models
{
    public class Class
    {
        public int id { get; set; }
        public string name { get; set; }
        public Teacher teacher { get; set; }
        public Course course { get; set; }
        public List<User> student { get; set; }
    }
}
