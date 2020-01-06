using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task07
{
    class Program
    {
        static void Main(string[] args)
        {
            DateExistanceProgram();
            HTMLReplacerProgram();
            EmailFinderProgram();
            NumberValidatorProgram();
            TimeCounterProgram();
        }

        static void DateExistanceProgram()
        {
            Console.WriteLine("Date existance");
            Console.Write("Введите текст, содержащий дату в формате dd-mm-yyyy: ");
            string str = Console.ReadLine();
            Console.Write($"В тексте \"{str}\"");
            if (DateExistance(str))
            {
                Console.WriteLine($" содержится дата.");
            }
            else
            {
                Console.WriteLine(" не содержится дата.");
            }
        }

        static void HTMLReplacerProgram()
        {
            Console.WriteLine($"{Environment.NewLine}HTML replacer");
            Console.Write($"Введите текст: ");
            string str = Console.ReadLine();
            Console.WriteLine($"Результат замены: {HtmlReplacer(str)}");
        }

        static void EmailFinderProgram()
        {
            Console.WriteLine($"{Environment.NewLine}Email finder");
            Console.Write("Введите строку: ");
            string str = Console.ReadLine();
            string[] values = EmailFinder(str);
            if (values.Length > 0)
            {
                Console.WriteLine("Найденные адреса электронной почты:");
                foreach (var item in values)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Адреса не найдены");
            }
        }

        static void NumberValidatorProgram()
        {
            Console.WriteLine($"{Environment.NewLine}Numver validator");
            Console.Write("Введите число: ");
            string str = Console.ReadLine();
            NumberFormat nf = NumberValidator(str);
            switch (nf)
            {
                case NumberFormat.Simple:
                    Console.WriteLine("Это число в обычной нотации.");
                    break;
                case NumberFormat.Scientific:
                    Console.WriteLine("Это число в научной нотации.");
                    break;
                case NumberFormat.None:
                    Console.WriteLine("Это не число.");
                    break;
            }
        }

        static void TimeCounterProgram()
        {
            Console.WriteLine($"{Environment.NewLine}Time counter");
            Console.Write("Введите текст: ");
            string str = Console.ReadLine();
            Console.WriteLine($"Время в тексте присутствует {TimeCounter(str)} раз.");
        }

        static bool DateExistance(string value)
        {
            Regex regex =
                new Regex(
                    @"((((0[1-9]|1[0-9]|2[0-8])-02)|((0[1-9]|1[0-9]|2[0-9]|30)-(0[469]|11))|((0[1-9]|1[0-9]|2[0-9]|3[01])-(0[13578]|1[02])))-(\d{4}))|((29-02-([02468][48]|[13579][26]|[2468][048])00)|(29-02-\d\d([02468][48]|[13579][26]|[2468][048])))");
            bool isMatch = regex.IsMatch(value);
            return isMatch;
        }

        static string HtmlReplacer(string value)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(value);
            Regex regex = new Regex(@"<.*?>|<\/.*?>");
            MatchCollection m = regex.Matches(value);
            foreach (Match item in m)
            {
                while (stringBuilder.ToString().Contains(item.Value))
                {
                    stringBuilder = stringBuilder.Replace(item.Value, "_");
                }
            }

            return stringBuilder.ToString();
        }

        static string[] EmailFinder(string value)
        {
            Regex regex =
                new Regex(
                    @"((([\dA-z])+)([\dA-z\.\-_]*)([\dA-z]+))@(((([\dA-z])+)([\dA-z\-]*)([\dA-z]+)\.)*)[A-z]{2,6}");
            MatchCollection matchCollection = regex.Matches(value);
            string[] array = new string[matchCollection.Count];
            for (int i = 0; i < matchCollection.Count; i++)
            {
                array[i] = matchCollection[i].Value;
            }

            return array;
        }

        static int TimeCounter(string value)
        {
            Regex regex = new Regex(@"(\b[0-9]|0[0-9]|1[0-9]|2[0-4]):[0-5][0-9]");
            int count = regex.Matches(value).Count;
            return count;
        }

        static NumberFormat NumberValidator(string value)
        {
            Regex simple = new Regex(@"^(\-?\d+(\.\d+)?)$");
            Regex scientific = new Regex(@"^(\-?\d+(\.\d+)?)e\-?\d+$");
            if (scientific.IsMatch(value))
            {
                return NumberFormat.Scientific;
            }

            if (simple.IsMatch(value))
            {
                return NumberFormat.Simple;
            }

            return NumberFormat.None;
        }
    }
}
