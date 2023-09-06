using System;
using System.Threading;
using System.Threading.Tasks;

class Punto5
{
    private static readonly object syncLock = new object();
    private static int[] progress = new int[4];
    private static bool[] isProcessFinished = new bool[4];

    static void Main()
    {
        // Iniciar un hilo para actualizar el tablero de comando
        Task.Run(() => UpdateCommandBoard());

        // Iniciar un hilo para cada proceso
        for (int i = 0; i < 4; i++)
        {
            int processNumber = i;
            Task.Run(() => RunProcess(processNumber));
        }

        Console.ReadLine();
    }

    static void UpdateCommandBoard()
    {
        while (!AreAllProcessesFinished()) // Esperar hasta que todos los procesos hayan terminado
        {
            Console.Clear(); // Limpiar la consola para actualizar el tablero

            for (int i = 0; i < 4; i++)
            {
                lock (syncLock)
                {
                    Console.WriteLine($"Proceso {i + 1} - Progreso: [{new string('#', progress[i] / 2)}{new string('-', (100 - progress[i]) / 2)}] {progress[i]}%");
                }
            }

            Thread.Sleep(100); // Actualizar cada 100 ms
        }

        Console.WriteLine("Todos los procesos han terminado.");
    }

    static void RunProcess(int processNumber)
    {
        for (int i = 5; i <= 100 && !isProcessFinished[processNumber]; i += 5) // Incrementar de a 5 en 5
        {
            lock (syncLock)
            {
                progress[processNumber] = i;
            }

            Thread.Sleep(200); // Simular el tiempo del proceso

            if (i == 100)
            {
                isProcessFinished[processNumber] = true;
            }
        }
    }

    static bool AreAllProcessesFinished()
    {
        lock (syncLock)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!isProcessFinished[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}