using System;
using System.Collections.Generic;

partial class Program
{
    static async Task Main()
    {
        List<int> listaint1 = new List<int>();
        List<int> listaint2 = new List<int>();
        List<int> listaint3 = new List<int>();
        List<int> listaint4 = new List<int>();
        List<int> listaint5 = new List<int>();
        List<int> listaint6 = new List<int>();
        List<int> listaint7 = new List<int>();
        List<int> listaint8 = new List<int>();
        List<int> listaint9 = new List<int>();
        List<int> listaint10 = new List<int>();

        Random rnd = new Random();
        for (int i = 0; i < 3000; i++)
        {
            listaint1.Add(rnd.Next(100));
            listaint2.Add(rnd.Next(100));
            listaint3.Add(rnd.Next(100));
            listaint4.Add(rnd.Next(100));
            listaint5.Add(rnd.Next(100));
            listaint6.Add(rnd.Next(100));
            listaint7.Add(rnd.Next(100));
            listaint8.Add(rnd.Next(100));
            listaint9.Add(rnd.Next(100));
            listaint10.Add(rnd.Next(100));
        }

        var total = 0;


        total += await contarLista(listaint1, "1");
        total += await contarLista(listaint2, "2");
        total += await contarLista(listaint3, "3");
        total += await contarLista(listaint4, "4");
        total += await contarLista(listaint5, "5");
        total += await contarLista(listaint6, "6");
        total += await contarLista(listaint7, "7");
        total += await contarLista(listaint8, "8");
        total += await contarLista(listaint9, "9");
        total += await contarLista(listaint10, "10");

        Console.WriteLine("La sumatoria de las 10 listas es: " + total);
    }

    public static async Task<int> contarLista(List<int> a, string nombre)
    {
        var suma = 0;
        foreach (var item in a)
        {
            suma += item;
        }

        Console.WriteLine("Hilo " + nombre + " - cuenta: " + suma);
        return suma;
    }

}
