using UniversityManager.Entities;
using UniversityManager.Services;

string PersonFilePath = "PersonsFile";
string studentFilePath = "StudentFile";
string adminFilePath = "AdminFile";
string courseFilePath = "CoursesFile";
string? personName;
string? personPassword;
bool exit = false;

RegisterServises registerService = new RegisterServises(PersonFilePath);
StudentService stService = new StudentService(PersonFilePath, courseFilePath);
AdminService adService = new AdminService(studentFilePath, courseFilePath, adminFilePath);

Student student = new Student();
Admin admin = new Admin();

#region inputs

char? input;
int? UserChoice;
string courseName;
string targetCourse;

#endregion

while (true)
{
    Console.WriteLine("\nL to login   R to register");
    input = Console.ReadKey().KeyChar;

    switch (input.ToString().ToLower())
    {
        case "l":
            Console.WriteLine("enter your name:");
            personName = Console.ReadLine();

            Console.WriteLine("enter your password");
            personPassword = Console.ReadLine();

            DataBase.activeUser = registerService.Login(personName, personPassword);

            if (DataBase.activeUser != null)
            {
                if (student == (Student)DataBase.activeUser)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\nchoose Action: 1.Get all Courses  2.Get student Course  3.take Course   4.logout");
                        UserChoice = int.Parse(Console.ReadLine());

                        switch (UserChoice)
                        {
                            case 1:
                                Console.WriteLine("\n\nall Courses:");
                                stService.GetAllCourse().ForEach(x => Console.WriteLine(x.name));
                                break;

                            case 2:
                                Console.WriteLine("\n\nyour Courses:");
                                stService.GetStudentCourses(DataBase.activeUser.id);
                                break;

                            case 3:
                                Console.WriteLine();
                                Console.WriteLine("\n\nall Courses:");
                                stService.GetAllCourse().ForEach(x => Console.WriteLine(x.name));

                                Console.WriteLine("\nchoose one course");
                                courseName = Console.ReadLine();
                                stService.TakeCourse(DataBase.activeUser.id, courseName);   // need Course Id
                                break;

                            case 4:
                                DataBase.activeUser = null;
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("invalid input");
                                break;
                        }
                    }

                    exit = false;
                }
                else if (admin == (Admin)DataBase.activeUser)
                {
                    while (!exit)
                    {
                        Console.WriteLine("\n\nchoose your action: \n1.Create Course\n2.get all Courses\n3.get Course Students\n4.Update course\n5.delete Course \n6.logout");
                        UserChoice = int.Parse(Console.ReadLine());

                        switch (UserChoice)
                        {
                            case 1:
                                Course newCourse = new Course();
                                Console.WriteLine("Course name:");
                                newCourse.name = Console.ReadLine();

                                adService.Create(newCourse);
                                break;

                            case 2:
                                Console.WriteLine("\nall courses:");
                                adService.GetAll().ForEach(c => Console.WriteLine(c.name));
                                break;

                            case 3:
                                Console.WriteLine("enter Course name:");
                                List<Student> studentList = adService.StudentsCourse(Console.ReadLine());

                                Console.WriteLine("students in course:");
                                studentList.ForEach(x => Console.WriteLine(x.name));
                                break;


                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nyou dont have account!...");
            }
            break;


        case "r":

            Person newPerson = new Person();

            Console.WriteLine("enter your name");
            newPerson.name = Console.ReadLine();

            Console.WriteLine("enter your password");
            newPerson.password = Console.ReadLine();

            Role newRole = new();
            Console.WriteLine("enter your role: (admin/student");
            newRole.RoleTitle = Console.ReadLine();
            newPerson.Role.RoleTitle = newRole.RoleTitle;

            registerService.Register(newPerson);
            break;

    }
}