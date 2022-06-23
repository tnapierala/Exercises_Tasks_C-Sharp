/*
 * Utwórz aplikację, która pobiera od użytkownika dane osobowe uczniów takie jak: imię, nazwisko, numer
 * telefonu, datę urodzenia.
 * Aplikacja posiada menu kontekstowe, które umożliwia:
 * 1. Dodanie ucznia
 * 2. Usunięcie ucznia
 * 3. Wyświetlenie listy uczniów
 *  a. Sortując po nazwisku
 *  b. Sortując po imieniu
 *  c. Sortując po numerze telefonu
 * 4. Zakończenie działania aplikacji
 * W momencie kiedy pobierane są dane od użytkownika należy upewnić się, że są one prawidłowe pod
 * względem typu danych. Wykorzystaj do tego obsługę błędów i metody „TryParse”.
 * Dane o użytkownikach zapisuj w listach. 
 */



using System;
using System.Collections.Generic;
using System.Linq;

namespace zadanie2_Napierala
{
    class Program
    {
        public static string GetName()
        {
            var name = "";

            while (name.Length <= 2) {

                Console.Write("\n What's your name? \n Write: ");
                name = Console.ReadLine();
                int n;

                var isNumeric = int.TryParse(name, out n);

                if (isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That name: " + name + " is a number!");
                    name = "";
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                } else if (name.Length <= 2) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name is too short!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
            return name;
        }
        public static string GetLastName()
        {
            var lastName = "";

            while (lastName.Length <= 2) {

                Console.Write("\n What's your last name? \n Write: ");
                lastName = Console.ReadLine();
                int n;

                var isNumeric = int.TryParse(lastName, out n);

                if (isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name: " + lastName + " is a number!");
                    lastName = "";
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                } else if (lastName.Length <= 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name's too short!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
            return lastName;
        }
        public static int GetBirthYear() {
            
            var input = "";
            var birthYear = 0;
            const int minLength = 4; //minimum length of date

            while (input.Length < minLength) {

                Console.Write("\n How old are you (year)? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a number!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                } else if (input.Length < minLength) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That year is too short!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                } else {
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

                Console.Write("\n How's your number phone? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a phone number!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                } else if (input.Length < minLength) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That phone number's too short!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;

                } else {
                    phoneNumber = Convert.ToInt32(input);
                }
            }
            return phoneNumber;
        }
        public static void NowyUczen(){

            try {
                var firstName = GetName();
                var lastName = GetLastName();
                var phoneNumber = GetPhoneNumber();
                var birthYear = GetBirthYear(); // rok urodzenia
               
                var localDate = DateTime.Now; // data lokalna 
                var currentYear = localDate.Year; // data teraz 
                var yearsOld = currentYear - birthYear; // ile lat

                var person = new Person(); // lista

                person.FillValues(firstName, lastName, yearsOld.ToString(), birthYear.ToString(), phoneNumber.ToString());

                items.Add(person);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Uczen dodany.\n");
                Console.ForegroundColor = defaultColor;

            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There was issue with saving data. Please try again!");
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = defaultColor;
            }
        }
        public static void UsunUcznia() {

            var input = "";
            const int minLength = 0;
            var num = 0;

            while (input.Length <= minLength) {
                if (items.Count == 0) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n List is empty. I can't delete a person ");
                    Console.WriteLine("\n Try again, when you add a one person ");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;

                } else {
                    foreach (var item in items.OrderBy(by => by.FirstName)) {
                        Console.WriteLine(" \n\n ");
                        item.Write();
                        Console.WriteLine(" --- ");
                    }
                }

                Console.Write(" Ktorego ucznia chcesz usunac? (numer od 0 do ilosci) \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (isNumeric) {    
                    num = Convert.ToInt32(input);
                    items.RemoveAt(num);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Uczen usunięty \n");
                    Console.ForegroundColor = defaultColor;

                } else {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a number!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            }
        }

        static void Sortowanie() {

            Console.WriteLine(@"
Wybierz sposob sortowania:

    a. Po nazwisku
    b. Po imieniu
    c. Po numerze telefonu

Wybierz:  ");
            var x = 0;
            var person = new Person();
            //bool empty = true;

            do {
                var wybor = Console.ReadKey();
                
                if (wybor.Key == ConsoleKey.A) {

                    if (items.Count == 0) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;

                    } else { 
                        foreach (var item in items.OrderBy(by => by.LastName)) {
                            Console.WriteLine(" \n ");
                            item.Write();
                            Console.WriteLine(" --- ");
                            x = 2;
                        }
                    }
                } else if (wybor.Key == ConsoleKey.B) {

                    if (items.Count == 0) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;

                    } else {
                        foreach (var item in items.OrderBy(by => by.FirstName)) {
                            Console.WriteLine(" \n ");
                            item.Write();
                            Console.WriteLine(" --- ");
                            x = 2;
                        }
                    }
                } else if (wybor.Key == ConsoleKey.C) {

                    if (items.Count == 0) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;

                    } else {
                        foreach (var item in items.OrderBy(by => by.PhoneNumber)) {
                            Console.WriteLine(" \n ");
                            item.Write();
                            Console.WriteLine(" --- ");
                            x = 2;
                        }
                    }
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n Bledny wybor \n\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

            } while (x < 1);
        }


        static List<Person> items = new List<Person>();
        static ConsoleColor defaultColor = Console.ForegroundColor;

        static void Main() {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Witam! Program torzenia listy z danymi ");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            bool exit = false;

            do
            {   
                Console.WriteLine(@"
  Wybierz opcję:
    1. Dodaj ucznia
    2. Usun ucznia
    3. Sortowanie
    4. Zakończenie działania programu.

Wybierz:  " );
                var wybor = Console.ReadKey();

                if (wybor.Key == ConsoleKey.D1 || wybor.Key == ConsoleKey.NumPad1)
                {
                    Console.WriteLine(" \n ");
                    NowyUczen();
                }
                else if (wybor.Key == ConsoleKey.D2 || wybor.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine(" \n ");
                    UsunUcznia();
                }
                else if (wybor.Key == ConsoleKey.D3 || wybor.Key == ConsoleKey.NumPad3)
                {
                    Console.WriteLine(" \n ");
                    Sortowanie();
                }
                else if (wybor.Key == ConsoleKey.D4 || wybor.Key == ConsoleKey.NumPad4)
                {
                    exit = true;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" \n \n Wyłączyłeś porgram :) \n ");
                    Console.WriteLine(" Dowidzenia! \n Nacisnij klawisz..");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n Wystapil blad! Poodaj ponownie: \n\n");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }
            } while (!(exit));


            Console.ReadKey();
        }

    }
}
