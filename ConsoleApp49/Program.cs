using ConsoleApp49.Context;
using ConsoleApp49.Models;
using ConsoleApp49.Repositories.Concretes;
using ConsoleApp49.Services;
using ConsoleApp49.UnitofWork;


namespace ConsoleApp49
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var context = new UniversityDbContext();

            var studentRepo = new StudentRepository(context);
            var courseRepo = new CourseRepository(context);
            var teacherRepo = new TeacherRepository(context);
            var facultyRepo = new FacultyRepository(context);
            
            //var allStudent = await studentRepo.GetAllAsync();

            //foreach (var student in allStudent)
            //{
            //    Console.WriteLine($"{student.FirstName} {student.LastName} {student.Faculty}");
            //}


            //var allTeacher = await courseRepo.getAllCourseWithTeacherNameAsync();
            //foreach(var teacher in allTeacher)
            //{
            //    Console.WriteLine($"{teacher.Firstname} {teacher.Lastname} {teacher.Coursename}");
            //}

            var uow = new UnitOfWork(context,studentRepo,facultyRepo,courseRepo,teacherRepo);
            var service = new StudentService(uow);

            var studentToUpdate = await uow.Students.GetByIdAsync(4);
            studentToUpdate.FirstName = "Tural";
            studentToUpdate.LastName = "Qasimov";

            var studentToAdd = new Student
            {
                FirstName = "Taleh",
                LastName = "Orucov",
                FacultyId = 3
            };

            await service.TransactionStudentOperation(studentToAdd, studentToUpdate);
        }
    }
}
