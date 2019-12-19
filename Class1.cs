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

        public bool Cango = false;
        public bool alive = true;

        public chess(string color, string name)//构造函数
        {
            this.color = color;
            this.name = name;
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
            public horse(string color)
            : base(color, "马")
            {
        }
        }

         public class cannon : chess
        {
            public cannon(string color)
            : base(color, "炮")
            { }
        }
        public class rood : chess
        {
            public rood(string color)
            : base(color, "车")
            { }
        }

        public class soldier : chess
        {
            public soldier(string color)
            : base(color, "兵")
            { }
    }

        public class elephant : chess
        {
            public elephant(string color)
            : base(color, "象")
            { }
    }

        public class guard : chess
        {
            public guard(string color)
            : base(color, "士")
            { }
        }

        public class general : chess
        {
        public general(string color)
            : base(color, "将")
        { }
        }

    public class nochess : chess
    {
        public nochess()
            : base("nochess", "nochess")
        { }
    }

}
