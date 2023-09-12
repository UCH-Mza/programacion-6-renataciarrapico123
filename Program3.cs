using System;

Partida p = new Partida();

var hilo1 = new Task(() =>
{
    Random r = new Random();

    String eleccion;
    switch (r.Next(1, 4))
    {
        case 1:
            eleccion = "Piedra";
            break;
        case 2:
            eleccion = "Papel";
            break;
        case 3:
            eleccion = "Tijera";
            break;
        default:
            eleccion = "Error en eleccion switch";
            break;
    }

    Thread.Sleep(2000);
    p.Seleccionar(1, eleccion);

});

var hilo2 = new Task(() =>
{
    Random r = new Random();

    String eleccion;
    switch (r.Next(1, 4))
    {
        case 1:
            eleccion = "Piedra";
            break;
        case 2:
            eleccion = "Papel";
            break;
        case 3:
            eleccion = "Tijera";
            break;
        default:
            eleccion = "Error en eleccion switch";
            break;
    }

    Thread.Sleep(500);
    p.Seleccionar(2, eleccion);
});

hilo1.Start();
hilo2.Start();

await hilo1;
await hilo2;

Console.WriteLine(p.Resultado());