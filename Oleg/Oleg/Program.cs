using Diplom.Services;
using Oleg.Entities;
using Oleg.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oleg
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationContext();

            var studentService = new StudentService(context);
            var teacherService = new TeacherService(context);
            var themeService = new ThemeService(context);

            //var theme = new Theme
            //{
            //    Title = "PIZDA"
            //};

            //var teacher = new Teacher
            //{
            //    Name = "Dima",
            //    Surname = "Efremov",
            //};

            //var student1 = studentService.Add(new Student
            //{
            //    Name = "Oleg",
            //    Surname = "Lebedev"
            //});

            //studentService.AssignToTheme(student1, theme);
            //studentService.AssignToTeacher(student1, teacher);

            var studs = studentService.GetAll();
            var t = teacherService.GetAll();
            var themes = themeService.GetAll();

            //studentService.AssignToTeacher(studs[1], t[0]);

            Seed(studs, "Student");
            Console.WriteLine();
            Console.WriteLine();
            Seed(t, "Teacher");
            Console.WriteLine();
            Console.WriteLine();
            Seed(themes, "Theme");

            Console.WriteLine();

            InitMenu(studentService, teacherService, themeService);
        }

        static void InitMenu(StudentService studentService, TeacherService teacherService, ThemeService themeService)
        {
            for (;;)
            {
                Console.WriteLine("Выберите действие:");

                Console.WriteLine("1: Над студентом");
                Console.WriteLine("2: Над преподавателем");
                Console.WriteLine("3: Над темой");
                Console.WriteLine("4: Выйти");

                var action = int.Parse(Console.ReadLine());

                if (action == 4)
                {
                    return;
                }

                switch (action)
                {
                    case 1:
                        Console.WriteLine("1: Добавить студента:");
                        Console.WriteLine("2: Удалить студента:");
                        Console.WriteLine("3: Присвоить преподавателя:");
                        Console.WriteLine("4: Присвоить тему:");
                        Console.WriteLine("5: Выйти:");

                        var studentAction = int.Parse(Console.ReadLine());

                        if (studentAction == 5)
                        {
                            break;
                        }

                        switch (studentAction)
                        {
                            case 1:
                                Console.WriteLine("Фамилия: ");
                                var surname = Console.ReadLine();

                                Console.WriteLine("Имя: ");
                                var name = Console.ReadLine();

                                var student = new Student
                                {
                                    Name = name,
                                    Surname = surname,
                                };

                                studentService.Add(student);

                                Seed(studentService.GetAll(), "Student");

                                Console.WriteLine();

                                break;

                            case 2:
                                Console.WriteLine("Выберите номер студента для удаления:");
                                var idToDelete = int.Parse(Console.ReadLine());

                                var studentToDelete = studentService.GetById(idToDelete);

                                studentService.Delete(studentToDelete);

                                Seed(studentService.GetAll(), "Student");

                                Console.WriteLine();
                                break;

                            case 3:
                                Console.WriteLine("Выберите номер преподавателя для присвоения:");
                                var teacherId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Выберите номер студента для присвоения:");
                                var studentId = int.Parse(Console.ReadLine());

                                var currentStudent = studentService.GetById(studentId);

                                var assignRes = studentService.AssignToTeacher(currentStudent, teacherService.GetById(teacherId));

                                if (assignRes == null)
                                {
                                    Console.WriteLine("Вы некорректно ввели данные!");
                                    Console.WriteLine();
                                    break;
                                }

                                Seed(studentService.GetAll(), "Student");
                                Seed(teacherService.GetAll(), "Teacher");

                                break;

                            case 4:
                                Console.WriteLine("Выберите номер темы для присвоения:");
                                var themeId = int.Parse(Console.ReadLine());

                                Console.WriteLine("Выберите номер студента для присвоения:");
                                var studentId2 = int.Parse(Console.ReadLine());

                                var currentStudent2 = studentService.GetById(studentId2);

                                var res = studentService.AssignToTheme(currentStudent2, themeService.GetById(themeId));

                                if (res == null)
                                {
                                    Console.WriteLine("Вы некорректно ввели данные!");
                                    Console.WriteLine();
                                    break;
                                }

                                Seed(studentService.GetAll(), "Student");
                                Seed(themeService.GetAll(), "Theme");

                                break;

                            default:
                                Console.WriteLine();
                                break;
                        }


                        break;

                    case 2:
                        Console.WriteLine("1: Добавить преподавателя:");
                        Console.WriteLine("2: Удалить преподавателя:");
                        Console.WriteLine("3: Выйти:");

                        var teacherAction = int.Parse(Console.ReadLine());

                        if (teacherAction == 3)
                        {
                            break;
                        }

                        switch (teacherAction)
                        {
                            case 1:
                                Console.WriteLine("Фамилия: ");
                                var surname = Console.ReadLine();

                                Console.WriteLine("Имя: ");
                                var name = Console.ReadLine();

                                var teacher = new Teacher
                                {
                                    Name = name,
                                    Surname = surname,
                                };

                                teacherService.Add(teacher);

                                Seed(teacherService.GetAll(), "Teacher");

                                Console.WriteLine();

                                break;
                            case 2:
                                Console.WriteLine("Выберите номер преподавателя для удаления:");
                                var idToDelete = int.Parse(Console.ReadLine());

                                var teacherToDelete = teacherService.GetById(idToDelete);

                                teacherService.Delete(teacherToDelete);

                                Seed(teacherService.GetAll(), "Teacher");

                                Console.WriteLine();
                                break;

                            default:
                                break;
                        }

                        break;

                    case 3:
                        Console.WriteLine("1: Добавить тему:");
                        Console.WriteLine("2: Удалить тему:");
                        Console.WriteLine("3: Выйти:");

                        var themeAction = int.Parse(Console.ReadLine());

                        if (themeAction == 3)
                        {
                            break;
                        }

                        switch (themeAction)
                        {
                            case 1:
                                Console.WriteLine("Название: ");
                                var title = Console.ReadLine();

                                var theme = new Theme
                                {
                                    Title = title
                                };

                                var addedTheme = themeService.Add(theme);

                                if (addedTheme == null)
                                {
                                    Console.WriteLine("Вы некорректно ввели данные!");
                                    Console.WriteLine();
                                    break;
                                }

                                Seed(themeService.GetAll(), "Theme");

                                Console.WriteLine();

                                break;
                            case 2:
                                Console.WriteLine("Выберите номер темы для удаления:");
                                var idToDelete = int.Parse(Console.ReadLine());

                                var themeToDelete = themeService.GetById(idToDelete);

                                if (themeToDelete == null)
                                {
                                    Console.WriteLine("Вы некорректно ввели данные!");
                                    Console.WriteLine();
                                    break;
                                }

                                themeService.Delete(themeToDelete);

                                Seed(themeService.GetAll(), "Theme");

                                Console.WriteLine();
                                break;

                            default:
                                break;
                        }

                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
        }

        static void Seed<T>(List<T> entities, string type) where T : class
        {
            LayoutDrawing.PrintLine();

            switch (type)
            {
                case "Student":
                    LayoutDrawing.PrintRow("Студенты");
                    LayoutDrawing.PrintLine();
                    LayoutDrawing.PrintRow("Номер", "Фамилия", "Имя", "Тема", "Преподаватель");
                    LayoutDrawing.PrintLine();

                    foreach (var item in (entities as List<Student>))
                    {
                        LayoutDrawing.PrintRow(
                                item.Id.ToString(),
                                item.Surname.ToString(),
                                item.Name.ToString(),
                                item.Theme == null ? "Нету" : item.Theme.Title.ToString(),
                                item.Teacher == null ? "Нету" : $"{item.Teacher.Surname} {item.Teacher.Name}");
                    }

                    LayoutDrawing.PrintLine();

                    break;

                case "Teacher":
                    LayoutDrawing.PrintRow("Преподаватели");
                    LayoutDrawing.PrintLine();
                    LayoutDrawing.PrintRow("Номер", "Фамилия", "Имя", "Студенты");
                    LayoutDrawing.PrintLine();

                    foreach (var teacher in entities as List<Teacher>)
                    {
                        var str = new StringBuilder();
                        foreach (var student in teacher.Students)
                        {
                            str.Append($"   {student.Surname} {student.Name}\n\t\t\t\t\t\t\t\t   ");
                        }

                        LayoutDrawing.PrintRow(
                                teacher.Id.ToString(),
                                teacher.Surname.ToString(),
                                teacher.Name.ToString(),
                                str.Length == 0 ? "Нету" : str.ToString());
                    }

                    break;

                case "Theme":
                    LayoutDrawing.PrintRow("Темы");
                    LayoutDrawing.PrintLine();
                    LayoutDrawing.PrintRow("Номер", "Название", "Студент");
                    LayoutDrawing.PrintLine();

                    foreach (var item in (entities as List<Theme>))
                    {
                        LayoutDrawing.PrintRow(
                                item.Id.ToString(),
                                item.Title.ToString(),
                                item.Student == null ? "Нету" : $"{item.Student.Surname} {item.Student.Name}");
                    }

                    LayoutDrawing.PrintLine();
                    break;

                default:
                    break;
            }
        }
    }
}
