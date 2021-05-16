using System;
using System.Collections.Generic;

namespace GameofUr
{
    public class Board : View// model
    {
        private string[,] board;
        public const int row = 8;
        public const int col = 3;
        private Move move;
        View view = new View();

        public Board()
        {
            move = new Move();

            board = new string[row, col];
            BoardHorizontalSymbol = "+---";
            BoardVerticalSymbol = "| ";
        }
        public string BoardHorizontalSymbol { get; set; }
        public string BoardVerticalSymbol { get; set; }
        public void displayBoard()
        {
            while (!move.win) // until user put the wrong input
            {
                view.x_header();

                for (view.r = 0; view.r < row; view.r++)
                {
                    view.x_2space();

                    for (view.c = 0; view.c < col; view.c++)
                    {
                        if ((view.r == 4 && view.c == 0) || (view.r == 4 && view.c == 2)
                           || (view.r == 5 && view.c == 0) || (view.r == 5 && view.c == 2))
                        {

                            view.x_4space();
                            continue;
                        }
                        view.HorizontalSymbol();
                    }
                    if ((view.r != 4 || view.r != 5))
                    {
                        view.plusbs();
                    }
                    else if ((view.r == 4 || view.r == 5))
                    {
                        view.backslash();
                    }


                    for (view.c = 0; view.c < col; view.c++)
                    {
                        if ((view.r == 4 && view.c == 0) || (view.r == 5 && view.c == 0))
                        {
                            view.x_5spaces();
                            continue;
                        }
                        if ((view.r == 4 && view.c == 2) || (view.r == 5 && view.c == 2))
                        {
                            continue;
                        }

                        if (view.c == 0)
                            view.y_header();

                        view.playerspawn();
                    }

                    view.verticalbs();

                }
                // botton line needs to printed seprately
                view.x_2space();
                for (view.c = 0; view.c < col; view.c++)
                {
                    view.HorizontalSymbol();
                }
                view._plusbs();
                move.MakeMove();
            }
            move.Exit = false;
        }

    }

    public class Player : PlayerTurn
    {
        public const char Player1_Symbol = 'A';
        public const char Player2_Symbol = 'B';
        public const char space = ' ';
        public static char[,] players;
        public Player()
        {
            players = new char[Board.row, Board.col];
            initPlayer();// player will spawn
        }

        private void initPlayer()
        {
            for (int r = 0; r < Board.row; r++)
            {
                for (int c = 0; c < Board.col; c++)
                {
                    //place X  into first and last 2 rows of array
                    if ((r == 4 && c == 0))
                    {
                        players[r, c] = Player1_Symbol;
                    }
                    else if ((r == 4 && c == 2))
                    {
                        players[r, c] = Player2_Symbol;
                    }
                    else
                        players[r, c] = space;
                }
            }
        }
    }


    public class PlayerTurn// switching the players
    {
        public int p;
        int result;
        public int x;

        View view = new View();

        public PlayerTurn()
        {
            p = 1;
            result = 0;


        }
        public void Turn()
        {

            if (p == 1)
            {

                view.p1();
                doRoll();
                x = result;
                view.p_Turn(x);
                result = 0;
                p = 2;

            }
            else
            {
                view.p2(); // put line on view
                doRoll();
                x = result;
                view.p_Turn(x);
                result = 0;
                p = 1;
            }
        }
        private void doRoll() // dice Roll block
        {

            Random r = new Random();

            int[] dice = new int[4];
            dice[0] = r.Next(0, 2);
            dice[1] = r.Next(0, 2);
            dice[2] = r.Next(0, 2);
            dice[3] = r.Next(0, 2);
            result = dice[0] + dice[1] + dice[2] + dice[3];
            Console.WriteLine(dice[0] + " " + dice[1] + " " + dice[2] + " " + dice[3]);
        }
    }

    public class Move : Player // 
    {
        private int targetX;
        private int targetY;
        private int destinationX;
        private int destinationY;
        public bool safe;
        public bool win;
        private int i, j;
        PlayerTurn playerturn = new PlayerTurn();
        View view = new View();

        public Move()
        {
            targetX = 0;
            targetY = 0;
            destinationX = 0;
            destinationY = 0;
            i = 1;
            j = 1;
            safe = false;
            Exit = false;
            win = false;
        }

        public bool Exit { get; set; }

        public void MakeMove() // movement of the piece is this function
        {
            if (safe)
            {
                if (playerturn.p == 1)
                {
                    playerturn.p = 2;
                }
                else
                {
                    playerturn.p = 1;
                }
            }
            playerturn.Turn();
            if (playerturn.x == 0)
            {
                playerturn.Turn();
            }
            getInput();
        }

        private void getInput()
        {
            view.targetx();
            Exit = validInput(int.TryParse(Console.ReadLine(), out targetX));

            if (!Exit)// if we passed the previous validation, move to next postion
            {
                view.targety();
                Exit = validInput(int.TryParse(Console.ReadLine(), out targetY));
            }

            {
                if ((playerturn.p == 2 && players[targetX, targetY] == Player1_Symbol) || (playerturn.p == 1 && players[targetX, targetY] == Player2_Symbol))
                {
                    rearrangePlayer();
                }
                else
                {
                    view.chooseWrong();
                    MakeMove();
                }
            }

        }

        private bool validInput(bool parsed)
        {
            bool error = false;
            if (!parsed)
                error = true;
            else if (targetX < 0 || targetY < 0)
                error = true;
            else if (targetX > Board.row - 1 || targetY > Board.col - 1)
                error = true;
            if (error)
            {
                view.invalid();
            }

            return error;
        }
        private void rearrangePlayer() // update the piece in the board
        {

            {
                if ((targetY == 0) || (targetY == 2))
                {
                    destinationX = targetX - playerturn.x;
                    destinationY = targetY;

                    if ((destinationX < 0 || destinationY < 0))
                    {
                        if ((targetX == 2 && playerturn.x == 4) || (targetX == 0 && playerturn.x == 2) || (targetX == 1 && playerturn.x == 3))
                        {
                            players[1, 1] = players[targetX, targetY];
                            SecondCol();
                        }
                        else if ((targetX == 0 && playerturn.x == 3) || (targetX == 1 && playerturn.x == 4))
                        {
                            players[2, 1] = players[targetX, targetY];
                            SecondCol();
                        }
                        else if ((targetX == 0 && playerturn.x == 4))
                        {
                            players[3, 1] = players[targetX, targetY];
                            SecondCol();
                        }
                        else
                        {
                            players[0, 1] = players[targetX, targetY];
                            SecondCol();
                        }
                    }
                    else
                    {
                        captureOwnPiece();
                        players[destinationX, destinationY] = players[targetX, targetY];

                    }
                }
                else if (targetY == 1)
                {
                    destinationX = targetX + playerturn.x;
                    destinationY = targetY;

                    if (destinationX > 7 && players[targetX, targetY] == Player1_Symbol)
                    {
                        if ((targetX == 6 && playerturn.x == 3) || (targetX == 7 && playerturn.x == 2) ||
                        (targetX == 5 && playerturn.x == 4))
                        {
                            destinationX = 6;
                            destinationY = 0;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];

                        }
                        else if ((targetX == 6 && playerturn.x == 4) || (targetX == 7 && playerturn.x == 2))
                        {
                            destinationX = 5;
                            destinationY = 0;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];
                        }
                        else
                        {
                            destinationX = 7;
                            destinationY = 0;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];

                        }
                    }
                    else if (destinationX > 7 && players[targetX, targetY] == Player2_Symbol)
                    {
                        if ((targetX == 6 && playerturn.x == 3) || (targetX == 7 && playerturn.x == 2) ||
                             (targetX == 5 && playerturn.x == 4))
                        {
                            destinationX = 6;
                            destinationY = 2;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];

                        }
                        else if ((targetX == 6 && playerturn.x == 4) || (targetX == 7 && playerturn.x == 2))
                        {
                            destinationX = 5;
                            destinationY = 2;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];

                        }
                        else
                        {
                            destinationX = 7;
                            destinationY = 2;
                            captureOwnPiece();
                            players[destinationX, destinationY] = players[targetX, targetY];

                        }
                    }
                    else
                    {
                        destinationX = targetX + playerturn.x;
                        destinationY = targetY;
                        captureOwnPiece();
                        players[destinationX, destinationY] = players[targetX, targetY];
                    }
                }
            }
            {
                if (((targetX == 4 && targetY == 0)) && players[targetX, targetY] == Player1_Symbol && i < 7)
                {
                    i = i + 1;
                }
                else if (((targetX == 4 && targetY == 2)) && players[targetX, targetY] == Player2_Symbol && j < 7)
                {
                    j = j + 1;
                }
                else
                {
                    players[targetX, targetY] = space;
                }
            }

            Win();
            safeZone();

        }
        private void SecondCol()
        {
            players[targetX, targetY] = space;
            destinationX = playerturn.x;
            captureOwnPiece();
            players[destinationX, 1] = players[targetX, targetY];
        }

        private void Win()
        {

            if (Player1_Symbol == players[5, 0] || Player2_Symbol == players[5, 2])
            {
                win = true;
                view.winGame();
            }
        }

        private void safeZone()
        {
            if (Player1_Symbol == players[0, 0] || Player1_Symbol == players[6, 0] //|| Player1_Symbol == players[3, 1]
                || Player2_Symbol == players[0, 2] || Player2_Symbol == players[6, 2])
            {
                safe = true;
                view.safezone();
            }
            else
            {
                safe = false;
            }
        }
        private void captureOwnPiece()
        {
            if (playerturn.p == 2)
            {
                if (players[destinationX, destinationY] == Player1_Symbol)
                {
                    view.capturePiece();
                    MakeMove();
                }
            }
            else if (playerturn.p == 1)
            {
                if (players[destinationX, destinationY] == Player2_Symbol)
                {
                    view.capturePiece();
                    MakeMove();
                }
            }
        }
    }
}
