using System;
using System.Collections.Generic;

namespace GameofUr
{
    public class GameManager
    {
        public string input;
        string input1;
        View view = new View();
        Board board = new Board();


        public GameManager()
        {
        }
        public void game() // here is another menu which is the play menu
        {

            view.sos();
            do
            {
                input1 = view.takinginput(input);

                switch (input1)
                {
                    case "play":
                        board.displayBoard();
                        view.sos();
                        break;

                    case "show":
                        view.sos();
                        break;

                    case "help":
                        view.help();
                        break;

                    case "quit":
                        System.Environment.Exit(0);
                        break;
                }
            } while (input1 != "quit");
        }

    }
}
