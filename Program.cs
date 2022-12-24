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


            //play area
            const int playAreaLength = 75, playAreaWidth = 25;
            const char tile = '=';
            string playAreaBorder = string.Concat(Enumerable.Repeat(tile, playAreaLength));

            //paddle and player scores
            const int paddleLength = 4;
            const char paddleBody = '|';

            int rightPaddlePos = playAreaWidth / 2 - 1;
            int leftPaddlePos = playAreaWidth / 2 - 1;

            int leftPlayerScore = 0;
            int rightPlayerScore = 0;



            //ball 

            int ballX = playAreaLength / 2;
            int ballY = playAreaWidth / 2;
            const char ball = 'o';

            int ballSpeedModifier = 90;


            bool ballUp = true;
            bool ballRight = true;


            //Display instructions

            Console.SetCursorPosition(playAreaLength + 10, playAreaWidth / 2 - 1);
            Console.WriteLine("R: reset");
            Console.SetCursorPosition(playAreaLength + 10, playAreaWidth / 2);
            Console.WriteLine("W/S: left paddle");
            Console.SetCursorPosition(playAreaLength + 10, playAreaWidth / 2 + 1);
            Console.WriteLine("UP/DOWN: right paddle");

            //Main thingy    
            while (true)
            {
                //setting up the play area
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(playAreaBorder);

                Console.SetCursorPosition(0, playAreaWidth);
                Console.WriteLine(playAreaBorder);




                //drawing/updating player position
                for (int i = 0; i < paddleLength; i++)
                {
                    Console.SetCursorPosition(0, 1 + i + leftPaddlePos);
                    Console.WriteLine(paddleBody);

                    Console.SetCursorPosition(playAreaLength - 1, 1 + i + rightPaddlePos);
                    Console.WriteLine(paddleBody);

                }

                //ball movement
                while (!Console.KeyAvailable)
                {

                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(ball);


                    Thread.Sleep(ballSpeedModifier);

                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(' ');


                    if (ballUp)
                    {
                        ballY--;
                    }

                    else
                    {
                        ballY++;
                    }

                    if (ballY == 1 || ballY == playAreaWidth - 1)
                    {
                        ballUp = !ballUp;

                    }




                    if (ballRight)
                    {
                        ballX++;

                    }

                    else
                    {
                        ballX--;
                    }

                    if (ballX == 1)
                    {

                        if (ballY >= leftPaddlePos + 1 && ballY <= leftPaddlePos + paddleLength)
                        {
                            ballRight = !ballRight;
                        }

                        else
                        {
                            ballX = playAreaLength / 2;
                            ballY = playAreaWidth / 2;
                            rightPlayerScore++;

                        }
                    }


                    if (ballX == playAreaLength - 2)
                    {

                        if (ballY >= rightPaddlePos + 1 && ballY <= rightPaddlePos + paddleLength)
                        {
                            ballRight = !ballRight;

                        }

                        else
                        {
                            ballX = playAreaLength / 2;
                            ballY = playAreaWidth / 2;
                            leftPlayerScore++;

                        }
                    }


                    Console.SetCursorPosition(playAreaLength / 2, playAreaWidth + 2);
                    Console.WriteLine(leftPlayerScore + "|" + rightPlayerScore);






                }





                //reading player input
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


                    case ConsoleKey.R:

                        leftPlayerScore = 0;
                        rightPlayerScore = 0;

                        ballX = playAreaLength / 2;
                        ballY = playAreaWidth / 2;

                        break;




                }

                //deleting old player position
                for (int i = 1; i < playAreaWidth; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(' ');

                    Console.SetCursorPosition(playAreaLength - 1, i);
                    Console.WriteLine(' ');

                }




            }

        }
    }
}
