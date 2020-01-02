using System;
using System.Collections.Generic;
using System.Text;

//这个是棋盘类

namespace ConsoleXiangqi
{
    public class board
    {
        //第一步先把所有棋子创建好，我想了下应该只能靠手动输入初始化了···
        public chess[,] Chess = new chess[10,9];
        public chess[,] Big = new chess[14, 13];
        public int colum;
        public int row;

        chess blackRood1 = new rood("black", 0, 0);

        chess blackHorse1 = new horse("black", 1, 0);

        chess blackElephant1 = new elephant("black", 2, 0);

        chess blackguard1 = new guard("black", 3, 0);

        chess blackgeneral = new general("black", 4, 0);

        chess blackguard2 = new guard("black", 5, 0);

        chess blackElephant2 = new elephant("black", 6, 0);

        chess blackHorse2 = new horse("black", 7, 0);

        chess blackRood2 = new rood("black", 8, 0);

        chess blackCannon1 = new cannon("black", 1, 2);

        chess blackCannon2 = new cannon("black", 7, 2);

        chess blacksoldier1 = new soldier("black", 0, 3);

        chess blacksoldier2 = new soldier("black", 2, 3);

        chess blacksoldier3 = new soldier("black", 4, 3);

        chess blacksoldier4 = new soldier("black", 6, 3);

        chess blacksoldier5 = new soldier("black", 8, 3);

        chess redRood1 = new rood("red", 0, 9);

        chess redHorse1 = new horse("red", 1, 9);

        chess redElephant1 = new elephant("red", 2, 9);

        chess redguard1 = new guard("red", 3, 9);

        chess redgeneral = new general("red", 4, 9);

        chess redguard2 = new guard("red", 5, 9);

        chess redElephant2 = new elephant("red", 6, 9);

        chess redHorse2 = new horse("red", 7, 9);

        chess redRood2 = new rood("red", 8, 9);

        chess redCannon1 = new cannon("red", 1, 7);

        chess redCannon2 = new cannon("red", 7, 7);

        chess redsoldier1 = new soldier("red", 0, 6);

        chess redsoldier2 = new soldier("red", 2, 6);

        chess redsoldier3 = new soldier("red", 4, 6);

        chess redsoldier4 = new soldier("red", 6, 6);

        chess redsoldier5 = new soldier("red", 8, 6);

        public board()
        {

        }

        //用坐标可以获得当前点棋子名字
        public string GetChessName(int colum, int row)
        {
            
            return Chess[row, colum].Getname();
        }


        //用坐标可以获得当前点棋子颜色
        public string GetChessColor(int colum, int row)
        {
            return Chess[row, colum].Getcolor();
        }

        //移动棋子类
        public void MoveChess(int begincolum, int beginrow, int endcolum, int endrow)//我们之后会利用Split截取用户输入的坐标，所以我就把点搞成String类型
        {
            /**int begincolum = int.Parse(strBegincolum);//先把这些坐标改成int类型
            int beginrow = int.Parse(strBeginrow);
            int endcolum = int.Parse(strEndcolum);
            int endrow = int.Parse(strEndrow);**/
            Chess[endrow, endcolum] = Chess[beginrow, begincolum];//把用户想去的点对应“棋盘”的二维数组坐标的棋子换成用户想走的棋子（即初始点的棋子放到终点）
            Chess[endrow, endcolum].row = endrow;
            Chess[endrow, endcolum].column = endcolum;
            Chess[beginrow, begincolum] = new nochess(begincolum,beginrow);//然后把棋子一开始的点变为空
        }

        public bool Movemethod(int begincolum,int beginrow, int endcolum, int endrow)
        {
            bool cango = true;
            switch (Chess[begincolum, beginrow].Getname())
            {
                case "兵":
                    switch (Chess[begincolum,beginrow].color)
                    {
                        case "red":
                            if (beginrow >= 5)//无过河
                            {
                                if (endcolum == begincolum && (beginrow - endrow) == 1)
                                {
                                    cango = true;
                                }
                                else
                                {
                                    cango = false;
                                }

                            }

                            else//已经过河
                            {
                                if (begincolum - endcolum == 1 || begincolum - endcolum == -1)//兵过河后走左右
                                {
                                    if (endrow - beginrow == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else if (beginrow - endrow == 1)
                                {
                                    if (begincolum - endcolum == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else
                                {
                                    cango = false;
                                }
                            }
                            break;

                        case "black":
                            if (beginrow <= 4)//无过河
                            {
                                if (endcolum == begincolum && (endrow - beginrow) == 1)
                                {
                                    cango = true;
                                }
                                else
                                {
                                    cango = false;
                                }

                            }

                            else//已经过河
                            {
                                if (begincolum - endcolum == 1 || begincolum - endcolum == -1)//兵过河后走左右
                                {
                                    if (endrow - beginrow == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else if (endrow - beginrow == 1)
                                {
                                    if (begincolum - endcolum == 0)
                                    {
                                        cango = true;
                                    }
                                    else
                                    {
                                        cango = false;
                                    }
                                }
                                else
                                {
                                    cango = false;
                                }
                            }
                            break;
                    }
                    break;

               


                //--------------------------------------------------------------------------
                case "象":

                    switch (Chess[begincolum, beginrow].color)

                    {

                        case "black":

                            if (beginrow <= 4)

                            {

                                if ((begincolum == 2) && (beginrow == 0))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }



                                        else

                                        {

                                            cango = false;

                                        }




                                    }
                                    else if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))
                                    {
                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else { cango = false; }
                                    }


                                    else

                                    {

                                        cango = false;

                                    }





                                }



                                else if ((begincolum == 4) && (beginrow == 2))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if ((Chess[begincolum + 1, beginrow + 1].Getname() == "nochess"))

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((begincolum - endcolum == 2) && (beginrow - endcolum == 2))
                                    {
                                        if ((Chess[begincolum + 1, beginrow + 1].Getname() == "nochess"))
                                        {
                                            cango = true;
                                        }
                                        else { cango = false; }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }



                                else if ((begincolum == 6) && (beginrow == 0))

                                {

                                    if ((endcolum - begincolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))
                                    {
                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }



                                else if ((beginrow == 2) && (begincolum == 8))

                                {

                                    if ((begincolum - endcolum == 2) && (endrow - beginrow == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow + 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }





                            }





                            break;





                        case "red":

                            if (beginrow >= 5)

                            {

                                if ((beginrow == 9) && (begincolum == 2))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }


                                }

                                if ((begincolum == 0) && (beginrow == 7))

                                {

                                    if ((endcolum - begincolum == 2) && (beginrow - endrow == 2))

                                    {

                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }

                                    else

                                    {

                                        cango = false;

                                    }

                                }

                                if ((beginrow == 9) && (begincolum == 6))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }



                                    else

                                    {

                                        cango = false;

                                    }

                                }

                                if ((begincolum == 4) && (beginrow == 7))

                                {

                                    if ((beginrow - endrow == 2) && (begincolum - endcolum == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }

                                    }
                                    else if ((beginrow - endrow == 2) && (endcolum - begincolum == 2))
                                    {
                                        if (Chess[begincolum + 1, beginrow - 1].Getname() == "nochess")
                                        {
                                            cango = true;
                                        }
                                        else
                                        {
                                            cango = false;
                                        }
                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }



                                if ((beginrow == 7) && (begincolum == 8))

                                {

                                    if ((begincolum - endcolum == 2) && (beginrow - endrow == 2))

                                    {

                                        if (Chess[begincolum - 1, beginrow - 1].Getname() == "nochess")

                                        {

                                            cango = true;

                                        }
                                        else
                                        {
                                            cango = false;
                                        }


                                    }

                                    else

                                    {

                                        cango = false;

                                    }



                                }





                            }









                            break;









                    }

                    break;

                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "马":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if (Math.Abs(begincolum - endcolum) == 2 && Math.Abs(beginrow - endrow) == 1)
                            {
                                if (Chess[endrow, beginrow].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }

                            else if (Math.Abs(begincolum - endcolum) == 1 && Math.Abs(beginrow - endrow) == 2)
                            {
                                if (Chess[begincolum, (beginrow + endrow) / 2].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }
                            else cango = false;
                            break;

                        case "black":
                            if (Math.Abs(begincolum - endcolum) == 2 && Math.Abs(beginrow - endrow) == 1)
                            {
                                if (Chess[endrow, beginrow].Getname() == "nochess")

                                { cango = true; }
                                else { cango = false; }

                            }
                            else if (Math.Abs(begincolum - endcolum) == 1 && Math.Abs(beginrow - endrow) == 2)
                            {
                                if (Chess[begincolum, (beginrow + endrow) / 2].Getname() == "nochess")
                                { cango = true; }
                                else { cango = false; }
                            }
                            else cango = false;
                            break;


                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "炮":
                    if ((beginrow == endrow) && (begincolum != endcolum))
                    {
                        if (endcolum < begincolum)//向左
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int j = begincolum - 1; j > endcolum; j--)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int j = begincolum - 1; j > endcolum; j--)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }
                        else if (endcolum > begincolum)//向右
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int j = begincolum + 1; j < endcolum; j++)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                int account = 0;
                                for (int j = begincolum + 1; j < endcolum; j++)
                                {
                                    if (!Chess[j, endrow].Getname().Equals("nochess"))
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }

                    }
                    //上下移动
                    else if ((begincolum == endcolum) && (beginrow != endrow))
                    {
                        if (endrow < beginrow)//向上
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int i = beginrow - 1; i > endrow; i--)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            //炮的“吃”法：
                            //去的地方有棋子，且那个棋子颜色是与自己不同的，即敌方的棋子
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                //判断起点和目的地之间是否有棋子，且只有一个，才能吃目的地的棋子，否则吃不了
                                int account = 0;
                                for (int i = beginrow - 1; i > endrow; i--)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;

                        }

                        else if (endrow > beginrow)//向下
                        {
                            if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                            {
                                for (int i = beginrow + 1; i < endrow; i++)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
                                    {
                                        cango = false;
                                        break;
                                    }
                                    else
                                        cango = true;
                                }
                            }
                            else if ((!Chess[endcolum, endrow].Getname().Equals("nochess")) && (!Chess[begincolum, beginrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                            {
                                int account = 0;
                                for (int i = beginrow + 1; i < endrow; i++)
                                {
                                    if (!Chess[endcolum, i].Getname().Equals("nochess"))
                                    {
                                        account = account + 1;
                                    }
                                }
                                if (account == 1)
                                {
                                    cango = true;
                                }
                                else
                                    cango = false;
                            }
                            else
                                cango = false;
                        }
                        else
                            cango = false;
                    }
                    else
                        cango = false;

                    break;
                //--------------------------------------------------------------------------
                case "将":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if ((endrow >= 7 && endrow <= 9) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 1)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            else
                                cango = false;
                            break;

                        case "black":
                            if ((endrow >= 0 && endrow <= 2) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 1)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            else
                                cango = false;
                            break;
                    }

                    break;
                //--------------------------------------------------------------------------
                case "士":
                    switch (Chess[begincolum, beginrow].color)
                    {
                        case "red":
                            if ((endrow >= 7 && endrow <= 9) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 1)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            else
                                cango = false;
                            break;

                        case "black":
                            if ((endrow >= 0 && endrow <= 2) && (endcolum >= 3 && endcolum <= 5))
                            {
                                if (Math.Pow(endrow - beginrow, 2) + Math.Pow(endcolum - begincolum, 2) == 2)
                                {
                                    if (Chess[endcolum, endrow].Getname().Equals("nochess"))
                                    {
                                        cango = true;
                                    }
                                    else if (!Chess[endcolum, endrow].Getname().Equals("nochess") && (!Chess[endcolum, endrow].Getcolor().Equals(Chess[endcolum, endrow].Getcolor())))
                                    {
                                        cango = true;
                                    }
                                    else
                                        cango = false;
                                }
                                else
                                    cango = false;

                            }
                            else
                                cango = false;
                            break;
                    }
                    break;

                case "车":
                    {
                        if (begincolum - endcolum == 0 && endrow - beginrow > 0)
                        {
                            for (int i = beginrow + 1; i < endrow; i++)
                            {
                                if (Chess[begincolum, i].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }

                            }

                        }
                        else if (beginrow - endrow == 0 && endcolum - begincolum > 0)
                        {
                            for (int j = begincolum + 1; j < endcolum; j++)
                            {
                                if (Chess[j, beginrow].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }
                            }
                        }
                        else if (begincolum - endcolum == 0 && endrow - beginrow < 0)
                        {
                            for (int i = beginrow - 1; i < endrow; i--)
                            {
                                if (Chess[begincolum, i].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;

                                }

                            }

                        }
                        else if (beginrow - endrow == 0 && endcolum - begincolum > 0)
                        {
                            for (int j = begincolum - 1; j < endcolum; j--)
                            {
                                if (Chess[j, beginrow].Getname() != "nochess")
                                {
                                    cango = false;
                                    break;
                                }
                                else
                                {
                                    cango = true;
                                }
                            }
                        }
                        else
                        {
                            cango = false;
                            break;
                        }




                    }

                    break;
            }
            return cango;

        }

        //通过找黑红的将生死看游戏有没有结束
        public bool GeneralAlive()
        {
            return blackgeneral.alive && redgeneral.alive;
        }

        public bool blackGeneralAlive()
        {
            return blackgeneral.alive ;
        }

        //这是查找将的生死，之后用排除法得是黑赢还是红赢
        public bool WhoWin()
        {
            return blackgeneral.alive;
        }

        //因为是把棋盘当成二维数组，所以我们把创建的棋子变量初始化到棋盘数组里
        public void InitializeBorad()
        {
            Chess[0,0] = blackRood1;

            Chess[0, 1] = blackHorse1;

            Chess[0, 2] = blackElephant1;

            Chess[0, 3] = blackguard1;

            Chess[0, 4] = blackgeneral;

            Chess[0, 5] = blackguard2;

            Chess[0, 6] = blackElephant2;

            Chess[0, 7] = blackHorse2;

            Chess[0, 8] = blackRood2;

            Chess[2, 1] = blackCannon1;

            Chess[2, 7] = blackCannon2;

            Chess[3, 0] = blacksoldier1;

            Chess[3, 2] = blacksoldier2;

            Chess[3, 4] = blacksoldier3;

            Chess[3, 6] = blacksoldier4;

            Chess[3, 8] = blacksoldier5;

            Chess[9, 0] = redRood1;

            Chess[9, 1] = redHorse1;

            Chess[9, 2] = redElephant1;

            Chess[9, 3] = redguard1;

            Chess[9, 4] = redgeneral;

            Chess[9, 5] = redguard2;

            Chess[9, 6] = redElephant2;

            Chess[9, 7] = redHorse2;

            Chess[9, 8] = redRood2;

            Chess[7, 1] = redCannon1;

            Chess[7, 7] = redCannon2;

            Chess[6, 0] = redsoldier1;

            Chess[6, 2] = redsoldier2;

            Chess[6, 4] = redsoldier3;

            Chess[6, 6] = redsoldier4;

            Chess[6, 8] = redsoldier5;

            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (Chess[j, i] == null)
                    {
                        Chess[j, i] = new nochess(i,j);
                    }
                }
            }
        }

        public void CopyCanGo()
        {
            for (int i = 2; i <= 11; i++)
            {
                for (int j = 2; j <= 10; j++)
                {
                    Chess[i-2, j-2].Cango = Big[i,j].Cango;
                }

            }
            for (int i = 0; i <= 13; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    Big[i, j] = new nochess(j,i);
                }

            }
        }

        public void CreateBigBoard()
        {
            for (int i = 0; i <= 13; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    Big[i, j] = new nochess(j,i);
                }

            }
            for (int i = 2; i <= 11; i++)
            {
                for (int j = 2; j <= 10; j++)
                {
                    Big[i, j] = Chess[i-2, j-2];
                }

            }


        }

        public void Wherecanchessgo(int chessColum, int chessRow)
        {
            switch (Chess[chessRow, chessColum].Getname())
            {
                case "兵":CreateBigBoard();
                    colum = chessColum + 2;
                    row = chessRow + 2;
                    switch (Chess[chessRow, chessColum].Getcolor())
                    {
                        case "red":
                            if (chessRow >= 5)
                            {
                                if (Big[row - 1, colum].Getcolor() != "red")
                                {
                                    Big[row - 1, colum].changeCango();
                                }
                            }
                            else if (chessRow <= 4)
                            {
                                if (Big[row, colum + 1].Getcolor() != "red")
                                {
                                    Big[row, colum + 1].changeCango();
                                }
                                if (Big[row, colum - 1].Getcolor() != "red")
                                {
                                    Big[row, colum - 1].changeCango();
                                }
                                if (Big[row - 1, colum].Getcolor() != "red")
                                {
                                    Big[row - 1, colum].changeCango();
                                }
                            }
                            CopyCanGo();
                            break;

                        case "black":
                            if (chessRow <= 4)
                            {
                                Big[row + 1, colum].changeCango();
                            }
                            else if (chessRow >= 5)
                            {
                                if (Big[row, colum + 1].Getcolor() != "black")
                                {
                                    Big[row, colum + 1].changeCango();
                                }
                                if (Big[row, colum - 1].Getcolor() != "black")
                                {
                                    Big[row, colum - 1].changeCango();
                                }
                                if (Big[row + 1, colum].Getcolor() != "black")
                                {
                                    Big[row + 1, colum].changeCango();
                                }
                            }
                            CopyCanGo();
                            break;
                    }
                    break;
                //--------------------------------------------------------------------------------------------
                case "炮":

                    for (int i = chessRow - 1; i >= 0; i--)
                    {
                        //如果起始点的下一个位置没有棋子，则显示可走
                        if (Chess[i, chessColum].Getname().Equals("nochess"))
                        {
                            Chess[i,chessColum].changeCango();
                        }
                        //如果下一个位置有棋子X
                        else
                        {
                            //那么，从这个棋子X开始，往棋子X之后继续遍历
                            for (int i1 = i - 1; i1 >= 0; i1--)
                            {
                                //如果棋子X之后一个位置有棋子，且为对方的棋子，则显示可走，然后到此为止，即退出当前循环，也要退出最外层的循环
                                if ((!Chess[i1, chessColum].Getname().Equals("nochess")) && (!Chess[i1, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[i1, chessColum].changeCango();
                                    i = -1;
                                    break;

                                }
                                //如果棋子X之后一个位置有棋子，但是是我方棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if ((!Chess[ i1,chessColum].Getname().Equals("nochess")) && (Chess[i1,chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    i = -1;
                                    break;
                                }
                                //如果棋子X之后一个位置没棋子，此时，也到此位置，退出当前循环和最外层循环
                                else if (Chess[ i1,chessColum].Getname().Equals("nochess"))
                                {
                                }
                                //如果棋子X之后一个位置没有棋子，则继续进行此循环，看看棋子X之后的一个位置是否有棋子。。。。。。
                            }
                        }
                    }
                    for (int i = chessRow + 1; i <= 9; i++)
                    {
                        if (Chess[i,chessColum].Getname().Equals("nochess"))
                        {
                            Chess[i, chessColum].changeCango();
                        }
                        else
                        {
                            for (int i1 = i + 1; i1 <= 9; i1++)
                            {
                                if ((!Chess[i1, chessColum].Getname().Equals("nochess")) && (!Chess[i1, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[i1, chessColum].changeCango();

                                    i = 10;
                                    break;
                                }
                                else if ((!Chess[i1, chessColum].Getname().Equals("nochess")) && (Chess[i1,chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    i = 10;
                                    break;
                                }
                                else if (Chess[i1, chessColum].Getname().Equals("nochess"))
                                {
                                    i = 10;
                                }
                            }
                        }
                    }
                    for (int j = chessColum - 1; j >= 0; j--)
                    {
                        if (Chess[chessRow, j].Getname().Equals("nochess"))
                        {
                            Chess[chessRow, j].changeCango();
                        }
                        else
                        {
                            for (int j1 = j - 1; j1 >= 0; j1--)
                            {
                                if ((!Chess[chessRow, j1].Getname().Equals("nochess")) && (!Chess[chessRow, j1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow, j1].changeCango();
                                    j = -1;
                                    break;
                                }
                                else if ((!Chess[chessRow, j1].Getname().Equals("nochess")) && (Chess[chessRow, j1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    j = -1;
                                    break;
                                }
                                else if (Chess[chessRow, j1].Getname().Equals("nochess"))
                                {
                                    j = -1;
                                }
                            }
                        }
                    }
                    for (int j = chessColum + 1; j <= 8; j++)
                    {
                        if (Chess[chessRow, j].Getname().Equals("nochess"))
                        {
                            Chess[chessRow, j].changeCango();
                        }
                        else
                        {
                            for (int j1 = j + 1; j1 <= 8; j1++)
                            {
                                if ((!Chess[chessRow, j1].Getname().Equals("nochess")) && (!Chess[chessRow, j1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow, j1].changeCango();
                                    j = 9;
                                    break;
                                }
                                else if ((!Chess[chessRow, j1].Getname().Equals("nochess")) && (Chess[chessRow, j1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    j = 9;
                                    break;
                                }
                                else if (Chess[chessRow, j1].Getname().Equals("nochess"))
                                {
                                    j = 9;
                                }
                            }
                        }
                    }
                    break;
                    /**
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "象":
                    switch (Chess[row, chessColum].Getcolor())
                    {
                        case "black":
                            if (row <= 4)
                            {
                                if ((row == 0) && (chessColum == 2))
                                {
                                    if (Chess[row + 1, colum - 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum - 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum - 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum - 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum - 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum - 2].changeCango();
                                            }
                                        }

                                    }
                                    if (Chess[row + 1, colum + 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum + 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum + 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum + 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum + 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum + 2].changeCango();
                                            }
                                        }
                                    }


                                }

                                if ((row == 0) && (colum == 6))
                                {

                                    if (Chess[row + 1, colum - 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum - 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum - 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum - 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum - 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum - 2].changeCango();
                                            }
                                        }

                                    }
                                    if (Chess[row + 1, colum + 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum + 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum + 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum + 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum + 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum + 2].changeCango();
                                            }
                                        }
                                    }

                                }











                                if ((row == 2) && (colum == 0))

                                {
                                    if (Chess[row + 1, colum + 1].Getname() == "nochess")
                                    {
                                        Chess[row + 2, colum + 2].changeCango();
                                    }
                                    else if (Chess[row + 2, colum + 2].Getname() != "nochess")
                                    {
                                        if (Chess[row + 2, colum + 2].Getcolor() == "red")
                                        {
                                            Chess[row + 2, colum + 2].changeCango();
                                        }
                                    }


                                }












                                if ((row == 2) && (colum == 4))
                                {
                                    if (Chess[row + 1, colum - 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum - 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum - 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum - 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum - 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum - 2].changeCango();
                                            }
                                        }

                                    }
                                    if (Chess[row + 1, colum + 1].Getname() == "nochess")
                                    {
                                        if (Chess[row + 2, colum + 2].Getname() == "nochess")
                                        {
                                            Chess[row + 2, colum + 2].changeCango();
                                        }
                                        else if (Chess[row + 2, colum + 2].Getname() != "nochess")
                                        {
                                            if (Chess[row + 2, colum + 2].Getcolor() == "red")
                                            {
                                                Chess[row + 2, colum + 2].changeCango();
                                            }
                                        }
                                    }
                                }













                                if ((row == 2) && (colum == 8) && Chess[colum - 1, row + 1].Getname() == "nochess")
                                {
                                    if (Chess[row + 1, colum - 1].Getname() == "nochess")
                                    {
                                        Chess[row + 2, colum - 2].changeCango();
                                    }
                                    else if (Chess[row + 2, colum - 2].Getname() != "nochess")
                                    {
                                        if (Chess[row + 2, colum - 2].Getcolor() == "red")
                                        {
                                            Chess[row + 2, colum - 2].changeCango();
                                        }
                                    }

                                }



                            }








                            break;

                        case "red":
                            if (row >= 5)
                            {

                                if (row == 9)
                                {
                                    if (Chess[row - 1, colum - 1].Getname() == "nochess")
                                    {
                                        if (Chess[row - 2, colum - 2].Getname() == "nochess")
                                        {
                                            Chess[row - 2, colum - 2].changeCango();
                                        }
                                        else if (Chess[row - 2, colum - 2].Getname() != "nochess")
                                        {
                                            if (Chess[row - 2, colum - 2].Getcolor() == "black")
                                            {
                                                Chess[row - 2, colum - 2].changeCango();
                                            }
                                        }

                                    }
                                    if (Chess[row - 1, colum + 1].Getname() == "nochess")
                                    {
                                        if (Chess[row - 2, colum + 2].Getname() == "nochess")
                                        {
                                            Chess[row - 2, colum + 2].changeCango();
                                        }
                                        else if (Chess[row - 2, colum + 2].Getname() != "nochess")
                                        {
                                            if (Chess[row - 2, colum + 2].Getcolor() == "black")
                                            {
                                                Chess[row - 2, colum + 2].changeCango();
                                            }
                                        }
                                    }
                                }

                                if ((row == 7) && (colum == 4))
                                {
                                    if (Chess[row - 1, colum - 1].Getname() == "nochess")
                                    {
                                        if (Chess[row - 2, colum - 2].Getname() == "nochess")
                                        {
                                            Chess[row - 2, colum - 2].changeCango();
                                        }
                                        else if (Chess[row - 2, colum - 2].Getname() != "nochess")
                                        {
                                            if (Chess[row - 2, colum - 2].Getcolor() == "black")
                                            {
                                                Chess[row - 2, colum - 2].changeCango();
                                            }
                                        }

                                    }
                                    if (Chess[row - 1, colum + 1].Getname() == "nochess")
                                    {
                                        if (Chess[row - 2, colum + 2].Getname() == "nochess")
                                        {
                                            Chess[row - 2, colum + 2].changeCango();
                                        }
                                        else if (Chess[row - 2, colum + 2].Getname() != "nochess")
                                        {
                                            if (Chess[row - 2, colum + 2].Getcolor() == "black")
                                            {
                                                Chess[row - 2, colum + 2].changeCango();
                                            }
                                        }
                                    }
                                }


                                if ((row == 7) && (colum == 0))

                                {
                                    if (Chess[row - 1, colum + 1].Getname() == "nochess")
                                    {
                                        Chess[row - 2, colum + 2].changeCango();
                                    }
                                    else if (Chess[row - 2, colum + 2].Getname() != "nochess")
                                    {
                                        if (Chess[row - 2, colum + 2].Getcolor() == "black")
                                        {
                                            Chess[row - 2, colum + 2].changeCango();
                                        }
                                    }


                                }

                                if ((row == 7) && (colum == 8))

                                {
                                    if (Chess[row - 1, colum - 1].Getname() == "nochess")
                                    {
                                        Chess[row - 2, colum - 2].changeCango();
                                    }
                                    else if (Chess[row - 2, colum - 2].Getname() != "nochess")
                                    {
                                        if (Chess[row - 2, colum - 2].Getcolor() == "black")
                                        {
                                            Chess[row - 2, colum - 2].changeCango();
                                        }
                                    }


                                }








                            }





                            break;





                    }

                    break;
                **/
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "车": //（0，0）==》（0，1）
                    for (int i = chessRow - 1; i >= 0; i--)
                    {
                        if (Chess[i, chessColum].Getname().Equals("nochess"))
                        {
                            Chess[i, chessColum].changeCango();
                        }
                        else if (Chess[i, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor()))
                        {
                            break;
                        }
                        else if ((!Chess[i, chessColum].Getname().Equals("nochess")) && (!Chess[i, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            Chess[i, chessColum].changeCango();
                            break;
                        }


                    }


                    for (int i = chessRow + 1; i <= 9; i++)
                    {
                        if (Chess[i, chessColum].Getname().Equals("nochess"))
                        {
                            Chess[i, chessColum].changeCango();
                        }
                        else if ((Chess[i, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[i, chessColum].Getname().Equals("nochess")) && (!Chess[i, chessColum].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            Chess[i, chessColum].changeCango();
                            break;
                        }

                    }

                    for (int j = chessColum - 1; j >= 0; j--)
                    {
                        if (Chess[chessRow, j].Getname().Equals("nochess"))
                        {
                            Chess[chessRow, j].changeCango();
                        }
                        else if ((Chess[chessRow, j].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[chessRow, j].Getname().Equals("nochess")) && (!Chess[chessRow, j].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            Chess[chessRow, j].changeCango();

                            break;

                        }
                    }


                    for (int j = chessColum + 1; j <= 8; j++)
                    {
                        if (Chess[chessRow, j].Getname().Equals("nochess"))
                        {
                            Chess[chessRow, j].changeCango();
                        }
                        else if ((Chess[chessRow, j].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[chessRow, j].Getname().Equals("nochess")) && (!Chess[chessRow, j].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                        {
                            Chess[chessRow, j].changeCango();
                            break;
                        }

                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "象":
                    CreateBigBoard();
                    colum = chessColum + 2;
                    row = chessRow + 2;
                    switch (Chess[chessRow, chessColum].Getcolor())
                    {
                        case "black":
                            if (chessRow <= 4)
                            {

                                if (chessRow == 4)
                                {
                                    if ((Big[row - 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum + 2].Getname() != "nochess" &&
                                    Big[row - 2, colum + 2].Getcolor() == "red")
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    if ((Big[row - 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum - 2].Getname() != "nochess" &&
                                    Big[row - 2, colum - 2].Getcolor() == "red")
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                }
                                else
                                {
                                    if ((Big[row - 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum + 2].Getname() != "nochess" &&Big[row + 2, colum + 2].Getcolor() == "red")
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    if ((Big[row - 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum - 2].Getname() != "nochess" &&
                                    Big[row - 2, colum - 2].Getcolor() == " red")
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess ")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                    if ((Big[row + 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess")
                                        {
                                            Big[row + 2, colum + 2].changeCango();
                                        }
                                    }
                                    else if (Big[row + 2, colum + 2].Getname() != "nochess" &&
                                   Big[row + 2, colum + 2].Getcolor() == "red")
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess ")
                                        { Big[row + 2, colum + 2].changeCango(); }
                                    }
                                    if ((Big[row + 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row + 2, colum - 2].Getname() != "nochess" &&
                                    Big[row + 2, colum - 2].Getcolor() == "red")
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess ")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                }
                            }
                            CopyCanGo();
                            break;


                        case "red":
                            if (chessRow >= 5)
                            {

                                if (chessRow == 5)
                                {
                                    if ((Big[row + 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row + 2, colum - 2].Getname() != "nochess" &&
                                    Big[row + 2, colum - 2].Getcolor() == "black")
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                    if ((Big[row + 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess")
                                        { Big[row + 2, colum + 2].changeCango(); }
                                    }
                                    else if (Big[row + 2, colum + 2].Getname() != "nochess" &&
                                    Big[row + 2, colum + 2].Getcolor() == "black")
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess")
                                        { Big[row + 2, colum + 2].changeCango(); }
                                    }
                                }
                                else
                                {
                                    if ((Big[row - 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum + 2].Getname() != "nochess" &&
                                   Big[row - 2, colum + 2].Getcolor() == " black")
                                    {
                                        if (Big[row - 1, colum + 1].Getname() == "nochess")
                                        { Big[row - 2, colum + 2].changeCango(); }
                                    }
                                    if ((Big[row + 2, colum + 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess")
                                        { Big[row + 2, colum + 2].changeCango(); }
                                    }
                                    else if (Big[row + 2, colum + 2].Getname() != "nochess" &&
                                    Big[row + 2, colum + 2].Getcolor() == " black")
                                    {
                                        if (Big[row + 1, colum + 1].Getname() == "nochess")
                                        { Big[row + 2, colum + 2].changeCango(); }
                                    }
                                    if ((Big[row + 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row + 2, colum - 2].Getname() != "nochess" &&
                                    Big[row + 2, colum - 2].Getcolor() == "black")
                                    {
                                        if (Big[row + 1, colum - 1].Getname() == "nochess")
                                        { Big[row + 2, colum - 2].changeCango(); }
                                    }
                                    if ((Big[row - 2, colum - 2].Getname() == "nochess"))
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                    else if (Big[row - 2, colum - 2].Getname() != "nochess" &&
                                    Big[ row- 2, colum - 2].Getcolor() == " black")
                                    {
                                        if (Big[row - 1, colum - 1].Getname() == "nochess")
                                        { Big[row - 2, colum - 2].changeCango(); }
                                    }
                                }
                            }
                            CopyCanGo();
                            break;
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "将":
                    switch (Chess[chessRow, chessColum].Getcolor())
                    {
                        case "red":
                            if (chessRow - 1 >= 7)
                            {
                                if (Chess[chessRow - 1, chessColum].Getname() == "nochess" || Chess[chessRow - 1, chessColum].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow - 1, chessColum].changeCango();
                                }
                            }
                            if (chessRow + 1 <= 9)
                            {
                                if (Chess[chessRow + 1, chessColum].Getname() == "nochess" || Chess[chessRow + 1, chessColum].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow + 1, chessColum].changeCango();
                                }
                            }
                            if (chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow, chessColum-1].Getname() == "nochess" || Chess[chessRow, chessColum - 1].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow, chessColum - 1].changeCango();
                                }
                            }
                            if (chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow, chessColum + 1].Getname() == "nochess" || Chess[chessRow, chessColum + 1].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow, chessColum + 1].changeCango();
                                }
                            }
                            //飞将
                            if (chessColum == blackgeneral.column)
                            {
                                int middlePiece = 0;
                                for (int i = chessRow - 1; i > blackgeneral.row; i--)
                                {
                                    if (Chess[i, chessColum].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    Chess[blackgeneral.column, blackgeneral.row].changeCango();
                                }
                            }
                            break;

                        case "black":
                            if (chessRow - 1 >= 0)
                            {
                                if (Chess[chessRow - 1, chessColum].Getname() == "nochess" || Chess[chessRow - 1, chessColum].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow - 1, chessColum].changeCango();
                                }
                            }
                            if (chessRow + 1 <= 2)
                            {
                                if (Chess[chessRow+1, chessColum].Getname() == "nochess" || Chess[chessRow+1, chessColum].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow + 1, chessColum].changeCango();
                                }
                            }
                            if (chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow, chessColum-1].Getname() == "nochess" || Chess[chessRow, chessColum - 1].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow, chessColum-1].changeCango();
                                }
                            }
                            if (chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow, chessColum+1].Getname() == "nochess" || Chess[chessRow, chessColum +1].Getcolor() != Chess[chessRow, chessColum].Getcolor())
                                {
                                    Chess[chessRow, chessColum+1].changeCango();
                                }
                            }
                            //飞将
                            if (chessColum == redgeneral.column)
                            {
                                int middlePiece = 0;
                                for (int i = chessRow + 1; i < redgeneral.row; i++)
                                {
                                    if (Chess[colum, i].Getname() != "nochess")
                                    {
                                        middlePiece = middlePiece + 1;
                                    }

                                }
                                if (middlePiece == 0)
                                {
                                    Chess[redgeneral.column, redgeneral.row].changeCango();
                                }
                            }
                            break;
                    }
                    break;
                //----------------------------------------------------------------------------------------------------------------------------------------------
                case "士":
                    switch (Chess[chessRow, chessColum].Getcolor())
                    {
                        case "red":
                            if (chessRow - 1 >= 7 && chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow - 1, chessColum + 1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow - 1, chessColum + 1].changeCango();
                                }
                                else if (!(Chess[chessRow - 1, chessColum + 1].Getname().Equals("nochess") || Chess[chessRow - 1, chessColum + 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow - 1, chessColum + 1].changeCango();
                                }
                            }

                            if (chessRow - 1 >= 7 && chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow - 1, chessColum - 1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow - 1, chessColum - 1].changeCango();
                                }
                                else if (!(Chess[chessRow - 1, chessColum - 1].Getname().Equals("nochess") || Chess[chessRow - 1, chessColum - 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow - 1, chessColum - 1].changeCango();
                                }
                            }

                            if (chessRow + 1 <= 9 && chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow + 1, chessColum - 1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow + 1, chessColum - 1].changeCango();
                                }
                                else if (!(Chess[chessRow + 1, chessColum - 1].Getname().Equals("nochess") || Chess[chessRow + 1, chessColum - 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow + 1, chessColum - 1].changeCango();
                                }
                            }

                            if (chessRow + 1 <= 9 && chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow + 1, chessColum +1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow + 1, chessColum + 1].changeCango();
                                }
                                else if (!(Chess[chessRow + 1, chessColum + 1].Getname().Equals("nochess") || Chess[chessRow + 1, chessColum + 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow + 1, chessColum + 1].changeCango();
                                }
                            }

                            break;
                        case "black":
                            if (chessRow - 1 >= 0 && chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow - 1, chessColum + 1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow - 1, chessColum + 1].changeCango();
                                }
                                else if (!(Chess[chessRow - 1, chessColum + 1].Getname().Equals("nochess") || Chess[chessRow - 1, chessColum + 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow - 1, chessColum + 1].changeCango();
                                }
                            }

                            if (chessRow - 1 >= 0 && chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow-1, chessColum-1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow - 1, chessColum - 1].changeCango();
                                }
                                else if (!(Chess[chessRow - 1, chessColum - 1].Getname().Equals("nochess") || Chess[chessRow - 1, chessColum - 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow - 1, chessColum - 1].changeCango();
                                }
                            }

                            if (chessRow + 1 <= 2 && chessColum - 1 >= 3)
                            {
                                if (Chess[chessRow+1, chessColum-1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow + 1, chessColum - 1].changeCango();
                                }
                                else if (!(Chess[chessRow + 1, chessColum - 1].Getname().Equals("nochess") || Chess[chessRow + 1, chessColum - 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow + 1, chessColum - 1].changeCango();
                                }
                            }

                            if (chessRow + 1 <= 2 && chessColum + 1 <= 5)
                            {
                                if (Chess[chessRow+1, chessColum+1].Getname().Equals("nochess"))
                                {
                                    Chess[chessRow + 1, chessColum + 1].changeCango();
                                }
                                else if (!(Chess[chessRow + 1, chessColum + 1].Getname().Equals("nochess") || Chess[chessRow + 1, chessColum + 1].Getcolor().Equals(Chess[chessRow, chessColum].Getcolor())))
                                {
                                    Chess[chessRow + 1, chessColum + 1].changeCango();
                                }
                            }
                            break;
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------

                case "马":
                    CreateBigBoard();
                    colum = chessColum + 2;
                    row = chessRow + 2;
                    if(Big[row+1,colum].Getname() == "nochess")
                    {
                        if(Big[row,colum].Getcolor() != Big[row + 2, colum + 1].Getcolor())
                        {
                            Big[row + 2, colum + 1].changeCango();
                        }
                        if (Big[row, colum].Getcolor() != Big[row + 2, colum - 1].Getcolor())
                        {
                            Big[row + 2, colum - 1].changeCango();
                        }
                    }

                    if (Big[row - 1, colum].Getname() == "nochess")
                    {
                        if (Big[row, colum].Getcolor() != Big[row - 2, colum + 1].Getcolor())
                        {
                            Big[row - 2, colum + 1].changeCango();
                        }
                        if (Big[row, colum].Getcolor() != Big[row - 2, colum - 1].Getcolor())
                        {
                            Big[row - 2, colum - 1].changeCango();
                        }
                    }

                    if (Big[row , colum-1].Getname() == "nochess")
                    {
                        if (Big[row, colum].Getcolor() != Big[row - 1, colum - 2].Getcolor())
                        {
                            Big[row - 1, colum - 2].changeCango();
                        }
                        if (Big[row, colum].Getcolor() != Big[row + 1, colum - 2].Getcolor())
                        {
                            Big[row + 1, colum - 2].changeCango();
                        }
                    }

                    if (Big[row, colum + 1].Getname() == "nochess")
                    {
                        if (Big[row, colum].Getcolor() != Big[row + 1, colum + 2].Getcolor())
                        {
                            Big[row + 1, colum + 2].changeCango();
                        }
                        if (Big[row, colum].Getcolor() != Big[row - 1, colum + 2].Getcolor())
                        {
                            Big[row - 1, colum + 2].changeCango();
                        }
                    }

                    break;
            }
        }
    }
}
