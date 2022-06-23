using System;

namespace Lab4
{
    abstract class Animal
    {
        public string Name { get; protected set; }
        public string Color { get; protected set; }
        public double Size { get; protected set; }
        public double Weight { get; protected set; }

        public Animal(string name)
        {
            Name = name;
        }

        public abstract void SomeAbstractMethod(int a);

        public virtual void Sound() 
        {
            Console.WriteLine($"{Name} sound:");
        }
    }
}