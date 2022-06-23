
using System;

namespace zadanie3_Napierala.Consolei
{
    internal class Lectuer : Osoba {
        public Lectuer() : base(name: "Lectuer") {

        }
        public Lectuer(string name) : base(name) {
        }

        public string StudentsType { get; protected set; }

        public override void SomeAbstractMethod(int a)
        {
            Console.WriteLine(a*2);
        }
        public override void numer()
        {
            base.numer();
            Console.Write(" 1 \n ");
            //Console.Read();
            Console.Write(" \n ");
        }
    }
}


