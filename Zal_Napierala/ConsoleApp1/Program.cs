using System;

namespace Zal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Helloooo! \n It's meeee \n Tomeeek \n\n hehehehhe XD \n");
            
            bool exit = false;
            do{
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@" MENU:
  1. Rozkład na czynniki
  2. Wartosc Eulera 
  3. Odwrotnosc modulo - Euklides
  Wpiscnij ESC, jelsi chcesz wyjsc z programu :/
");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("  Wybierz: ");
                var wyb = Console.ReadKey();

                if (wyb.Key == ConsoleKey.D1 || wyb.Key == ConsoleKey.NumPad1) {
                    Console.WriteLine("\n");
                    czynniki();
                } else if (wyb.Key == ConsoleKey.D2 || wyb.Key == ConsoleKey.NumPad2) {
                    Console.WriteLine("\n");
                    Euler();
                } else if (wyb.Key == ConsoleKey.D3 || wyb.Key == ConsoleKey.NumPad3) {
                    Console.WriteLine("\n");
                    Eukli();
                } else if (wyb.Key == ConsoleKey.Escape) {
                    exit = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" WWyszedles z proramu!!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Bledny wybor!!! \n Wpisz ponownie!!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (!exit);
        }
        private static int czynniki()
        {
            var input = "";
            var x = 0;

            while (x < 1) {
                Console.WriteLine("\n Podaj liczbe, ktroej zobaczyc chcesz czynniki pierwsze ");
                Console.Write(" Podaj liczbe: ");
                
                input = Console.ReadLine();
                int n;
                var isNumeric = int.TryParse(input, out n);

                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("To nie jest liczba!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.Gray;
                } 
                else if ( n <= 1) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ta liczba jest za mała lub nie ma czynników pierwszych!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.Gray;
                } else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    int m = 0;
                    int k = 2;

                    while (n > 0) {
                        if (n >= k) {
                            while (n % k == 0) {
                                Console.Write("  " + n + " / " + k + "\n"); //wypisanie watości i czynników
                                n /= k;
                            }
                            ++k;
                        } else {
                            m = n % k;
                            Console.Write("  " + m + " / \n "); // wypisanie tej 1 na końcu xD (tak się bawiłem tylko) nie musisz tego dawac
                            break;
                        }
                    }
                    
                    Console.ForegroundColor = ConsoleColor.Gray;
                                        
                    Console.WriteLine(" \n Czy chcesz kontynuowac? ");
                    Console.WriteLine(" Jesli 'TAK' to klinij Y, jesli 'NIE' to kliknij N ");
                    int a = 0;
                    
                    do {
                        Console.Write("  Wpisz: ");
                        var wybor = Console.ReadKey();

                        if (wybor.Key == ConsoleKey.N) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n Wyszedłeś :( ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            x = 2;
                            a = 2;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        } else if (wybor.Key == ConsoleKey.Y) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n To zaczynamy od poczatku :) ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            x = 0;
                            a = 2;
                            Console.WriteLine("\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Bledny wybor \n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    } while (a < 1);
                }
            } return x;
        }
        private static int Euler() 
        {
            var input = "";
            bool exit = false;
            long p = 0;

            do {
                Console.WriteLine("\n Podaj liczbe, ktorej chcesz wyswietlic wartosc f. Eulera ");
                Console.Write(" Podaj liczbe: ");

                input = Console.ReadLine();
                long n;
                var isNumeric = long.TryParse(input, out n);

                if (!isNumeric) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("To nie jest liczba!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (n <= 1 || n > 9999999) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ta liczba jest za mała lub za duża!");
                    input = "";
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;

                    long NWD(long a, long b)
                    {
                        while (a != b) {
                            if (a > b) {
                                a -= b;
                            } else {
                                b -= a;
                            }
                        } return a;
                    }

                    long fEuler(long n) {
                        int pom = 0;
                        for (int i = 1; i < n; i++) {
                            if (NWD(i, n) == 1) { 
                                pom++;
                            }
                        } return pom;
                    }
                    p = fEuler(n);
                    Console.WriteLine("Liczba Eulera to: {0} \n", p);

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" \n Czy chcesz ponownie? ");
                    Console.WriteLine(" Jesli 'TAK' to klinij Y, jesli 'NIE' to kliknij N ");
                     int a = 0;

                    do {
                        Console.Write("  Wpisz: ");
                        var wybor = Console.ReadKey();

                        if (wybor.Key == ConsoleKey.N) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n Wyszedłeś :( ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            exit = true;
                            a = 2;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (wybor.Key == ConsoleKey.Y) {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n To zaczynamy od poczatku :) ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            a = 2;
                            Console.WriteLine("\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        } else {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Bledny wybor \n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                   } while (a < 1);
                }
                
            } while (!exit);

            return 0;
        }

        // 5. wylicza i prezentuje kolejne kroki znalezienia odwrotności modulo wprowadzonych liczb rozszerzonym algorytmem Euklidesa;

        private static int Eukli()
        {
            var input = "";
            var input1 = "";
            bool exit = false;
            bool exit1 = false;
            bool exit2 = false;
            int euklides = 0;
            //long p = 0;

            do
            {
                Console.WriteLine("\n Podaj liczbe, ktorej chcesz wyswietlic wartosc odwrotna modulo ");

                int a, b;
/*                
                Console.Write(" Podaj liczbe A: ");
                input = Console.ReadLine();
                var isNumeric = int.TryParse(input, out a);*/

                do
                {
                    Console.Write("\n  Podaj liczbe A: ");
                    input = Console.ReadLine();
                    var isNumeric = int.TryParse(input, out a);

                    if (!isNumeric)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" \nPodana liczba A nie jest liczba!");
                        input = "";
                        Console.ForegroundColor = ConsoleColor.Gray;

                    }
                    else if (a <= 1 || a > 100000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" \nLiczba A jest za mała lub za duża!");
                        input = "";
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        exit1 = true;
                    }

                } while (!exit1);


                do {
                    Console.Write("\n  Podaj liczbe B: ");
                    input1 = Console.ReadLine();
                    var isNumeric1 = int.TryParse(input1, out b);

                    if (!isNumeric1) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" \nPodana liczba B nie jest liczba!");
                        input = "";
                        Console.ForegroundColor = ConsoleColor.Gray;

                    } else if (b <= 1 || b > 100000) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" \nLiczba B jest za mała lub za duża!");
                        input = "";
                        Console.ForegroundColor = ConsoleColor.Gray;
                    } else {
                        euklides = 1;
                        exit2 = true;
                    } 
                } while (!exit2);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\n  Liczba A to: {0}. Liczba B to: {1}. \n", a, b);
                Console.ForegroundColor = ConsoleColor.Gray;

                if (euklides == 1) {
                    int u, w, x, z, q, i, i2, i3;

                    u = 1; w = a;
                    x = 0; z = b;

                    while (w != 0) {
                        if (w < z) {
                            q = u; u = x; x = q;
                            q = w; w = z; z = q;
                        }
                            q = w / z;
                            u -= q * x;
                            w -= q * z;
                    }

                    if (z == 1) {
                        if (x < 0) {
                            x += b;
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n Odwrotnosc modulo to: {0}, bo \n ", x);
                        int wynik1 = (a * x);
                        int wynik2 = wynik1 % b;
                        Console.WriteLine("  a * x mod b \n\n {0} * {1} mod {2} \n\n {3} mod {4} = {5} \n ", a,x,b, wynik1, b, wynik2);
                        

                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" \n Brak odwrotnosci modulo! \n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" \n Czy chcesz ponownie? ");
                    Console.WriteLine(" Jesli 'TAK' to klinij Y, jesli 'NIE' to kliknij N ");
                    int t = 0;

                    do
                    {
                        Console.Write("  Wpisz: ");
                        var wybor = Console.ReadKey();

                        if (wybor.Key == ConsoleKey.N)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n Wyszedłeś :( ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            exit = true;
                            t = 2;
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else if (wybor.Key == ConsoleKey.Y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\n To zaczynamy od poczatku :) ");
                            Console.WriteLine(" Naciśnij klawisz.. \n");
                            Console.ReadKey();
                            t = 2;
                            Console.WriteLine("\n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Bledny wybor \n");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    } while (t < 1);
                }

            } while (!exit);

            return 0;
        }
    }
}