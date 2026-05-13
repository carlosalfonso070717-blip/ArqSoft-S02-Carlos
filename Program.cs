using System;
using Ahorcado;

while (true)
{
    Console.Clear();
    Console.WriteLine("=== MENÚ DE JUEGOS ===");
    Console.WriteLine("¿Qué juego quieres jugar?");
    Console.WriteLine("  1 — Ahorcado");
    Console.WriteLine("  2 — Viborita");
    Console.Write("Opción: ");

    var opcion = Console.ReadLine();

    if (opcion == "2")
    {
        var motor = new MotorViborita();
        var ui = new ConsolaUIViborita(motor);

        Console.CursorVisible = false;

        while (!motor.Ganado() && !motor.Perdido())
        {
            ui.MostrarTablero();
            var tecla = ui.LeerTecla();

            if (tecla == ConsoleKey.Q) break;

            if (tecla != ConsoleKey.NoName)
            {
                motor.CambiarDireccion(tecla);
            }

            motor.Avanzar();
            Thread.Sleep(150);
        }

        ui.MostrarTablero();
        ui.MostrarMensaje(motor.Ganado() ? "\n¡Ganaste! Llegaste a 10 puntos." : "\nGame over.");

        Console.CursorVisible = true;
    }
    else if (opcion == "1")
    {
        string categoria = ConsolaUI.PedirCategoria();
        var repositorio = new PalabrasEnMemoria(categoria);
        var motor = new MotorAhorcado(repositorio);
        var ui = new ConsolaUI(motor);

        Console.Clear();
        Console.WriteLine("=== AHORCADO ===");

        while (!motor.Ganado() && !motor.Perdido())
        {
            ui.MostrarTablero();
            char letra = ui.PedirLetra();

            if (motor.LetraYaUsada(letra))
            {
                ui.MostrarMensaje("Ya usaste esa letra.");
                continue;
            }

            motor.RegistrarLetra(letra);
        }

        ui.MostrarTablero();

        if (motor.Ganado())
            ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
        else
            ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
    }
    else
    {
        Console.WriteLine("Opción no válida.");
        Thread.Sleep(1000);
        continue;
    }

    Console.WriteLine("\n¿Quieres jugar otra vez? (S/N)");
    var respuesta = Console.ReadLine()?.ToUpper();
    if (respuesta != "S")
    {
        break;
    }
}