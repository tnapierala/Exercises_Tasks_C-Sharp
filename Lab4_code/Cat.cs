using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    internal class Cat : Animal
    {
        public Cat() : base(name: "Cat")
        {

        }
        public Cat(string name) : base(name)
        {
        }

        public override void SomeAbstractMethod(int a)
        {
            Console.WriteLine(a * 2);
        }

        public override void Sound()
        {
            base.Sound();
            Console.WriteLine("Miau miau");
        }
    }
}
