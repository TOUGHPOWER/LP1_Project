using System;
using System.Collections.Generic;

namespace GameofUr
{
    public class View // view
    {
        public int r, c;

        public View()
        {

        }
        public void sos() // this is the main menu
        {
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("play  --- play the game");
            Console.WriteLine("show  --- to show the main menu again");
            Console.WriteLine("help  --- to show the help menu");
            Console.WriteLine("quit  --- to exit the program");
            Console.WriteLine("+---------------------------------------------+");
        }

        public string takinginput(string input)
        {
            Console.Write("\n> ");
            input = Console.ReadLine();
            Console.WriteLine();
            return input;
        }

        public void game() // here is another menu which is the play menu
        {
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("write --- write player names");
            Console.WriteLine("roll  --- roll the dice");
            Console.WriteLine("board --- to show the board");
            Console.WriteLine("back  --- Go back to main menu");
            Console.WriteLine("+---------------------------------------------+");
        }
        public void x_header()
        {
            Console.WriteLine("    0   1   2");
        }
        public void x_4space()
        {
            Console.Write("    ");
        }
        public void x_2space()
        {
            Console.Write("  ");
        }
        public void HorizontalSymbol()
        {
            Console.Write("+---");
        }
        public void plusbs()
        {
            Console.Write("+\n");
        }
        public void backslash()
        {
            Console.Write("\n");
        }

        public void x_5spaces()
        {
            Console.Write(r + "     ");
        }
        public void playerspawn()
        {
            Console.Write("| " + Player.players[r, c] + " ");
        }

        public void y_header()
        {
            Console.Write(r + " ");
        }
        public void verticalbs()
        {
            Console.Write("|\n");
        }
        public void _plusbs()
        {
            Console.Write("+\n\n");
        }

        public void targetx()
        {
            Console.WriteLine("Enter Target's X axis");
        }
        public void targety()
        {
            Console.WriteLine("Enter Target's Y axis");
        }
        public void invalid()
        {
            Console.WriteLine("Invalid Move.");
        }
        public void chooseWrong()
        {
            Console.WriteLine("\nYou didn't choose correct piece. Another Player turns\n");
        }
        public void safezone()
        {
            Console.WriteLine("You are in safe zone. You got a chance to roll the dice again");
        }

        public void p1()
        {
            Console.WriteLine(" Player 1 Turns\n\n");
        }

        public void p_Turn(int x)
        {
            PlayerTurn playerTurn = new PlayerTurn();
            Console.WriteLine("You have to choose a piece to move " + x + " blocks\n");
        }
        public void p2()
        {
            Console.WriteLine("Player 2 Turns\n\n");
        }

        public void capturePiece()
        {
            Console.WriteLine("you cannot capture your own piece");
        }

        public void winGame()
        {
            Console.WriteLine("YOU WIN");
        }
    }
}