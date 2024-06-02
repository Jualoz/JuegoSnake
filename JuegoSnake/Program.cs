using JuegoSnake;
using System.Drawing;

Ventana ventana;
Snake snake;
Comida comida;
bool jugar = false;
bool ejecucion = true;

void Iniciar()
{
    ventana = new Ventana("Snake", 65, 20, ConsoleColor.Black, ConsoleColor.White, new Point(5, 3), new Point(59, 18));
    ventana.DibujarMarco();
 
    comida = new Comida(ConsoleColor.Red, ventana);

    snake = new Snake(new Point(8, 5), ConsoleColor.DarkGreen, ConsoleColor.DarkGray, ventana, comida);

}

void Game()
{
    while (ejecucion)
    {
        ventana.Menu();
        ventana.Teclado(ref ejecucion, ref jugar, snake);
        while (jugar)
        {
            snake.Informacion(0, 34);
            snake.Mover();
            if (!snake.Vivo)
            {
                jugar = false;
                snake.Puntaje = 0;
            }
            Thread.Sleep(100);
        }
        Thread.Sleep(100);
    }
}

Iniciar();
Game();