using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("2.1 Round");
            Round2_1();
            Console.WriteLine("\n\r2.2 Triangle");
            Triangle2_2();
            Console.WriteLine("\n\r2.3 User");
            User2_3();
            Console.WriteLine("\n\r2.4 MyString");
            MyString2_4();
            Console.WriteLine("\n\r2.5 Employee");
            Employee2_5();
            Console.WriteLine("\n\r2.6 Ring");
            Ring2_6();
            Console.ReadLine();
        }

        static void Round2_1()
        {
            Console.WriteLine("Создаем круг сос сторонами 3, 5, 6");
            Round round = new Round(3, 5, 6);
            Console.WriteLine("Площадь круга: " + round.Area);
            Console.WriteLine("Длина круга: " + round.Length);
            round.X = 1.2;
            round.Y = 2.2;
            Console.WriteLine("Пытаемся присвоить радиусу неверное значение: -10");
            round.Radius = -10;//заведомо неправильное значение
            Console.WriteLine("Выводим значение радиуса: "+round.Radius+ " (сработала проверка и подставила свое верное значение)");
            Console.WriteLine("Площадь круга: " + round.Area);
            Console.WriteLine("Длина круга: " + round.Length);
        }


        static void Triangle2_2()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine("Площадь треугольника: " + triangle.Area);
            Console.WriteLine("Периметр треугольника: " + triangle.Perimeter);
            int i = -9;
            Console.WriteLine("Пытаемся ввести неправильное значение стороны А: "+i);
            triangle.A = -9;
            Console.WriteLine("Выводим значение А после попытки ввода неправильного значения: "+triangle.A+" (сработала проверка и подставила свое верное значение)");
            Console.WriteLine("Новая площадь треугольника: " + triangle.Area);
            Console.WriteLine("Новый периметр треугольника: " + triangle.Perimeter);
        }

        static void User2_3()
        {
            User user = new User("Dmitriy", "Chukarin", "Vladimirovich", new DateTime(1997, 4, 6));
            Console.WriteLine("Возраст пользователя " + user.LastName + " " + user.Name + " " + user.Surname + ": " + user.Age);
        }

        static void MyString2_4()
        {
            MyString myString1 = new MyString("Hello, ");
            MyString myString2 = new MyString("world");
            MyString myString3 = new MyString("world");
            MyString myString4 = new MyString("brave");
            Console.WriteLine("Сравнение \""+myString2+"\" и \""+myString3+"\": "+ myString2.Equals(myString3));
            Console.Write("Cancat: \""+myString1+"\" и \""+myString2+"\":");
            MyString a = MyString.Cancat(myString1, myString2);
            Console.WriteLine(a);
            Console.Write("Cancat через оператор: ");
            Console.WriteLine(myString1 + myString4 + " " + myString2);

        }

        static void Employee2_5()
        {
            Employee employee = new Employee("Dmitriy", "Chukarin", "Vladimirovich", new DateTime(1997, 4, 6), 1.5f, "Hololens developer");
            Console.WriteLine("Сотрудник " + employee.Name + ", возраст: " + employee.Age + ", опыт работы: " + employee.Position + ", стаж: " + employee.Experience);

            employee = new Employee("Ivan", "Ivanov", "Ivanovich", new DateTime(1999, 1, 1), -1.5f, "Programmer");//заведомо неправильные данные опыта
            Console.WriteLine("Сотрудник " + employee.Name + ", возраст: " + employee.Age + ", опыт работы: " + employee.Position + ", стаж: " + employee.Experience);
        }

        static void Ring2_6()
        {
            Ring ring = new Ring(1.1d, 1.3d, 1.1d, 3.9d);
            Console.WriteLine("Внешний радиус: " + ring.OuterRadius);
            Console.WriteLine("Внутренний радиус: " + ring.InnerRadius);
            Console.WriteLine("Длина: " + ring.Length);
            Console.WriteLine("Площадь: " + ring.Area);
            Console.WriteLine("Теперь изменяем значение радиуса на неправильное");
            ring.OuterRadius = -9.6;//заведомо неправильные данные внешнего радиуса
            Console.WriteLine("Внешний радиус: " + ring.OuterRadius);
            Console.WriteLine("Внутренний радиус: " + ring.InnerRadius+ " (сработала проверка и подставила свое верное значение)");
            Console.WriteLine("Площадь: " + ring.Area);
            Console.WriteLine("Длина: " + ring.Length);
        }
    }
}
