using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleXiangqi
{

    public  class control//这个类的作用我觉得是能把main类变得很简洁
    {
        public board Board = new board();
        public board copyBoard = new board();
        int beginrow;
        int begincol;
        public bool state = true;
        string color = "red";//这个是在后面玩家切换回合使用，显示黑色走

        public bool Gameover()
        {
            bool alive;
            alive = Board.GeneralAlive();
            return alive;
        }

        public bool WhoWin()
        {
            bool alive;
            alive = Board.blackGeneralAlive();
            return alive;
        }

        /** public void display()//展示棋盘
         {
                 Display[0, 0] = "  ";
                 Display[0, 1] = "零";
                 Display[0, 2] = "一";
                 Display[0, 3] = "二";
                 Display[0, 4] = "三";
                 Display[0, 5] = "四";
                 Display[0, 6] = "五";
                 Display[0, 7] = "六";
                 Display[0, 8] = "七";
                 Display[0, 9] = "八";
                 Display[0, 10] = "九";
                 Display[1, 0] = "零";
                 Display[2, 0] = "一";
                 Display[3, 0] = "二";
                 Display[4, 0] = "三";
                 Display[5, 0] = "四";
                 Display[6, 0] = "五";
                 Display[7, 0] = "六";
                 Display[8, 0] = "七";
                 Display[9, 0] = "八";

                 for (int j = 1; j < 10; j++)
                 {

                     Display[j, 1] = "┬ ";
                     Display[j, 5] = "┴ ";
                     Display[j, 6] = "┬ ";
                     Display[j, 10] = "┴ ";
                 }
                 for (int i = 1; i < 11; i++)
                     {
                             Display[1, i] = "├ ";
                             Display[9, i] = "┤ ";
                     }

                 Display[1, 1] = "┌ ";
                 Display[9, 1] = "┐ ";
                 Display[1, 10] = "└ ";
                 Display[9, 10] = "┘ ";
             for (int j = 0; j < 11; j++)
                     {
                         for (int i = 0; i < 10; i++)
                         {
                     if (i == 0 || j == 0)
                     {
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.Write(Display[i, j]);
                     }
                     else if (Display[i, j] == "├ " || Display[i, j] == "┤ ")
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             Console.ForegroundColor = ConsoleColor.White;
                             Console.Write(Display[i, j]);
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                         }
                     }
                     else if (j == 1 || j == 10)
                     {
                         if(i != 4 && i != 5 && i != 6)
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Console.Write(Display[i, j]);
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                             }
                         }
                         else
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "×";
                                 Console.Write(Display[i, j]);
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                             }
                         }
                     }
                     else if (j == 5 || j == 6)
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             Console.ForegroundColor = ConsoleColor.White;
                             Console.Write(Display[i, j]);
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                         }
                     }
                     else if (i == 4 || i == 5 || i == 6)
                     {
                         if (j == 1 || j == 2 || j == 3 || j == 10 || j == 8 || j == 9)
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "×";
                                 Console.Write(Display[i, j]);
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                             }
                         }
                         else
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "┼ ";
                                 Console.Write(Display[i, j]);
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                             }
                         }
                     }
                     else
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             Console.ForegroundColor = ConsoleColor.White;
                             Display[i, j] = "┼ ";
                             Console.Write(Display[i, j]);
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                         }
                     }
                         }
                         Console.WriteLine("");
                     }
                   Console.ForegroundColor = ConsoleColor.White;
                   Console.WriteLine("");
           }
            **/
         public void Playchoose(int beginrow, int begincol)//选择棋子
         {
 
                this.begincol = begincol;
                this.beginrow = beginrow;
            
        }

        public void Movechess(int endrow, int endcol)
        {
            /** if (Board.Chess[endrow, endcol].Getname() == "将")
             {
                 Board.Chess[endrow, endcol].alive = false;
             }**/
            Board.MoveChess(this.begincol, this.beginrow, endcol, endrow);
            if(this.beginrow == endrow && this.begincol == endcol)
            {
                 MyException ex = new MyException();
                 throw new MyException("you choose the start point", ex);
            }
        }
        /** public void DisplayChoose(int colum, int row)//可能后期用于提供可走路线的展示
         {
             CopyBoard();
             copyBoard.Wherecanchessgo(colum, row);
             Display[0, 0] = "  ";
             Display[0, 1] = "零";
             Display[0, 2] = "一";
             Display[0, 3] = "二";
             Display[0, 4] = "三";
             Display[0, 5] = "四";
             Display[0, 6] = "五";
             Display[0, 7] = "六";
             Display[0, 8] = "七";
             Display[0, 9] = "八";
             Display[0, 10] = "九";
             Display[1, 0] = "零";
             Display[2, 0] = "一";
             Display[3, 0] = "二";
             Display[4, 0] = "三";
             Display[5, 0] = "四";
             Display[6, 0] = "五";
             Display[7, 0] = "六";
             Display[8, 0] = "七";
             Display[9, 0] = "八";

             for (int j = 1; j < 10; j++)
             {

                 Display[j, 1] = "┬ ";
                 Display[j, 5] = "┴ ";
                 Display[j, 6] = "┬ ";
                 Display[j, 10] = "┴ ";
             }
             for (int i = 1; i < 11; i++)
             {
                 Display[1, i] = "├ ";
                 Display[9, i] = "┤ ";
             }

             Display[1, 1] = "┌ ";
             Display[9, 1] = "┐ ";
             Display[1, 10] = "└ ";
             Display[9, 10] = "┘ ";
             for (int j = 0; j < 11; j++)
             {
                 for (int i = 0; i < 10; i++)
                 {
                     if (i == 0 || j == 0)
                     {
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.Write(Display[i, j]);
                         Console.BackgroundColor = ConsoleColor.Black; 
                     }
                     else if (Display[i, j] == "├ " || Display[i, j] == "┤ ")
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             if (copyBoard.Chess[i -1, j-1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             Console.ForegroundColor = ConsoleColor.White;
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black; 
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black; 
                         }
                     }
                     else if (j == 1 || j == 10)
                     {
                         if (i != 4 && i != 5 && i != 6)
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                             else
                             {
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                         }
                         else
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "×";
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                         }
                     }
                     else if (j == 5 || j == 6)
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             Console.ForegroundColor = ConsoleColor.White;
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black;
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black;
                         }
                     }
                     else if (i == 4 || i == 5 || i == 6)
                     {
                         if (j == 1 || j == 2 || j == 3 || j == 10 || j == 8 || j == 9)
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "×";
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                         }
                         else
                         {
                             if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                             {
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Display[i, j] = "┼ ";
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;
                             }
                             else
                             {
                                 Display[i, j] = Board.GetChessName(i - 1, j - 1);
                                 if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                                 {
                                     Console.BackgroundColor = ConsoleColor.DarkYellow;
                                 }
                                 switch (Board.GetChessColor(i - 1, j - 1))
                                 {
                                     case "red":
                                         Console.ForegroundColor = ConsoleColor.Red;
                                         break;

                                     case "black":
                                         Console.ForegroundColor = ConsoleColor.Blue;
                                         break;
                                 }
                                 Console.Write(Display[i, j]);
                                 Console.BackgroundColor = ConsoleColor.Black;

                             }
                         }
                     }
                     else
                     {
                         if (Board.Chess[i - 1, j - 1].Getname() == "nochess")
                         {
                             if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             Console.ForegroundColor = ConsoleColor.White;
                             Display[i, j] = "┼ ";
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black;
                         }
                         else
                         {
                             Display[i, j] = Board.GetChessName(i - 1, j - 1);
                             if (copyBoard.Chess[i - 1, j - 1].Cango == true)
                             {
                                 Console.BackgroundColor = ConsoleColor.DarkYellow;
                             }
                             switch (Board.GetChessColor(i - 1, j - 1))
                             {
                                 case "red":
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     break;

                                 case "black":
                                     Console.ForegroundColor = ConsoleColor.Blue;
                                     break;
                             }
                             Console.Write(Display[i, j]);
                             Console.BackgroundColor = ConsoleColor.Black;
                         }
                     }
                 }
                 Console.WriteLine("");
             }
             Console.ForegroundColor = ConsoleColor.White;
             Console.WriteLine("");

         }**/


        public void RefreshCanGo(int endrow, int endcol)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    Board.Chess[i, j].Cango = false;
                }

            }
        }
        public void SwitchPlayer()
        {
            switch (color)
            {
                case "black":
                    color = "red";
                    break;

                case "red":
                    color = "black";
                    break;
            }
        }

        /**public void CopyBoard()
        {
            for(int j = 0; j < 10; j++)
            {
                for(int i = 0; i <9; i++)
                {
                    if (Board.Chess[i, j].GetCango() == true)
                    {
                        Board.Chess[i, j].Cango = false;
                    }
                }
            }
            copyBoard = Board;
        }
    **/

    }
}