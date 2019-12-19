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

        chess blackRood1 = new rood("black");

        chess blackHorse1 = new horse("black");

        chess blackElephant1 = new elephant("black");

        chess blackguard1 = new guard("black");

        chess blackgeneral = new general("black");

        chess blackguard2 = new guard("black");

        chess blackElephant2 = new elephant("black");

        chess blackHorse2 = new horse("black");

        chess blackRood2 = new rood("black");

        chess blackCannon1 = new cannon("black");

        chess blackCannon2 = new cannon("black");

        chess blacksoldier1 = new soldier("black");

        chess blacksoldier2 = new soldier("black");

        chess blacksoldier3 = new soldier("black");

        chess blacksoldier4 = new soldier("black");

        chess blacksoldier5 = new soldier("black");

        chess redRood1 = new rood("red");

        chess redHorse1 = new horse("red");

        chess redElephant1 = new elephant("red");

        chess redguard1 = new guard("red");

        chess redgeneral = new general("red");

        chess redguard2 = new guard("red");

        chess redElephant2 = new elephant("red");

        chess redHorse2 = new horse("red");

        chess redRood2 = new rood("red");

        chess redCannon1 = new cannon("red");

        chess redCannon2 = new cannon("red");

        chess redsoldier1 = new soldier("red");

        chess redsoldier2 = new soldier("red");

        chess redsoldier3 = new soldier("red");

        chess redsoldier4 = new soldier("red");

        chess redsoldier5 = new soldier("red");

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
            Chess[beginrow, begincolum] = new nochess();//然后把棋子一开始的点变为空
        }

        /*8public bool Movemethod(int begincolum,int beginrow, int endcolum, int endrow)
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
        **/
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
                        Chess[j, i] = new nochess();
                    }
                }
            }
        }
       
        public void Wherecanchessgo(int colum, int row)
        {
            switch (Chess[row, colum].Getname())
            {
                case "兵":
                    switch(Chess[row, colum].Getcolor())
                    {
                        case "red":
                            if (row >= 5)
                            {
                                if (Chess[row - 1 , colum].Getcolor() != "red")
                                {
                                    Chess[ row - 1, colum].changeCango();
                                }
                            }
                            else if (row<=4){
                                if (colum == 0)
                                {
                                    if(row == 0)
                                    {
                                        if (Chess[ row, colum + 1].Getcolor() != "red")
                                        {
                                            Chess[ row, colum + 1].changeCango();
                                        }
                                    }
                                    else 
                                    {
                                        if (Chess[ row, colum + 1].Getcolor() != "red")
                                        {
                                            Chess[ row, colum + 1].changeCango();
                                        }
                                        if (Chess[ row - 1, colum].Getcolor() != "red")
                                        {
                                            Chess[ row - 1, colum].changeCango();
                                        }
                                    }
                                }
                                else if (row==0)
                                {
                                    if (colum == 0)
                                    {
                                        if (Chess[row,colum + 1].Getcolor() != "red")
                                        {
                                            Chess[row,colum + 1].changeCango();
                                        }
                                    }
                                    else if(colum == 8)
                                    {
                                        if (Chess[row,colum - 1].Getcolor() != "red")
                                        {
                                            Chess[row,colum - 1].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        Chess[row,colum + 1].changeCango();
                                        Chess[row,colum - 1].changeCango();
                                    }
                                }
                                else if(colum == 8){
                                    if (row == 0)
                                    {
                                        if (Chess[row,colum - 1].Getcolor() != "red")
                                        {
                                            Chess[row,colum - 1].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[row,colum - 1].Getcolor() != "red")
                                        {
                                            Chess[row, colum - 1].changeCango();
                                        }
                                        if (Chess[row - 1,colum].Getcolor() != "red")
                                        {
                                            Chess[row - 1, colum].changeCango();
                                        }
                                    }
                                }
                                else
                                {
                                    if(Chess[row,colum + 1].Getcolor() != "red")
                                    {
                                        Chess[row,colum + 1].changeCango();
                                    }
                                    if (Chess[row,colum - 1].Getcolor() != "red")
                                    {
                                        Chess[row,colum - 1].changeCango();
                                    }
                                    if (Chess[row-1, colum].Getcolor() != "red")
                                    {
                                        Chess[row-1, colum].changeCango();
                                    }
                                }
                            }
                            break;

                        case "black":
                            if (row <= 4)
                            {
                                Chess[row + 1,colum].changeCango();
                            }
                            else if (row >= 5)
                            {
                                if (colum == 0)
                                {
                                    if (row == 9)
                                    {
                                        if (Chess[row,colum + 1].Getcolor() != "black")
                                        {
                                            Chess[row,colum + 1 ].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[row, colum + 1].Getcolor() != "black")
                                        {
                                            Chess[row, colum + 1].changeCango();
                                        }
                                        if (Chess[row+1, colum].Getcolor() != "black")
                                        {
                                            Chess[row + 1, colum].changeCango();
                                        }
                                    }
                                }
                                else if (row == 9)
                                {
                                    if (colum == 0)
                                    {
                                        Chess[row,colum + 1].changeCango();
                                    }
                                    else if (colum == 8)
                                    {
                                        Chess[row,colum - 1].changeCango();
                                    }
                                    else
                                    {
                                        Chess[row,colum + 1].changeCango();
                                        Chess[row, colum - 1].changeCango();
                                    }
                                }
                                else if (colum == 8)
                                {
                                    if (row == 0)
                                    {

                                        if (Chess[row, colum - 1].Getcolor() != "black")
                                        {
                                            Chess[row, colum - 1].changeCango();
                                        }
                                    }
                                    else
                                    {
                                        if (Chess[row, colum - 1].Getcolor() != "black")
                                        {
                                            Chess[row, colum - 1].changeCango();
                                        }
                                        if (Chess[row + 1, colum].Getcolor() != "black")
                                        {
                                            Chess[ row + 1, colum].changeCango();
                                        }
                                    }
                                }
                                else
                                {
                                    if (Chess[ row, colum + 1].Getcolor() != "black")
                                    {
                                        Chess[ row, colum + 1].changeCango();
                                    }
                                    if (Chess[row, colum - 1].Getcolor() != "black")
                                    {
                                        Chess[ row, colum - 1].changeCango();
                                    }
                                    if (Chess[row + 1, colum].Getcolor() != "black")
                                    {
                                        Chess[ row + 1, colum].changeCango();
                                    }
                                }
                            }
                            break;
                    }
                    break;
                    /**
                //--------------------------------------------------------------------------------------------
                case "炮":

                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else
                        {
                            for (int i1 = i - 1; i1 >= 0; i1--)
                            {
                                if ((!Chess[colum, i1].Getname().Equals("nochess")) && (!Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum, i1].changeCango();
                                    i = -1;
                                    break;

                                }
                                else
                                {
                                    i = -1;
                                }
                            }
                        }
                    }
                    for (int i = row + 1; i <= 9; i++)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else
                        {
                            for (int i1 = i + 1; i1 <= 9; i1++)
                            {
                                if ((!Chess[colum, i1].Getname().Equals("nochess")) && (!Chess[colum, i1].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[colum, i1].changeCango();

                                    i = 10;
                                    break;
                                }
                                else
                                {
                                    i = 10;
                                }
                            }
                        }
                    }
                    for (int j = colum - 1; j >= 0; j--)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else
                        {
                            for (int j1 = j - 1; j1 >= 0; j1--)
                            {
                                if ((!Chess[j1, row].Getname().Equals("nochess")) && (!Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[j1, row].changeCango();
                                    j = -1;
                                    break;
                                }
                                else
                                {
                                    j = -1;
                                }
                            }
                        }
                    }
                    for (int j = colum + 1; j <= 8; j++)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else
                        {
                            for (int j1 = j + 1; j1 <= 8; j1++)
                            {
                                if ((!Chess[j1, row].Getname().Equals("nochess")) && (!Chess[j1, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                                {
                                    Chess[j1, row].changeCango();
                                    j = 9;
                                    break;
                                }
                                else
                                {
                                    j = 9;
                                }
                            }
                        }
                    }
                    break;
                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "象":
                    switch (Chess[colum, row].Getcolor())
                    {
                        case "black":
                            if (row <= 4)
                            {
                                if (row == 0)
                                {
                                    if ((Chess[colum - 1, row + 1].Getname() == "nochess") && (Chess[colum + 1, row + 1].Getname() == "nochess"))
                                    {
                                        Chess[colum - 2, row + 2].changeCango();
                                        Chess[colum + 2, row + 2].changeCango();
                                    }

                                }
                                if ((row == 2) && (colum == 0) && (Chess[colum + 1, row + 1].Getname() == "nochess"))
                                {
                                    Chess[colum + 2, row + 2].changeCango();

                                }
                                if ((row == 2) && (colum == 4) && (Chess[colum - 1, row + 1].Getname() == "nochess") && (Chess[colum + 1, row + 1].Getname() == "nochess"))
                                {
                                    Chess[colum + 2, row + 2].changeCango();
                                    Chess[colum - 2, row + 2].changeCango();
                                }
                                if ((row == 2) && (colum == 8) && Chess[colum - 1, row + 1].Getname() == "nochess")
                                {
                                    Chess[colum - 2, row + 2].changeCango();
                                }



                            }








                            break;

                        case "red":
                            if (row >= 5)
                            {

                                if (row == 9)
                                {
                                    if ((Chess[colum + 1, row - 1].Getname() == "nochess") && (Chess[colum - 1, row - 1].Getname() == "nochess"))
                                    {
                                        Chess[colum + 2, row - 2].changeCango();
                                        Chess[colum - 2, row - 2].changeCango();
                                    }
                                }

                                if (row == 7)
                                {

                                    if ((colum == 0) && (Chess[colum + 1, row - 1].Getname() == "nochess"))
                                    {
                                        Chess[colum + 2, row - 2].changeCango();
                                    }




                                    if ((colum == 4) && (Chess[colum + 1, row - 1].Getname() == "nochess") && (Chess[colum - 1, row - 1].Getname() == "nochess"))
                                    {
                                        Chess[colum + 2, row - 2].changeCango();
                                        Chess[colum - 2, row - 2].changeCango();
                                    }
                                    if ((colum == 8) && (Chess[colum - 1, row - 1].Getname() == "nochess"))
                                    {
                                        Chess[colum - 2, row - 2].changeCango();
                                    }
                                }




                            }





                            break;





                    }

                    break;

                //-------------------------------------------------------------------------------------------------------------------------------------------
                case "车": //（0，0）==》（0，1）
                    for (int i = row - 1; i >= 0; i--)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else if (Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor()))
                        {
                            break;
                        }
                        else if ((!Chess[colum, i].Getname().Equals("nochess")) && (!Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[colum, i].changeCango();
                            break;
                        }


                    }


                    for (int i = row + 1; i <= 9; i++)
                    {
                        if (Chess[colum, i].Getname().Equals("nochess"))
                        {
                            Chess[colum, i].changeCango();
                        }
                        else if ((Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[colum, i].Getname().Equals("nochess")) && (!Chess[colum, i].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[colum, i].changeCango();
                            break;
                        }

                    }

                    for (int j = colum - 1; j >= 0; j--)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else if ((Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[j, row].Getname().Equals("nochess")) && (!Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[j, row].changeCango();

                            break;

                        }
                    }


                    for (int j = colum + 1; j <= 8; j++)
                    {
                        if (Chess[j, row].Getname().Equals("nochess"))
                        {
                            Chess[j, row].changeCango();
                        }
                        else if ((Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            break;
                        }
                        else if ((!Chess[j, row].Getname().Equals("nochess")) && (!Chess[j, row].Getcolor().Equals(Chess[colum, row].Getcolor())))
                        {
                            Chess[j, row].changeCango();
                            break;
                        }

                    }
                    break;
                    //-------------------------------------------------------------------------------------------------------------------------------------------













**/
            }
        }
    }
}
