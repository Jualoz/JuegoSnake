using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSnake
{
    internal class Ventana
    {
        public string Titulo { get; set; }
        public int Ancho { get; set; }
        public int Altura { get; set; }
        public int Area { get; set; }
        public ConsoleColor ColorFondo { get; set; }
        public ConsoleColor ColorLetra { get; set; }
        public Point LimiteSuperior { get; set; }
        public Point LimiteInferior { get; set; }
        public Snake SnakeC { get; set; }
        public Ventana (string titulo, int ancho, int altura, ConsoleColor colorFondo, ConsoleColor colorLetra, Point limiteSuperior, Point limiteInferior)
        {
            Titulo = titulo;
            Ancho = ancho;
            Altura = altura;
            ColorFondo = colorFondo;
            ColorLetra = colorLetra;
            LimiteSuperior = limiteSuperior;
            LimiteInferior = limiteInferior;
            Area = ((LimiteInferior.X - LimiteSuperior.X) - 1) * ((LimiteInferior.Y - LimiteSuperior.Y) - 1);
            Init();
        }

        public void Init()
        {
            Console.SetWindowSize(Ancho, Altura);
            Console.Title = Titulo;
            Console.CursorVisible = false;
            Console.BackgroundColor = ColorFondo;
            Console.Clear();
            SnakeC = new Snake(new Point(LimiteInferior.X / 2, LimiteInferior.Y - 3), ConsoleColor.Magenta, ConsoleColor.White, this, null);
            SnakeC.IniciarCuerpo(4);
        }

        public void DibujarMarco()
        {
            Console.ForegroundColor = ColorLetra;

            for (int i = LimiteSuperior.X; i < LimiteInferior.X; i++)
            {
                Console.SetCursorPosition(i, LimiteSuperior.Y);
                Console.Write("═");
                Console.SetCursorPosition(i, LimiteInferior.Y);
                Console.Write("═");
            }
            for (int i = LimiteSuperior.Y; i < LimiteInferior.Y; i++)
            {
                Console.SetCursorPosition(LimiteSuperior.X, i);
                Console.Write("║");
                Console.SetCursorPosition(LimiteInferior.X, i);
                Console.Write("║");
            }
            
            Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
            Console.Write("╔");
            Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
            Console.Write("╚");
            Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
            Console.Write("╗");
            Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
            Console.Write("╝");
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 12, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 4);
            Console.Write("J U E G O  S N A K E");
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 8, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2);
            Console.Write("Enter - JUGAR");
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 7, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 1);
            Console.Write("Esc - SALIR");

            SnakeC.MoverMenu();
        }

        public void Teclado(ref bool ejecucion, ref bool jugar, Snake snake)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo tecla = Console.ReadKey();
                if (tecla.Key == ConsoleKey.Enter)
                {
                    jugar = true;
                    Console.Clear();
                    DibujarMarco();
                    snake.Init();
                }
                if (tecla.Key == ConsoleKey.Escape)
                {
                    ejecucion = false;
                    Console.Clear();
                }
            }
        }

        public void GameOver(string text)
        {
            Console.Clear();
            DibujarMarco();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(LimiteSuperior.X + (LimiteInferior.X / 2) - 10, LimiteSuperior.Y + (LimiteInferior.Y / 2) - 2);
            Console.Write(text);
            Thread.Sleep(3000);
            Console.Clear();
            DibujarMarco();
        }
    }
}
