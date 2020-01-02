using System;
using System.Collections.Generic;
using System.Text;

//这个是棋子的类，我就是是基于这个类出发做的，所以要看的话先看这个类！

namespace ConsoleXiangqi
{

    public abstract class chess
    {
        string name;//名字，颜色，行，列，这是我暂时想到有用的属性
        public string color;
        public int row;
        public int column;
        public bool Cango = false;
        public bool alive = true;

        public chess(string color, string name,int column, int row)//构造函数
        {
            this.color = color;
            this.name = name;
            this.column = column;
            this.row = row;
        }

        public string Getname()//获取名字
        {
            return this.name;
        }

        public string Getcolor()//获取棋子的颜色
        {
            return this.color;
        }



        public void changeCango()
        {
            Cango = true;
        }

        public bool GetCango()
        {
            return Cango;
        }

    }


    //以下就算是各个棋子的类，也就是“棋子”的子类，除了将我添加了一个"生死"属性，其它一样
        public class horse : chess
        {
            public horse(string color,int column, int row)
            : base(color, "马",column,row)
            {
        }
        }

         public class cannon : chess
        {
            public cannon(string color, int column, int row)
            : base(color, "炮", column, row)
            { }
        }
        public class rood : chess
        {
            public rood(string color, int column, int row)
            : base(color, "车", column, row)
            { }
        }

        public class soldier : chess
        {
            public soldier(string color, int column, int row)
            : base(color, "兵", column, row)
            { }
    }

        public class elephant : chess
        {
            public elephant(string color, int column, int row)
            : base(color, "象", column, row)
            { }
    }

        public class guard : chess
        {
            public guard(string color, int column, int row)
            : base(color, "士", column, row)
            { }
        }

        public class general : chess
        {
        public general(string color, int column, int row)
            : base(color, "将", column, row)
        { }
        }

    public class nochess : chess
    {
        public nochess(int column, int row)
            : base("nochess", "nochess", column, row)
        { }
    }

}
