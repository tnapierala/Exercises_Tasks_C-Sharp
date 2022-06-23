using System;

namespace Lab3
{
    internal class Person
    {

        string FirstName = nameUpper;


        public string lastName { get; internal set; }


        internal void FillValues(string nameUpper, string lastNameUpper, int yearsOld, int phoneNumber)
        {
            throw new NotImplementedException();
        }

        internal void FillValues(string nameUpper, string lastNameUpper, int yearsOld)
        {
            throw new NotImplementedException();
        }

        internal void Write()
        {
            Console.WriteLine("\n\n Your Name is: {0}", program.nameUpper);
            Console.WriteLine("\n Your Last Name is: {0}", lastNameUpper);
            Console.WriteLine("\n Your Birth Year is: {0}", birthYear);
            Console.WriteLine(" \n Your Phone is: {0}", phoneNumber);
        }
    }
}