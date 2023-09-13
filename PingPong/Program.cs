using System;
using System.Linq;

namespace PingPong
{
    internal class Program
    {
        //https://softuni.org/project-tutorials/how-to-make-a-pong-game-in-csharp-guide/
        //Ping Pong
        static void Main(string[] args)
        {
            //criando variaveis largura e comprimento
            const int fieldLength = 50, fieldWidht = 15;
            const char fieldTitle = '#';
            //adicionando uma cadeia de caracteres ao final 
            string line = string.Concat(Enumerable.Repeat(fieldTitle,fieldLength));

            //Criando Raquetes
            const int racketLenght = fieldWidht / 4;
            const char racketTile = '|';

            int leftRacketHeight = 0;
            int rightRacketHeight = 0;

            
            //cria um loop e imprime as bordas do jogo no console
            while (true) 
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidht);
                Console.WriteLine(line);
                
                //Fazendo aparecer as raquetes
                for(int i = 1; i<racketLenght; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                    Console.WriteLine(racketTile);
                }

                //criando movimentos do jogador
                while (!Console.KeyAvailable)
                {

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
                }
            }
        }
    }
}
