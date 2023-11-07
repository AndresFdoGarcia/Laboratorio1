using System.Threading;

namespace fifo;
class Program
{
    static void Main(string[] args)
    {
        Process p1 = new Process { Name = "Proceso 1", TimeLeft = 5 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p2 = new Process { Name = "Proceso 2", TimeLeft = 7 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p3 = new Process { Name = "Proceso 3", TimeLeft = 3 }; //Se define el proceso: nombre y tiempo de ejecución

        Planner Planner = new Planner(); // Configura el quantum

        Planner.AddProcess(p1);
        Planner.AddProcess(p2);
        Planner.AddProcess(p3);

        Planner.RunQ();
    }
    
    public class Process{
        public required string Name {get;set;}
        public int TimeLeft { get; set; }
    }

    public class Planner
    {
        private Queue<Process> colaProcesos;        

        public Planner()
        {
            colaProcesos = new Queue<Process>();           
        }

        public void AddProcess(Process proceso)
        {
            colaProcesos.Enqueue(proceso);
        }

        public void RunQ()
        {
            while (colaProcesos.Count > 0)
            {
                Process procesoActual = colaProcesos.Dequeue();
                Console.WriteLine($"Ejecutando {procesoActual.Name}");

                for (int segundos = 1; segundos <= procesoActual.TimeLeft; segundos++)
                {
                    Console.Write(segundos);
                    Console.Write(segundos < procesoActual.TimeLeft ? "," : "");

                    // Espera 1 segundo
                    Thread.Sleep(1000);
                }                
                Console.WriteLine();
                Console.WriteLine($"El proceso {procesoActual.Name} ha finalizado");
                Console.WriteLine();               
            }
        }
    }
}
