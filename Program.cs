using System.Runtime.CompilerServices;
using System;
using System.Threading;
using System.Threading.Tasks;


var hilo1 = new Task(() =>
{
    for (int x = 0; x < 100; x++)
    {
        Console.WriteLine("Hilo 1, escribe: " + x);
    }

});


var hilo2 = new Task(() =>
{
    for (int x = 0; x < 100; x++)
    {
        Console.WriteLine("Hilo 2, escribe: " + x);
    }
});



var hilo3 = new Task(() =>
{
    for (int x = 0; x < 100; x++)
    {
        Console.WriteLine("Hilo 3, escribe: " + x);
    }
});


var hilo4 = new Task(() =>
{
    for (int x = 0; x < 100; x++)
    {
        Console.WriteLine("Hilo 4, escribe: " + x);
    }
});

var hilo5 = new Task(() =>
{
    for (int x = 0; x < 100; x++)
    {
        Console.WriteLine("Hilo 5, escribe: " + x);
    }
});

hilo1.Start();
hilo2.Start();
hilo3.Start();
hilo4.Start();
hilo5.Start();

Task.WaitAll(
    hilo1,
    hilo2,
    hilo3,
    hilo4,
    hilo5);

Console.WriteLine("Finaliza");
Console.ReadLine();
