using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        const int HEIGHT = 80;
        const int WIDTH = 25;

        static void Main(string[] args)
        {
            Console.SetBufferSize(HEIGHT, WIDTH);
            Walls walls = new Walls(HEIGHT, WIDTH);
            walls.Draw();

           

            FoodCreator foodCreator = new FoodCreator(WIDTH, HEIGHT, 'p');
            Point food = foodCreator.CreateFood();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake)|| snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    snake.Draw();
                }
                else
                {
                    snake.Move();
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key);
                    
                }
                Thread.Sleep(100);
                snake.Move();

            }

            Console.ReadLine();
        }
    }
}
