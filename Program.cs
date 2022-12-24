using System;
using System.Linq;
namespace pong
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            const int playAreaLenth = 70, playAreaWidth = 28;
            const char tile = '*';

            const int paddleLength = 4;
            const char paddleBody = '|';

            int rightPaddlePos = 0;
            int leftPaddlePos = 0;

            string playAreaBorder = string.Concat(Enumerable.Repeat(tile, playAreaLenth));

            while (true)
            {

                Console.SetCursorPosition(0, 0);
                Console.WriteLine(playAreaBorder);

                Console.SetCursorPosition(0, playAreaWidth);
                Console.WriteLine(playAreaBorder);

                for (int i = 0; i < paddleLength; i++)
                {
                    Console.SetCursorPosition(0, 1 + i + leftPaddlePos) ;
                    Console.WriteLine(paddleBody);

                    Console.SetCursorPosition(playAreaLenth - 1, 1 + i + rightPaddlePos);
                    Console.WriteLine(paddleBody);

                }


                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:

                        if (leftPaddlePos > 0)
                        {
                            leftPaddlePos--;
                        }
                        break;

                    case ConsoleKey.S:

                        if (leftPaddlePos < playAreaWidth - paddleLength - 1)
                        {
                            leftPaddlePos++;
                        }
                        break;

                    case ConsoleKey.UpArrow:

                        if (leftPaddlePos > 0)
                        {
                            rightPaddlePos--;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (leftPaddlePos < playAreaWidth - paddleLength - 1)
                        {
                            rightPaddlePos++;
                        }
                        break;




                }
            }



            //player movement

            






        }
    }
}
