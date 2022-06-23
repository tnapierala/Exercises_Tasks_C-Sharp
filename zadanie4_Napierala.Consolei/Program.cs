using zadanie4_Napierala.Consolei.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace zadanie4_Napierala.Consolei
{
class Program
    {

        public static string GetName()
        {
            var name = "";

            while (name.Length <= 2)
            {

                Console.Write("\n What's your name? \n Write: ");
                name = Console.ReadLine();
                int n;

                var isNumeric = int.TryParse(name, out n);

                if (isNumeric)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That name: " + name + " is a number!");
                    name = "";
                    Console.ResetColor();

                }
                else if (name.Length <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Name is too short!");
                    Console.ResetColor();
                }
            }
            return name;
        }
        public static string GetLastName()
        {
            var lastName = "";

            while (lastName.Length <= 2)
            {

                Console.Write("\n What's your last name? \n Write: ");
                lastName = Console.ReadLine();
                int n;

                var isNumeric = int.TryParse(lastName, out n);

                if (isNumeric)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name: " + lastName + " is a number!");
                    lastName = "";
                    Console.ResetColor();

                }
                else if (lastName.Length <= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That last name's too short!");
                    Console.ResetColor();
                }
            }
            return lastName;
        }
        public static int GetBirthYear()
        {

            var input = "";
            var birthYear = 0;
            const int minLength = 4; //minimum length of date

            while (input.Length < minLength)
            {

                Console.Write("\n How old are you (year)? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (!isNumeric)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a number!");
                    input = "";
                    Console.ResetColor();

                }
                else if (input.Length < minLength)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That year is too short!");
                    Console.ResetColor();
                }
                else
                {
                    birthYear = Convert.ToInt32(input);
                }
            }
            return birthYear;
        }
        public static int GetPhoneNumber()
        {

            var input = "";
            const int minLength = 9;
            var phoneNumber = 0;

            while (input.Length < minLength)
            {

                Console.Write("\n How's your number phone? \n Write: ");
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (!isNumeric)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That isn't a phone number!");
                    input = "";
                    Console.ResetColor();

                }
                else if (input.Length < minLength)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That phone number's too short!");
                    Console.ResetColor();

                }
                else
                {
                    phoneNumber = Convert.ToInt32(input);
                }
            }
            return phoneNumber;
        }
        public static void NowyUczen()
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            string connectionString = configuration.GetConnectionString("Db");

            var services = new ServiceCollection();
            services.AddDbContext<DbEntities>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var provider = services.BuildServiceProvider();

            var db = provider.GetService<DbEntities>();

            
                var firstName = GetName();
                var lastName = GetLastName();
                var phoneNumber = GetPhoneNumber();
                var birthYear = GetBirthYear(); // rok urodzenia

                var localDate = DateTime.Now; // data lokalna 
                var currentYear = localDate.Year; // data teraz 
                var yearsOld = currentYear - birthYear; // ile lat


                var person = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    years = yearsOld.ToString(),
                    birthYear = birthYear.ToString(),
                    PhoneNumber = phoneNumber.ToString()
                };

                db.People.Add(person);
                db.SaveChanges();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Uczen dodany.\n");
                Console.ResetColor();

        }
        public static void UsunUcznia() {
                   
                  IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();

                    string connectionString = configuration.GetConnectionString("Db");

                    var services = new ServiceCollection();
                    services.AddDbContext<DbEntities>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });

                    var provider = services.BuildServiceProvider();

                    var db = provider.GetService<DbEntities>();

                    var people = db.People.ToList();


                var input = "";
                const int minLength = 0;
                var toRemoveId = 0;
                
                
                
                while (input.Length <= minLength)
                {
                    if (people.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n List is empty. I can't delete a person ");
                        Console.WriteLine("\n Try again, when you add a one person ");
                        Console.ResetColor();
                        break;

                    }
                    else
                    {
                        Console.WriteLine(" \n Lista uczniów w bazie: ");
                        foreach (var item in people.OrderBy(by => by.PersonId))
                        {
                            Console.WriteLine(" \n\n ");
                            item.Write();
                            Console.WriteLine(" --- ");
                        }
                    }

                    Console.Write(" \n\n ");
                    Console.Write(" Ktorego ucznia chcesz usunac? [ID] \n Write: ");
                    input = Console.ReadLine();
                    int n;
                    var isNumeric = int.TryParse(input, out n);

                    if (isNumeric)
                    {
                        toRemoveId = Convert.ToInt32(input);
                        var personToRemove = db.People.FirstOrDefault(w => w.PersonId == toRemoveId);

                        if (personToRemove != null)
                        {
                            db.Remove(personToRemove);
                            db.SaveChanges();
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n Uczen usunięty \n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n That isn't a number! \n");
                        input = "";
                        Console.ResetColor();
                    }
                }
            }
        static void Sortowanie() {
                        
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("Db");

                var services = new ServiceCollection();
                services.AddDbContext<DbEntities>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

                var provider = services.BuildServiceProvider();

                var db = provider.GetService<DbEntities>();

                var people = db.People.ToList();

                Console.WriteLine(@"
Wybierz sposob sortowania:

    a. Po nazwisku
    b. Po imieniu
    c. Po numerze telefonu
");

                Console.Write(" Wybierz: ");
                
                var x = 0;

                do
                {
                    var wybor = Console.ReadKey();

                    if (wybor.Key == ConsoleKey.A)
                    {

                        if (people.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n List is empty ");
                            Console.WriteLine("\n You must add someone to list ");
                            Console.ResetColor();
                            break;

                        }
                        else
                        {
                            foreach (var item in people.OrderBy(by => by.LastName))
                            {
                                Console.WriteLine(" \n ");
                                item.Write();
                                Console.WriteLine(" --- ");
                                x = 2;
                            }
                        }
                    }
                    else if (wybor.Key == ConsoleKey.B)
                    {

                        if (people.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n List is empty ");
                            Console.WriteLine("\n You must add someone to list ");
                            Console.ResetColor();
                            break;

                        }
                        else
                        {
                            foreach (var item in people.OrderBy(by => by.FirstName))
                            {
                                Console.WriteLine(" \n ");
                                item.Write();
                                Console.WriteLine(" --- ");
                                x = 2;
                            }
                        }
                    }
                    else if (wybor.Key == ConsoleKey.C)
                    {
                        if (people.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n List is empty ");
                            Console.WriteLine("\n You must add someone to list ");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            foreach (var item in people.OrderBy(by => by.PhoneNumber))
                            {
                                Console.WriteLine(" \n ");
                                item.Write();
                                Console.WriteLine(" --- ");
                                x = 2;
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n Bledny wybor \n\n");
                        Console.ResetColor();
                    }

                } while (x < 1);
            }
        static void Wyszukaj()
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Db");

            var services = new ServiceCollection();
            services.AddDbContext<DbEntities>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var provider = services.BuildServiceProvider();

            var db = provider.GetService<DbEntities>();

            var people = db.People.ToList();

            Console.WriteLine(@"
Wybierz sposob wyszukania:

    a. Po nazwisku
    b. Po imieniu
    c. Po numerze telefonu
");

            Console.Write(" Wybierz: ");

            var x = 0;
            var person = new Person();



            do
            {
                var wybor = Console.ReadKey();

                if (wybor.Key == ConsoleKey.A)
                {
                    if (people.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ResetColor();
                        break;

                    }
                    else
                    {
                        Console.Write("\n\n Wpisz nazwisko po ktorym chcesz wyszukac: ");
                        var pattern = Console.ReadLine().ToLower();
                        var searchResults = people.Where(w =>
                                 w.LastName.ToLower().Contains(pattern)
                                 || w.FirstName.ToLower().Contains(pattern)
                                 || w.PhoneNumber.ToLower().Contains(pattern)
                                 || w.years.ToLower().Contains(pattern)
                                 || w.birthYear.ToLower().Contains(pattern)
                                 ).ToList();

                        Console.WriteLine("\n Search results: ");
                        searchResults.ForEach(i => Console.WriteLine(i.ToString()));
                        Console.WriteLine("\n ");
                        x = 2;
                    }
                }
                else if (wybor.Key == ConsoleKey.B)
                {
                    if (people.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.Write("\n\n Wpisz imie po ktorym chcesz wyszukac: ");
                        var pattern = Console.ReadLine().ToLower();
                        var searchResults = people.Where(w =>
                                w.FirstName.ToLower().Contains(pattern)
                                || w.LastName.ToLower().Contains(pattern)
                                || w.PhoneNumber.ToLower().Contains(pattern)
                                || w.years.ToLower().Contains(pattern)
                                || w.birthYear.ToLower().Contains(pattern)
                                ).ToList();

                        Console.WriteLine("\n Search results: ");
                        searchResults.ForEach(i => Console.WriteLine(i.ToString()));
                        Console.WriteLine("\n ");
                        x = 2;
                    }
                }
                else if (wybor.Key == ConsoleKey.C)
                {
                    if (people.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n List is empty ");
                        Console.WriteLine("\n You must add someone to list ");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.Write("\n\n Wpisz nr. tel. : ");
                        var pattern = Console.ReadLine().ToLower();
                        var searchResults = people.Where(w =>
                                w.PhoneNumber.ToLower().Contains(pattern)
                                || w.FirstName.ToLower().Contains(pattern)
                                || w.LastName.ToLower().Contains(pattern)
                                || w.years.ToLower().Contains(pattern)
                                || w.birthYear.ToLower().Contains(pattern)
                                ).ToList();

                        Console.WriteLine("\n Search results: ");
                        searchResults.ForEach(i => Console.WriteLine(i.ToString()));
                        Console.WriteLine("\n ");
                        x = 2;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n Bledny wybor \n\n");
                    Console.ResetColor();
                }
            } while (x < 1);
        }

static void Main()
            {

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n Witam! Program torzenia listy z danymi ");
                Console.ResetColor();

                bool exit = false;

                do
                {
                    Console.WriteLine(@"
  Wybierz opcję:
    1. Dodaj ucznia
    2. Usun ucznia
    3. Sortowanie
    4. Wyszukaj
    5. Zakończenie działania programu.
");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Wybierz: ");
                Console.ResetColor();

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
                        Console.WriteLine(" \n ");
                        Wyszukaj();
                    }
                    else if (wybor.Key == ConsoleKey.D5 || wybor.Key == ConsoleKey.NumPad4)
                    {
                        exit = true;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" \n \n Wyłączyłeś porgram :) \n ");
                        Console.WriteLine(" Dowidzenia! \n Nacisnij klawisz..");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n Wystapil blad! Poodaj ponownie: \n\n");
                        Console.ResetColor();
                    }
                } while (!(exit));


                Console.ReadKey();
            }

        }
           
    }

