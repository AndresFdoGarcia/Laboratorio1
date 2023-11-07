using System;
using System.Collections.Generic;

namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        Process p1 = new Process { Name = "Proceso 1", TimeLeft = 5 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p2 = new Process { Name = "Proceso 2", TimeLeft = 7 }; //Se define el proceso: nombre y tiempo de ejecución
        Process p3 = new Process { Name = "Proceso 3", TimeLeft = 3 }; //Se define el proceso: nombre y tiempo de ejecución

        Planner Planner = new Planner(2); // Configura el quantum

        Planner.AddProcess(p1);
        Planner.AddProcess(p2);
        Planner.AddProcess(p3);

        Planner.Ejecutar();
    }
    
    public class Process{
        public required string Name {get;set;}
        public int TimeLeft { get; set; }
    }

    public class Planner
    {
        private Queue<Process> colaProcesos;
        private int quantum;

        public Planner(int quantum)
        {
            colaProcesos = new Queue<Process>();
            this.quantum = quantum;
        }

        public void AddProcess(Process proceso)
        {
            colaProcesos.Enqueue(proceso);
        }

        public void Ejecutar()
        {
            while (colaProcesos.Count > 0)
            {
                Process procesoActual = colaProcesos.Dequeue();

                Console.WriteLine($"Ejecutando {procesoActual.Name}");

                int tiempoEjecucion = Math.Min(quantum, procesoActual.TimeLeft);
                procesoActual.TimeLeft -= tiempoEjecucion;

                if (procesoActual.TimeLeft > 0)
                {
                    Console.WriteLine($"Poner {procesoActual.Name} nuevamente en la cola, tiempo de ejecución restante: {procesoActual.TimeLeft}");
                    colaProcesos.Enqueue(procesoActual);
                }
                else
                {
                    Console.WriteLine($"{procesoActual.Name} completado");
                }
            }
        }
    }
}

