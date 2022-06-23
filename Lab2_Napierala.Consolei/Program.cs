using System;

namespace Lab2_Napierala.Consolei
{
    class Program
    {
        const int MIN_LENTH = 3;
        static void Main(string[] args)
        {
            string firstName;
            string lastName;
            string tel;
            string date;

            var defaultColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n Type your imie");
            firstName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Type your nazwisko");
            lastName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Type your telfon");
            tel = Console.ReadLine();

            Console.WriteLine("\n Type your date urodzenia");
            date = Console.ReadLine();      

            Console.ForegroundColor = defaultColor;


            Console.WriteLine("\n\nHello " + firstName + " " + lastName + "\n");
            Console.WriteLine(string.Concat("Hello ", firstName, " ", lastName, "\n"));
            Console.WriteLine("Hello {0} {1} {2}", firstName, lastName, "\n");
            Console.WriteLine($"Hello {firstName} {lastName} \n");

            Console.ReadKey();
        }
    }
}
