using System;
using System.Linq;
using System.Threading;

namespace PingPong
{
    internal class Program
    {
        //https://softuni.org/project-tutorials/how-to-make-a-pong-game-in-csharp-guide/
        //Ping Pong
        static void Main(string[] args)
        {
            //criando variaveis largura e comprimento
            const int fieldLength = 50, fieldWidth = 15;
            const char fieldTitle = '#';
            //adicionando uma cadeia de caracteres ao final 
            string line = string.Concat(Enumerable.Repeat(fieldTitle,fieldLength));

            //Criando Raquetes
            const int racketLength = fieldWidth / 4;
            const char racketTile = '|';

            int leftRacketHeight = 0;
            int rightRacketHeight = 0;


          
            
            //posicoes da bola (Calculo Ponto Medio)
            int ballX = fieldLength / 2;
            int ballY = fieldWidth / 2;
            //adicionando bola
            const char ballTitle = 'O';

            bool isBallGoinDown = true;
            bool isBallGoingRight = true;


            //Pontos dos jogadores
            int leftPlayerPoints = 0;
            int rightPlayerPoints = 0;

            //placar
            int scoreboardX = fieldLength / 2 - 2;
            int scoreboardY = fieldWidth + 1;


            //cria um loop e imprime as bordas do jogo no console
            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);
                
                //Fazendo aparecer as raquetes
                for(int i = 1; i< racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                    Console.WriteLine(racketTile);
                }

                //criando movimentos do jogador
                while (!Console.KeyAvailable)
                {
                    

                    Console.SetCursorPosition(ballX,ballY);
                    Console.WriteLine(ballTitle);
                    Thread.Sleep(100);//timer para reação do jogador

                    //limpando posicoes da bola
                    Console.SetCursorPosition( ballX, ballY);
                    Console.WriteLine(" ");                   

                    //movimentando a bola
                    if(isBallGoinDown) 
                    {
                        ballY++;
                    }
                    else 
                    {
                        ballY--;
                    }
                    if(isBallGoingRight) 
                    {
                        ballX++;
                    }
                    else
                    {
                        ballX--;
                    }

                    if(ballY==1||ballY==fieldWidth - 1)
                    {
                        isBallGoinDown=!isBallGoinDown;//Change direction
                    }
                    if(ballX ==1)
                    {
                        if(ballY >- leftRacketHeight + 1 && ballY <= leftRacketHeight + racketLength)
                        {
                            isBallGoingRight =!isBallGoingRight;
                        }
                        else
                        {
                            rightPlayerPoints++;
                            ballY = fieldWidth/2;
                            ballX = fieldLength/2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");
                            if (rightPlayerPoints == 10)
                            {
                                goto outer;
                            }
                        }
                    }
                    if(ballX==fieldLength - 2)
                    {
                        if(ballY>=rightRacketHeight+ 1 && ballY <= rightRacketHeight + racketLength)
                        {
                            isBallGoingRight = !isBallGoingRight;

                        }
                        else
                        {
                            leftPlayerPoints++;
                            ballY = fieldWidth/2;
                            ballX= fieldLength/2;
                            Console.SetCursorPosition(scoreboardX, scoreboardY);
                            Console.WriteLine($"{leftPlayerPoints} | {rightPlayerPoints}");
                            if(leftPlayerPoints == 10)
                            {
                                goto outer;
                            }
                        }
                    }
                }
                //Conferindo tecla pressionada
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if (rightRacketHeight > 0)
                        {
                            rightRacketHeight--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (rightRacketHeight < fieldWidth - racketLength - 1)
                        {
                            rightRacketHeight++;
                        }
                        break;

                    case ConsoleKey.W:
                        if (leftRacketHeight > 0)
                        {
                            leftRacketHeight--;
                        }
                        break;

                    case ConsoleKey.S:
                        if (leftRacketHeight < fieldWidth - racketLength - 1)
                        {
                            leftRacketHeight++;
                        }
                        break;
                }
                //limpar as posicoes anteriores
                for (int i=1; i < fieldWidth; i++)
                {
                    Console.SetCursorPosition(0,i);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(fieldLength - 1,i);
                    Console.WriteLine(" ");
                }

            }
        outer:;
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            if (rightPlayerPoints == 10)
            {
                Console.WriteLine("Right player won!");
            }
            else
            {
                Console.WriteLine("Left player won!");
            }
        }
    }
}
