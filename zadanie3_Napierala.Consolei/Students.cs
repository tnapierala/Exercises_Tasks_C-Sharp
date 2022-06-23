
using System;

namespace zadanie3_Napierala.Consolei
{
    internal class Students : Osoba {
        public Students() : base(name: " Student") {

        }
        public Students(string name) : base(name) {
        }

        public string StudentsType { get; protected set; }

        public override void SomeAbstractMethod(int a)
        {
            Console.WriteLine(a);
        }
        public override void numer()
        {
            base.numer();
            Console.Write(" 24482 \n ");
            //Console.Read();
            //Console.Write(" \n ");
        }
    }
}