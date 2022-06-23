using System;

namespace Lab3
{
    class AddressBookItem
    {
        string firstName;
        string lastName;
        string phoneNumber;
        // string address;
        // string city;

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

        public string Address { get; private set; }
        public string City { get; private set; }

        // public AddressBookItem(string firstName, string lastName,
        //     string address, string city)
        // {
        //     FirstName = firstName;
        //     this.lastName = lastName;
        //     Address = address;
        //     City = city;
        // }

        // public AddressBookItem(string firstName, string lastName,
        //     string address, string city, string phoneNumber)
        //     : this(firstName, lastName, address, city)

        // {
        //     // this.firstName = firstName;
        //     // this.lastName = lastName;
        //     // Address = address;
        //     // this.City = city;
        //     this.phoneNumber = phoneNumber;
        // }

        public void Write()
        {
            Console.WriteLine($"First name {firstName}");
            Console.WriteLine($"Last name {lastName}");
            Console.WriteLine($"Phone number {phoneNumber}");
        }

        public void FillValues(string firstName, string lastName,
            string address, string city)
        {
            FirstName = firstName;
            LastName = lastName;

            if (ValidateField(address))
            {
                Address = address;
            }
            else
            {
                throw new ArgumentException("Incorrect address.");
            }

            if (ValidateField(city))
            {
                City = city;
            }
            else
            {
                throw new ArgumentException("Incorrect city.");
            }
        }

        public void FillValues(string firstName, string lastName, string address,
            string city, string phoneNumber)
        {
            FillValues(firstName, lastName, address, city);
            PhoneNumber = phoneNumber;
        }

        private bool ValidateField(string value)
        {
            return
             !(string.IsNullOrWhiteSpace(value)
             || value.Length < 3);
        }


    }
}