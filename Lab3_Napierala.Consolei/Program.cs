using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_Napierala.Consolei {
    class Program {
        static void Main(string[] args) {
            var defaultColor = Console.ForegroundColor;
            // var address1 = new AddressBookItem("Artur", "Ziemianski", "Nowowiejskiego 10", "Poznan");
            // var address2 = new AddressBookItem("Karol", "Ziemianski", "Nowowiejskiego 20", "Poznan", "0481233211");

            // address1.Write();
            // address2.Write();

            //var addressBookItem = new AddressBookItem();

            var items = new List<AddressBookItem>();

            // var arturs = items.Where(x => x.FirstName == "Artur");
            // var ziemianski = items.First(w => w.LastName == "Ziemianski");

            do {
                try {
                    Console.WriteLine("First name: ");
                    var firstName = Console.ReadLine();

                    Console.WriteLine("Last name: ");
                    var lastName = Console.ReadLine();

                    Console.WriteLine("Phone number: ");
                    var phoneNumber = Console.ReadLine();

                    Console.WriteLine("Address: ");
                    var address = Console.ReadLine();

                    Console.WriteLine("City: ");
                    var city = Console.ReadLine();

                    var addressBookItem = new AddressBookItem();

                    if (string.IsNullOrWhiteSpace(phoneNumber)) {
                        addressBookItem.FillValues(firstName, lastName, address, city);
                    } else {
                        addressBookItem.FillValues(firstName, lastName, address, city, phoneNumber);
                    }

                    items.Add(addressBookItem);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("User added to address book.");
                    Console.ForegroundColor = defaultColor;

                    Console.WriteLine("To exit press 'q'.");

                    if (Console.ReadLine() == "q") {
                        break;
                    }
                }
                catch (Exception ex) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There was issue with saving data. Please try again!");
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = defaultColor;
                }
            } while (true);

            foreach (var item in items.OrderBy(by => by.LastName)) {
                item.Write();
                Console.WriteLine(" --- ");
            }

            Console.ReadKey();
        }
    }
}

