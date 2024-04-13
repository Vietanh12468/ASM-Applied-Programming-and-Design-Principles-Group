using ASM2.Helpers;
using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Numerics;
using System.Reflection;

namespace ASM2.Controllers
{
    public class ClassController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.students = new List<Student>();
            ViewBag.typeObj = "Teacher";
            ViewBag.users = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Class cls, string teacherId, string teacherName, string courseName)
        {
            List<Teacher>? teachers = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
            Teacher teacher = FileHelper.FindObj<Teacher>(teachers, int.Parse(teacherId));
            cls.teacher = teacher;

            List<Course> courses = FileHelper.ReadFileList<Course>("Data/courses.json");
            Course course = FileHelper.FindObj<Course>(courses, courseName);
            cls.course = course;

            List<Class> classes = FileHelper.ReadFileList<Class>("Data/classes.json");
            cls.id = classes.Count + 1;

            classes.Add(cls);
            FileHelper.AddToJson(classes, "Data/classes.json");
            return View();
        }

        [HttpPost]
        public IActionResult SetObjForClass(string keyword, string typeObj, string hideTeacherName, string hideCourseName, string hideTeacherId)
        {
            ViewBag.students = new List<Student>();
            ViewBag.typeObj = typeObj;
            ViewBag.hideTeacherName = hideTeacherName;
            ViewBag.hideCourseName = hideCourseName;
            ViewBag.hideTeacherId = hideTeacherId;
            switch (typeObj)
            {
                case "Teacher":
                    List<Teacher>? teachers = FileHelper.ReadFileList<Teacher>("Data/teachers.json");
                    UserSearchHelper<Teacher> searchHelperTeacher = new UserSearchHelper<Teacher>();
                    List<Teacher> searchResultTeacher = searchHelperTeacher.SearchList(teachers, keyword);
                    ViewBag.users = searchResultTeacher;
                    break;
                case "Course":
                    List<Course>? courses = FileHelper.ReadFileList<Course>("Data/courses.json");
                    CourseSearchHelper<Course> searchHelperCourse = new CourseSearchHelper<Course>();
                    List<Course> searchResultCourse = searchHelperCourse.SearchList(courses, keyword);
                    ViewBag.users = searchResultCourse;
                    break;
                default:
                    List<Student>? students = FileHelper.ReadFileList<Student>("Data/students.json");
                    UserSearchHelper<Student> searchHelperStudent = new UserSearchHelper<Student>();
                    List<Student> searchResultStudent = searchHelperStudent.SearchList(students, keyword);
                    ViewBag.users = searchResultStudent;
                    break;
            }
            return View("Create");
        }
    }
}
