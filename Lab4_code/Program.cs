using System;
using System.Collections.Generic;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Animal>();


            //Dog dog = new Dog();
            //Cat cat = new Cat();
            list.Add(new Dog());
            list.Add(new Cat());
            //Animal animal = new Animal("");

            //Animal animal = dog;

            //dog.Sound();
            //cat.Sound();

            foreach (var item in list)
            {
                //if(item is Dog) 
                //{
                //    Console.WriteLine("Dog sound: ");
                //}
                //else 
                //{
                //    Console.WriteLine("Cat sound: ");                    
                //}

                item.Sound();
            }

            Console.ReadKey();

        }

        private void Show(Animal animal) 
        {
            animal.SomeAbstractMethod(2);
        }
    }
}
