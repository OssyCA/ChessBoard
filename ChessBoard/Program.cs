using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Chessboard
{
    // Ossy Drakeneld 24NET
    internal class Program
    {
        static void Main(string[] args)
        {
            StartChessBoard();
        }
        static void StartChessBoard()
        {
            var msg = " ";
            do
            {
                Console.Clear();
                // Getting data required for the board through methods, and the variables to be passed as arguments
                int size = SizeOfBoard();
                string firstCharacter = AddCharacter(true);
                string secCharacter = AddCharacter(false);

                Chessboard(size, firstCharacter, secCharacter); // Calling the method 

                Console.WriteLine("Igen? skriv (ja) för fortsätta, tryck enter för avsluta: ");
                msg = Console.ReadLine().ToLower();

            } while (msg == "ja");
        }
        static int SizeOfBoard() // return the size of the board
        {
            var num = 0;
            while (num < 2) // Looping untill user enter a valid numbers
            {
                Console.WriteLine("Hur stort ska schackbrädet vara(Minst 2)?: "); // Let user enter a number, minium 2 to make board
                string enterNum = Console.ReadLine();

                if (int.TryParse(enterNum, out num) && num >= 2) // If input is a valid int, assign it to num
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("ogilitgt svar");

                }
            }
            return num;
        }
        static string AddCharacter(bool isFirst) // Method to return what user choose as character 
        {
            string message = isFirst ? "Första" : "Andra"; // give a message depending if its first or sec character
            Console.WriteLine($"Välj {message} karatär ska vara på shackbrädet: ");
            return Console.ReadLine();
        }
        static void Chessboard(int num, string firstCharcter, string secCharater) // Setting up the board
        {
            // Create a num x num board array 
            string[,] board = new string[num, num];

            // Loop through rows
            for (int i = 0; i < num; i++)
            {
                // Loop through columns
                for (int j = 0; j < num; j++)
                {
                    // If (i + j) is even, place firstCharacter; otherwise, place secCharacter
                    if ((i + j) % 2 == 0 == true)
                    {
                        board[i, j] = firstCharcter;
                    }
                    else
                    {
                        board[i, j] = secCharater;
                    }
                }
            }
            PrintBoard(board, num); // Print board before placing a piece, easier to see the change when placed piece

            PlacePiece(board, num);

        }
        static void PlacePiece(string[,] board, int num)
        {
            bool valid = false;
            Console.WriteLine("Skriv karatär för pjäs: ");
            string piece = Console.ReadLine(); // Piece to place

            while (!valid) // As long as a user not putting on a valid number it will run
            {
                Console.WriteLine($"Bestäm rad för pjäs (0 till {num - 1}): ");
                string rowInput = Console.ReadLine();

                Console.WriteLine($"Bestäm kolumn för pjäs (0 till {num - 1}): ");
                string colInput = Console.ReadLine();

                // Try to parse the input for row and column
                if (int.TryParse(rowInput, out int row) && int.TryParse(colInput, out int col))
                {
                    // Check if row and column are valid 
                    if (row < 0 || row >= num || col < 0 || col >= num)
                    {
                        Console.WriteLine("Fel: Ogiltig rad eller kolumn. Försök igen.");
                    }
                    else
                    {
                        // Place the piece and exit the loop
                        board[row, col] = piece;
                        valid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt svar, välj korrekt nummer");
                }

            }

            PrintBoard(board, num);

        }
        static void PrintBoard(string[,] board, int num) // Print the chessboard
        {
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(board[i, j] + " "); // Make it more readable
                }
                Console.WriteLine(); // New line after each row
            }
        }
    }
}