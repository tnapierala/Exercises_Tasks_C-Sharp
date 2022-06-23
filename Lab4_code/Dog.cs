using System;

namespace Lab4
{
    internal class Dog : Animal
    {
        public Dog() : base(name: "Dog")
        {

        }
        public Dog(string name) : base(name)
        {
        }

        public string DogType { get; protected set; }

        public override void SomeAbstractMethod(int a)
        {
            Console.WriteLine(a);
        }

        public override void Sound()
        {
            base.Sound();
            Console.WriteLine("Wow wow");
        }
    }
}