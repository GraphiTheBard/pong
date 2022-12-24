using System;
using System.Linq;
using System.Threading;

namespace pong
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();
            const int playAreaLength = 75, playAreaWidth = 25;
            const char tile = '=';

            const int paddleLength = 4;
            const char paddleBody = '|';

            int rightPaddlePos = 0;
            int leftPaddlePos = 0;

            string playAreaBorder = string.Concat(Enumerable.Repeat(tile, playAreaLength));

            int ballX = playAreaLength / 2;
            int ballY = playAreaWidth / 2;
            const char ball = 'o';


            bool ballUp = true;
            bool ballRight = true;

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

                    Console.SetCursorPosition(playAreaLength - 1, 1 + i + rightPaddlePos);
                    Console.WriteLine(paddleBody);

                }


                while (!Console.KeyAvailable)
                {

                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(ball);


                    Thread.Sleep(70);


                    if (ballUp)
                    {
                        ballY--;
                    }

                    else
                    {
                        ballY++;
                    }

                    if (ballY == 1 || ballY == playAreaWidth -1) {
                        ballUp = !ballUp;
                    
                    }

                   


                    if (ballRight)
                    {
                        ballX++;

                    }

                    else {
                        ballX--;
                    }

                    if (ballX < 1)
                    {

                        if (ballY >= leftPaddlePos + 1 || ballY <= leftPaddlePos + paddleLength)
                        {
                            ballRight = !ballRight;
                        }

                        else {
                             ballX = playAreaLength / 2;
                             ballY = playAreaWidth / 2;

                        }
                    }


                    if (ballX == playAreaLength -1)
                    {

                        if (ballY >= rightPaddlePos + 1 || ballY <= rightPaddlePos + paddleLength)
                        {
                            ballRight = !ballRight;
                        }

                        else
                        {
                            ballX = playAreaLength / 2;
                            ballY = playAreaWidth / 2;

                        }
                    }


                    // Console.SetCursorPosition(ballX-1, ballY-1);
                    //Console.WriteLine(' ');






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

                        if (rightPaddlePos > 0)
                        {
                            rightPaddlePos--;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        if (rightPaddlePos < playAreaWidth - paddleLength - 1)
                        {
                            rightPaddlePos++;
                        }
                        break;




                }

                for (int i = 1; i < playAreaWidth; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(' ');

                    Console.SetCursorPosition(playAreaLength - 1, i);
                    Console.WriteLine(' ');

                }
            }



            //player movement

            






        }
    }
}
