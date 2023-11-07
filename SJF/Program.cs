namespace SJF;
class Program
{
    static void Main(string[] args)
    {
        Process p1 = new Process { Name = "Proceso 1", TimeLeft = 5, ArrivalTime= 0 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p2 = new Process { Name = "Proceso 2", TimeLeft = 7, ArrivalTime= 3 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p3 = new Process { Name = "Proceso 3", TimeLeft = 3, ArrivalTime= 6 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p4 = new Process { Name = "Proceso 4", TimeLeft = 4, ArrivalTime= 5 }; //Se define el proceso: nombre y tiempo de ejecución

        Planner Planner = new Planner(); // Configura el quantum

        Planner.AddProcess(p1);
        Planner.AddProcess(p2);
        Planner.AddProcess(p3);
        Planner.AddProcess(p4);

        Planner.Ejecutar();
    }
    
    public class Process{
        public required string Name {get;set;}
        public int TimeLeft { get; set; }
        public int ArrivalTime {get;set;}
    }

    public class Planner
    {
        private List<Process> colaProcesos;

        public Planner()
        {
            colaProcesos = new List<Process>();
        }

        public void AddProcess(Process proceso)
        {
            colaProcesos.Add(proceso);
        }

        public void Ejecutar()
        {
            int tiempoActual = 0;
        while (colaProcesos.Count > 0)
        {
            Process procesoActual = colaProcesos
                .Where(p => p.ArrivalTime <= tiempoActual)
                .OrderBy(p => p.TimeLeft)
                .First();

            colaProcesos.Remove(procesoActual);

            Console.WriteLine($"Ejecutando {procesoActual.Name}");

            int tiempoEjecucion = procesoActual.TimeLeft;
            tiempoActual += tiempoEjecucion;

            Console.WriteLine($"{procesoActual.Name} completado (Tiempo de retorno: {tiempoActual})");
        }
        }
    }
}
