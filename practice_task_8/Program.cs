using System;
using System.Text.RegularExpressions;

namespace practice_task_8
{
    class Program
    {
        static void Main()
        {
            Regex chessCoordReg = new Regex(@"[a-h][1-8]");

            Console.Write("Введите позицию первой клетки: ");
            string firstPos = Console.ReadLine().ToLower();
            Console.Write("\nВведите позицию другой клетки: ");
            string secondPos = Console.ReadLine().ToLower();

            char[,] chessBoard = GenerateChessBoard();
            
            if (!chessCoordReg.IsMatch(firstPos) || !chessCoordReg.IsMatch(secondPos))
            {
                Console.WriteLine("Введены некорректные координаты!");
                return;
            }

            firstPos = ConvertChessCoordsToNormalCoords(firstPos);
            secondPos = ConvertChessCoordsToNormalCoords(secondPos);

            if (CoordsNotValid(firstPos, secondPos))
            {
                Console.WriteLine("Введены некорректные данные!");
                return;
            }

            if (TilesEquale(firstPos, secondPos, chessBoard))
            {
                Console.WriteLine("Клетки одного цвета.");
            }
            else
            {
                Console.WriteLine("Клетки разного цвета.");
            }

            DrawChessBoard(chessBoard);
        }


        static char[,] GenerateChessBoard()
        {
            char[,] board = new char[8, 8];

            for (int i=0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i+j) % 2 == 0) board[i, j] = '■';
                    else board[i, j] = '¤';
                }
            }
            return board;
        }

        static void DrawChessBoard(char[,] board)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Доска:\n");

            for(int i = 0; i < 8; i++)
            {
               
                Console.Write((char)('a' + i));
            }
            Console.WriteLine();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.Write($" {i+1}");
                Console.WriteLine();
            }
        }

        static public string ConvertChessCoordsToNormalCoords(string chessCoords)
        {
            int xCoord = chessCoords[0] - 'a' + 1;
            int yCoord = int.Parse(chessCoords[1].ToString());

            return new string(xCoord.ToString() + yCoord.ToString());
        }

        static public Boolean CoordsNotValid(string firstPosition, string secondPosition)
        {
            int firstX = firstPosition[0] - '0';
            int firstY = firstPosition[1] - '0';
            int secondX = secondPosition[0] - '0';
            int secondY = secondPosition[1] - '0';

            if (firstPosition == secondPosition) { return true; }
            if ((firstX < 0 || firstY < 0 || firstX > 8 || firstY > 8) &&
                (secondX < 0 || secondY < 0 || secondX > 8 || secondY > 8))
            { return true; }

            return false;
        }

        static bool TilesEquale(string first, string second, char[,] board)
        {
            int firstX = Convert.ToInt32(first[0] - '0');
            int firstY = Convert.ToInt32(first[1] - '0');
            int secondX = Convert.ToInt32(second[0] - '0');
            int secondY = Convert.ToInt32(second[1] - '0');

            if (board[firstX, firstY] == board[secondX, secondY])
            {
                return true;
            }
            return false;
        }
    }
}
