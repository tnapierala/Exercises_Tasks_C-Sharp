using System;
using System.Collections.Generic;
using System.Text;

namespace zadanie4_Napierala.Consolei.Database
{
    public class Person
    {
        string firstName;
        string lastName;
        string phoneNumber;
        public int PersonId { get; protected set; }

        public string FirstName {
            get { return firstName; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect first name value.");
                }
                firstName = value;
            }
        }

        public string LastName {
            get  { return lastName; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect last name value.");
                }
                lastName = value;
            }
        }

        public string PhoneNumber {
            get { return phoneNumber; }
            set {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 9)
                {
                    throw new ArgumentException("Incorrect phone number.");
                }
                phoneNumber = value;
            }
        }

        public string years { get; set; }
        public string birthYear { get; set; }

        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"ID: {PersonId}");   
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"First name:    {firstName}");
            Console.WriteLine($"Last name:     {lastName}");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Phone number:  {phoneNumber}");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Years:         {years}");
            Console.WriteLine($"Birth Year:    {birthYear}");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public override string ToString()
        {
            return $"ID: {PersonId}, First name: {FirstName}, Last name: {LastName}";
        }
    }
}
