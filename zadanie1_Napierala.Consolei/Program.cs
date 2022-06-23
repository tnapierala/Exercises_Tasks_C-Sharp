using System;
 
namespace Zadanie1 {
    internal class Program {
        public static string GetName() {
            var name = "";
 
            while (name.Length <= 3) {
                Console.WriteLine("\n What's your name? \n Write: ");
                name = Console.ReadLine();
                int n;
 
                var isNumeric = int.TryParse(name, out n);
 
                if (isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That name: " + name + " is a number!");
                    name = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (name.Length <= 3) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name is too short!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
 
            return name;
        }
        public static string GetLastName() {
            var lastName = "";
 
            while (lastName.Length <= 1) {

                Console.WriteLine("\n What's your last name? \n Write: ");
                lastName = Console.ReadLine();
                int n;
 
                var isNumeric = int.TryParse(lastName, out n);
 
                if (isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name: " + lastName + " is a number!");
                    lastName = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (lastName.Length <= 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name's too short!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
 
            return lastName;
        }
        public static int GetBirthYear() {
            var input = "";
            var birthYear = 0;
            const int minLength = 4; //minimum length of date
 
            while (input.Length < minLength) {
                
                Console.WriteLine("\n How old are you? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);
 
                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a number!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Length < minLength) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That year is too short!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else {
                    birthYear = Convert.ToInt32(input);
                }
            }
 
            return birthYear;
        }
        public static int GetPhoneNumber() {
            var input = "";
            const int minLength = 9;
            var phoneNumber = 0;
 
            while (input.Length < minLength) {
                
                Console.WriteLine("\n How's your number phone? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);
 
                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a phone number!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (input.Length < minLength) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That phone number's too short!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else {
                    phoneNumber = Convert.ToInt32(input);
                }
            }
 
            return phoneNumber;
        }
        private static void Main(string[] args)
        {   
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n Laborki 1 - Zadanie 1: ");
            Console.ForegroundColor = ConsoleColor.White;

            // Dane
            var name = GetName();
            var lastName = GetLastName();
            var birthYear = GetBirthYear();
            var phoneNumber = GetPhoneNumber();
            var localDate = DateTime.Now; // data lokalna 
            var currentYear = localDate.Year; // data teraz 
            var yearsOld = currentYear - birthYear; //data urodzenia 
            var nameUpper = char.ToUpper(name[0]) + name.Substring(1);
            var lastNameUpper = char.ToUpper(lastName[0]) + lastName.Substring(1);
 
            // Wypisywnie danych
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n Your Name is: {0}", nameUpper);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n Your Last Name is: {0}", lastNameUpper);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n Your Birth Year is: {0}", birthYear);

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" \n Your Phone is: {0}", phoneNumber);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n\n ***     Hello {0} {1}. You are {2} years old     ***\n\n", nameUpper, lastNameUpper, yearsOld);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" Press any key to continue.. ;) \nxcd");
            Console.ReadKey();
        }
    }
}