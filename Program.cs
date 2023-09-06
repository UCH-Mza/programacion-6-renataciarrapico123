using System;
using System.Threading.Tasks;

namespace BarraDeEstadoConBarraCarga
{
    class ejercicio4

    {
        static bool procesoCancelado = false;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando proceso...");

            Task procesoTarea = EjecutarProcesoAsync();
            Task barraCargaTarea = ActualizarBarraCargaAsync(procesoTarea);

            await Task.WhenAll(procesoTarea, barraCargaTarea);

            Console.WriteLine("Proceso completado.");
        }

        static async Task EjecutarProcesoAsync()
        {
            // Simula un proceso que toma tiempo
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(1000);

                if (procesoCancelado)
                {
                    Console.WriteLine("Proceso cancelado.");
                    return;
                }
            }
        }

        static async Task ActualizarBarraCargaAsync(Task procesoTarea)
        {
            int barLength = 20; 
            int porcentaje = 0;

            Console.WriteLine("Progreso:");
            while (!procesoTarea.IsCompleted)
            {
                Console.Write($"|{new string('#', porcentaje / (100 / barLength)).PadRight(barLength)}| {porcentaje}%\r");
                porcentaje += 10;
                await Task.Delay(1000);
            }
            Console.WriteLine();
        }

        static void CancelarProceso()
        {
            procesoCancelado = true;
        }
    }
}