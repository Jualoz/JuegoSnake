using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoSnake
{
    internal class Comida
    {
        public Point Posicion { get; set; }
        public ConsoleColor Color { get; set; }
        public Ventana VentanaC { get; set; }
        public Comida(ConsoleColor color, Ventana ventana)
        {
            Color = color;
            VentanaC = ventana;
        }

        private void Dibujar()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.Write("█");
        }

        public bool GenerarComida(Snake snake)
        {
            int logSnake = snake.Cuerpo.Count + 1;
            
            if ((VentanaC.Area - logSnake) <= 0) 
                return false;

            Random random = new Random();
            int x = random.Next(VentanaC.LimiteSuperior.X + 1, VentanaC.LimiteInferior.X - 1);
            int y = random.Next(VentanaC.LimiteSuperior.Y + 1, VentanaC.LimiteInferior.Y - 1);
            Posicion = new Point(x, y);

            foreach(Point item in snake.Cuerpo)
            {
                if ((x == item.X && y == item.Y) || (x == snake.Cabeza.X && y == snake.Cabeza.Y))
                {
                    if (GenerarComida(snake)) 
                        return true;
                }
            }

            Dibujar();
            return true;
        }
    }
}
