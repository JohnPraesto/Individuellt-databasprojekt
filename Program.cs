using Individuellt_databasprojekt.Data;
using Individuellt_databasprojekt.Models;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.Identity.Client;
using System.Globalization;

namespace Individuellt_databasprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using SchoolDbContext db = new SchoolDbContext();
            int y = 2;

            while (y != 11)
            {
                Console.Clear();

                // Det måste finnas en meny där man kan välja att visa
                // olika data som efterfrågas av skolan. (Console)
                Console.WriteLine("Use arrow keys to navigate. Press Enter to make menu choice.\n");

                Console.WriteLine("     Employee: Register");   // Case 2
                Console.WriteLine("     Employee: Unregister"); // Case 3
                Console.WriteLine("     Employee: Edit");       // Case 4
                Console.WriteLine("     Employee: Show all");   // Case 5   
                Console.WriteLine("     Student: Register");    // Case 6
                Console.WriteLine("     Student: Unregister");  // Case 7
                Console.WriteLine("     Student: Edit");        // Case 8
                Console.WriteLine("     Student: Show all");    // Case 9
                Console.WriteLine("     Active courses");       // Case 10
                Console.WriteLine("     Exit");                 // Case 11

                // Hur många lärare jobbar på de olika avdelningarna? (EF i VS)
                Console.WriteLine("\nNumber of employees by department");
                Console.WriteLine("Principal      " + db.Employee.Where(e => e.Job == "Principal").Count());
                Console.WriteLine("Teacher        " + db.Employee.Where(e => e.Job == "Teacher").Count());
                Console.WriteLine("Administrator  " + db.Employee.Where(e => e.Job == "Administrator").Count());
                Console.WriteLine("Librarian      " + db.Employee.Where(e => e.Job == "Librarian ").Count());
                Console.WriteLine("Counselor      " + db.Employee.Where(e => e.Job == "Counselor").Count());
                Console.WriteLine("Janitor        " + db.Employee.Where(e => e.Job == "Janitor").Count());

                Console.SetCursorPosition(0, y);

                y = Navigation(2, 2, 11);

                Console.Clear();

                switch (y)
                {
                    case 2:
                        // Skapar en dummy-employee för att kunna skicka den till ManipulateDB()
                        Employee newEmp = new Employee() { FirstName = "x", LastName = "x", Job = "x", Hired = DateTime.Now, Salary = 0 };
                        
                        Console.WriteLine("---- REGISTER EMPLOYEE ----\n");
                        newEmp = ManipulateEmp(newEmp);

                        db.Employee.Add(newEmp);
                        db.SaveChanges();

                        Console.WriteLine($"\n{newEmp.FirstName} {newEmp.LastName} has been added to the database. Press Enter to continue.");
                        Console.ReadLine();

                        break;

                    case 3:
                        Console.WriteLine("---- UNREGISTER EMPLOYEE ----\n");
                        int id;
                        Console.Write("State id of employee to unregister: ");
                        while (!Int32.TryParse(Console.ReadLine(), out id)) ;

                        var unregEmp = db.Employee.FirstOrDefault(e => e.EmployeeId == id);

                        if (unregEmp != null)
                        {
                            string empFN = unregEmp.FirstName;
                            string empLN = unregEmp.LastName;

                            db.Employee.Remove(unregEmp);
                            db.SaveChanges();

                            Console.WriteLine($"\nEmployee with name {empFN} {empLN} has been unregistered");
                        }
                        else
                        {
                            Console.WriteLine("\nEmployee with the provided ID not found");
                        }
                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        
                        break;

                    case 4:
                        Console.WriteLine("---- EDIT EMPLOYEE ----\n");
                        Console.Write("State the ID of employee to edit: ");

                        while (!Int32.TryParse(Console.ReadLine(), out id)) ;

                        var editEmp = db.Employee.FirstOrDefault(e => e.EmployeeId == id);

                        if (editEmp != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Editing {editEmp.FirstName} {editEmp.LastName}\n");

                            editEmp = ManipulateEmp(editEmp);

                            db.SaveChanges();
                            Console.WriteLine($"\nEmployee with name id {id} has been edited.");
                        }
                        else
                        {
                            Console.WriteLine("\nEmployee with the provided ID not found.");
                        }

                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 5:
                        var employees = db.Employee;
                        Console.Clear();
                        Console.WriteLine("ID  First name  Last Name    Position     Salary     Hired\n");

                        foreach (Employee item in employees)
                        {
                            Console.Write($"{item.EmployeeId,-4}");
                            Console.Write($"{item.FirstName,-12}");
                            Console.Write($"{item.LastName,-13}");
                            Console.Write($"{item.Job,-13}");
                            Console.Write($"{item.Salary,-11}");
                            Console.WriteLine(item.Hired.ToString("yyyy-MM-dd"));
                            //Console.WriteLine(item.Leave);
                        }

                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 6:
                        // Skapar en dummy-student för att kunna skicka den till ManipulateDB()
                        Student newStu = new Student() { FirstName = "x", LastName = "x", PersonalNumber = "x", Class = "x" };

                        Console.WriteLine("---- REGISTER STUDENT ----\n");
                        newStu = ManipulateStu(newStu);

                        db.Student.Add(newStu);
                        db.SaveChanges();

                        Console.WriteLine($"\n{newStu.FirstName} {newStu.LastName} has been added to the database. \n\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 7:
                        Console.WriteLine("---- UNREGISTER STUDENT ----\n");
                        Console.Write("State id of student to unregister: ");
                        while (!Int32.TryParse(Console.ReadLine(), out id)) ;

                        var unregStu = db.Student.FirstOrDefault(s => s.StudentId == id);

                        if (unregStu != null)
                        {
                            string stuFN = unregStu.FirstName;
                            string stuLN = unregStu.LastName;

                            db.Student.Remove(unregStu);
                            db.SaveChanges();

                            Console.WriteLine($"\nStudent with name {stuFN} {stuLN} has been unregistered");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent with the provided ID not found");
                        }
                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 8: // Uppdatera/korrigera en elevs information via kod. (EF i VS)
                        Console.WriteLine("---- EDIT STUDENT ----\n");
                        Console.Write("State the ID of student to edit: ");

                        while (!Int32.TryParse(Console.ReadLine(), out id)) ;

                        var editStu = db.Student.FirstOrDefault(e => e.StudentId == id);

                        if (editStu != null)
                        {
                            Console.Clear();
                            Console.WriteLine($"Editing {editStu.FirstName} {editStu.LastName}\n");

                            editStu = ManipulateStu(editStu);

                            db.SaveChanges();
                            Console.WriteLine($"\nStudent with name id {id} has been edited.");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent with the provided ID not found.");
                        }

                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 9: // Visa information om alla elever (EF i VS)

                        var students = db.Student;
                        Console.Clear();
                        Console.WriteLine("ID  First name  Last Name    Class   Personal Number\n");

                        foreach (Student item in students)
                        {
                            Console.Write($"{item.StudentId,-4}");
                            Console.Write($"{item.FirstName,-12}");
                            Console.Write($"{item.LastName,-13}");
                            Console.Write($"{item.Class,-8}");
                            Console.WriteLine(item.PersonalNumber);
                        }

                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 10: // Visa en lista på alla aktiva kurser (EF i VS)

                        Console.Clear();
                        Console.WriteLine("Course name  Course end\n");

                        //var activeC = db.CourseStudentConnection.Where(c => c.CourseEnd > DateTime.Now);

                        var activeC = from c in db.CourseStudentConnection
                                      join course in db.Course on c.CourseId equals course.CourseId
                                      where c.CourseEnd > DateTime.Now
                                      select new { course.CourseName, c.CourseEnd };

                        foreach (var item in activeC)
                        {
                            Console.Write($"{item.CourseName,-13}");
                            Console.WriteLine(item.CourseEnd.ToString("yyyy-MM-dd"));
                        }
                        Console.WriteLine("\nPress Enter to continue.");
                        Console.ReadLine();
                        break;

                    case 11:
                        // Exit program
                        break;

                    default:
                        Console.WriteLine("You're not supposed to be here. This is the switch default.");
                        break;
                }
            }
        }

        public static int Navigation(int y, int topLimit, int botLimit)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("-->");
            Console.CursorVisible = false;
            ConsoleKeyInfo navigator;
            do
            {
                navigator = Console.ReadKey();
                Console.SetCursorPosition(0, y);
                Console.Write("   ");
                if (navigator.Key == ConsoleKey.UpArrow && y > topLimit)
                {
                    y--;
                }
                else if (navigator.Key == ConsoleKey.DownArrow && y < botLimit)
                {
                    y++;
                }
                Console.SetCursorPosition(0, y);
                Console.Write("-->");
                Console.ResetColor();
            } while (navigator.Key != ConsoleKey.Enter);
            Console.SetCursorPosition(0, botLimit+1);
            Console.CursorVisible = true;
            return y;
        }

        public static Employee ManipulateEmp(Employee editEmp)
        {
            Console.Write("First name: ");
            editEmp.FirstName = Console.ReadLine();

            Console.Write("Last name : ");
            editEmp.LastName = Console.ReadLine();

            Console.Write("Select position using the arrow keys.\n");
            Console.WriteLine("     Principal");
            Console.WriteLine("     Teacher");
            Console.WriteLine("     Administrator");
            Console.WriteLine("     Librarian");
            Console.WriteLine("     Counselor");
            Console.WriteLine("     Janitor");

            int selector = Navigation(5, 5, 10);
            string job;
            if (selector == 5)
                job = "Principal";
            else if (selector == 6)
                job = "Teacher";
            else if (selector == 7)
                job = "Administrator";
            else if (selector == 8)
                job = "Librarian";
            else if (selector == 9)
                job = "Counselor";
            else if (selector == 10)
                job = "Janitor";
            else
                job = "ERROR IN ASSIGNING POSITION";
            editEmp.Job = job;

            while (true)
            {
                Console.Write("Hired date: ");
                try
                {
                    editEmp.Hired = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("\nEnter only format YYYY-MM-DD.\n");
                }
            }
            int salary;
            Console.Write("Salary    : ");
            while (!Int32.TryParse(Console.ReadLine(), out salary)) ;
            editEmp.Salary = salary;

            return editEmp;
        }

        public static Student ManipulateStu(Student editStu)
        {
            Console.Write("First name: ");
            editStu.FirstName = Console.ReadLine();

            Console.Write("Last name : ");
            editStu.LastName = Console.ReadLine();

            Console.Write("Personal number: ");
            editStu.PersonalNumber = Console.ReadLine();

            Console.Write("Class: ");
            editStu.Class = Console.ReadLine();

            return editStu;
        }
    }
}

/*
Förslag till vidareutveckling:
göra metod av saker som är samma i både student och employee casen
göra klass till Manipulate?
*/