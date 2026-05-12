using System;

var repositorio = new Ahorcado.PalabrasEnMemoria();
var motor = new Ahorcado.MotorAhorcado(repositorio);
var ui = new Ahorcado.ConsolaUI(motor);

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

if (ui.PreguntarOtravez())
{
    var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio);
    var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
    // Nota: Para que el ciclo se repita completamente aquí, 
    // usualmente se envolvería todo en un bucle do-while.
}
;