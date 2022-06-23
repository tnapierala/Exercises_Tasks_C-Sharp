using System;

namespace zadanie2_Napierala
{
    public class Person
    {
        string firstName;
        string lastName;
        string phoneNumber;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect first name value.");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Incorrect last name value.");
                }
                lastName = value;
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 9)
                {
                    throw new ArgumentException("Incorrect phone number.");
                }
                phoneNumber = value;
            }
        }

        public string years { get; private set; }
        public string birthYear { get; private set; }

        public void FillValues(string firstName, string lastName, string Years, string BirthYear, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            years = Years;
            birthYear = BirthYear;
            PhoneNumber = phoneNumber;
        }

       public void Write()
        {
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
    }
}