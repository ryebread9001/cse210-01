

using System;
using System.Collections.Generic;


namespace cse210_01
{

    class Program
    {
        static void Main(string[] args)
        {
            string currentPlayer = "x";
            
            List<List<String>> matrix = GetNewBoard();
            //List<string> board = GetNewBoard();
                
            int moveCount = 0;
            while (!IsGameOver(matrix, moveCount))
            {
                DisplayBoard(matrix);
                int choice = GetMoveChoice(currentPlayer);
                MakeMove(matrix, choice, currentPlayer);
                moveCount++;
                    
                currentPlayer = GetNextPlayer(currentPlayer);
                
            }
            currentPlayer = GetNextPlayer(currentPlayer);
            DisplayWin(matrix, currentPlayer, moveCount);
            
            
            
        }

        static List<List<string>> GetNewBoard()
        {
            List<List<string>> board = new List<List<string>>();
            board.Add(new List<String>());
            board.Add(new List<String>());
            board.Add(new List<String>());
            


            for (int i = 1; i <= 3; i ++) {
                board[0].Add(i.ToString());
            }
            for (int i = 4; i <= 6; i ++) {
                board[1].Add(i.ToString());
            }
            for (int i = 7; i <= 9; i ++) {
                board[2].Add(i.ToString());
            }
            

            return board;
        }

        static bool IsGameOver(List<List<string>> board, int moves)
        {
            return (IsWinner(board,"x") || IsWinner(board, "o") || moves > 8);
        }

        static void DisplayBoard(List<List<string>> board)
        {
            for (var i = 0; i < 3; i++) {
                for (var j = 0; j < 3; j++) {
                    Console.Write($"|{board[i][j]}|");
                    if (j == 2) {
                        Console.WriteLine("\n --+--+--");
                    }
                }
                
            }
        }

        static void DisplayWin(List<List<string>> board, string currentPlayer, int moves)
        {
            DisplayBoard(board);
            if (moves < 9) {
                Console.WriteLine($"{currentPlayer} Wins!");
            } else {
                Console.WriteLine("CATS GAME");
            }
            
        }


        static bool IsWinner(List<List<string>> board, string player)
        {
            if (board[0][0] == player && board[0][1] == player && board[0][2] == player) { return true; }
            if (board[1][0] == player && board[1][1] == player && board[1][2] == player) { return true; }
            if (board[2][0] == player && board[2][1] == player && board[2][2] == player) { return true; }

            // check columns
            if (board[0][0] == player && board[1][0] == player && board[2][0] == player) { return true; }
            if (board[0][1] == player && board[1][1] == player && board[2][1] == player) { return true; }
            if (board[0][2] == player && board[1][2] == player && board[2][2] == player) { return true; }

            // check diags
            if (board[0][0] == player && board[1][1] == player && board[2][2] == player) { return true; }
            if (board[0][2] == player && board[1][1] == player && board[2][0] == player) { return true; }

            return false;
        }

        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9) (0 to quit): ");
            string move = Console.ReadLine();
            int choice = int.Parse(move);
            if (choice == 0) {
                System.Environment.Exit(1);
            }
            return choice;
        }

        static void MakeMove(List<List<string>> board, int choice, string currentPlayer)
        {
            
            int index = 0;
            int indey = 0;
            switch (choice)
            {
                
                case 1:
                    index = 0;
                    indey = 0;
                    break;
                case 2:
                    index = 1;
                    indey = 0;
                    break;
                case 3:
                    index = 2;
                    indey = 0;
                    break;
                case 4:
                    index = 0;
                    indey = 1;
                    break;
                case 5:
                    index = 1;
                    indey = 1;
                    break;
                case 6:
                    index = 2;
                    indey = 1;
                    break;
                case 7:
                    index = 0;
                    indey = 2;
                    break;
                case 8:
                    index = 1;
                    indey = 2;
                    break;
                case 9:
                    index = 2;
                    indey = 2;
                    break;
            }
            if (board[indey][index] == "x" || board[indey][index] == "o") {
                Console.WriteLine("Spot is taken!!!");
                return;
            }
            board[indey][index] = currentPlayer;
        }
    }    
}