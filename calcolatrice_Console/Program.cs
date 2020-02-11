using System;
using System.Collections.Generic;
using System.Linq;
namespace calcolatrice_Console
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Dictionary<string, IOperazione> operazioni = new Dictionary<string, IOperazione>();
          
            var type = typeof(IOperazione);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            foreach (var item in types)
            {
                var imp = (IOperazione)Activator.CreateInstance(item);
                if (!operazioni.ContainsKey(imp.operatore()))
                {
                    operazioni.Add(imp.operatore(), imp);
                }
            }

            while (true)
            {
                Console.WriteLine("Dammi il primo numero");
                double a = System.Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Scegli l'operazione");
                string operazione = Console.ReadLine();

                if (!operazioni.ContainsKey(operazione))
                {
                    Console.WriteLine("operazione non supportata");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                double b = 0;
                if (operazioni[operazione].IsDueNumeri())
                {
                    Console.WriteLine("Dammi il secondo numero");
                    b = System.Convert.ToDouble(Console.ReadLine());
                }

                
                double risultato = operazioni[operazione].esegui(a, b);

                Console.WriteLine("Risultato");
                Console.WriteLine(risultato);

                Console.ReadKey();

                Console.Clear();
            }

        }
    }


    interface IOperazione
    {
        double esegui(double a, double b);
        string operatore();

        bool IsDueNumeri();
    }

    public class Somma : IOperazione
    {
        public double esegui(double a, double b)
        {
            return a + b;
            //throw new NotImplementedException();
        }

        public bool IsDueNumeri()
        {
            return true;
        }

        public string operatore()
        {
            return "+";
        }
    }

    public class Sottrazione : IOperazione
    {
        public double esegui(double a, double b)
        {
            return a - b;
        }
        public string operatore()
        {
            return "+";
        }

        public bool IsDueNumeri()
        {
            return true;
        }
    }

    public class Moltiplicazione : IOperazione
    {
        public double esegui(double a, double b)
        {
            return a * b;
        }
        public string operatore()
        {
            return "*";
        }

        public bool IsDueNumeri()
        {
            return true;
        }
    }

    public class Divisione : IOperazione
    {
        public double esegui(double a, double b)
        {
            //throw new NotImplementedException();

            if (b == 0)
                return 0;
            return a / b;
        }
        public string operatore()
        {
            return "/";
        }

        public bool IsDueNumeri()
        {
            return true;
        }
    }

    public class Potenza : IOperazione
    {
        public double esegui(double a, double b)
        {
            //throw new NotImplementedException();

            return Math.Pow(a, b);
            //if (b == 0)
            //    return 0;
            //return a / b;
        }
        public string operatore()
        {
            return "^";
        }

        public bool IsDueNumeri()
        {
            return true;
        }
    }

    public class radice : IOperazione
    {
        public double esegui(double a, double b)
        {
            return Math.Sqrt(a);
        }

        public string operatore()
        {
            return "@";
        }

        public bool IsDueNumeri()
        {
            return false ;
        }
    }

    public class seno : IOperazione
    {
        public double esegui(double a, double b)
        {
            return Math.Sin(a);
        }

        public bool IsDueNumeri()
        {
            return false;
        }

        public string operatore()
        {
            return "s";
        }
    }

}
