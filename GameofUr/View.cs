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
            Console.Write(r + "   " + Player.players[r, c] + " ");
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
            Console.WriteLine("+----------------------------------------------------------+");
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
            Console.WriteLine("You are in safe zone. You got a chance to roll the dice again\n");
        }
        public void line()
        {
            Console.WriteLine("+----------------------------------------------------------+\n");
        }

        public void help()
        {
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("HELP MENU:");
            Console.WriteLine("This is the board game of two players where there are seven pieces for each player");
            Console.WriteLine("When each piece has reach to the position[5,0] for player one and [5,2] for player two. Player will win the game\n");
            Console.WriteLine("RULES:");
            Console.WriteLine("Four dices of 2 values (0,1) will roll on the screen and player has to move his piece to the sum of the dices");
            Console.WriteLine("Player one has the piece named as 'A'. Player one cannot access the player two piece when it is your turn");
            Console.WriteLine("Player two has the piece named as 'B'. Player two cannot access the player two piece when it is your turn\n");
            Console.WriteLine("HOW TO DO MOVEMENT IN A GAME:");
            Console.WriteLine("Player can access his piece with the help of board border number:");
            Console.WriteLine("1) By putting X-Axis of the piece");
            Console.WriteLine("2) By putting Y-Axis of the piece");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------------------+");
        }
        public void p1()
        {
            Console.WriteLine("+----------------------------------------------------------+");
            Console.WriteLine("        PLAYER 1 Turns\n");
        }

        public void p_Turn(int x)
        {
            PlayerTurn playerTurn = new PlayerTurn();
            Console.WriteLine("You have to choose a piece to move " + x + " blocks\n");
            Console.WriteLine("+----------------------------------------------------------+");
        }
        public void p2()
        {
            Console.WriteLine("+----------------------------------------------------------+");
            Console.WriteLine("       PLAYER 2 Turns\n");
        }

        public void capturePiece()
        {
            Console.WriteLine("You cannot capture your own piece\n");
        }

        public void winGame()
        {
            Console.WriteLine("YOU WIN\n");
        }
    }
}