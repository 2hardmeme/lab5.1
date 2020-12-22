using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _1zavd
{
    class MyFrac : IComparable<MyFrac>, IMyNumber<MyFrac>
    {
        BigInteger num;
        BigInteger denum;

        //конструктор для BigInteger
        public MyFrac(BigInteger num, BigInteger denum)
        {
            //2 поля за умовою BigInteger
            BigInteger g1 = num;
            BigInteger g2 = denum;

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }
            this.num = num / (g1 + g2);
            this.denum = denum / (g1 + g2);
        }
        //метод, який зрівнює дроби
        public int CompareTo(MyFrac ob)
        {
            double r1 = (double)this.num / (double)this.denum;
            double r2 = (double)ob.num / (double)ob.denum;
            return r1.CompareTo(r2);
        }
        //конструктор для int
        public MyFrac(int num, int denum)
        {
            //беремо по модулю, щоб працювало і з від'ємними числами
            long g1 = Math.Abs(num);
            long g2 = Math.Abs(denum);

            //Якщо в знаменнику мінус, то ставимо його вверх
            if (denum < 0)
            {
                num = -num;
                denum = Math.Abs(denum);
            }

            while ((g1 != 0) && (g2 != 0))
            {
                if (g1 > g2)
                    g1 %= g2;
                else
                    g2 %= g1;
            }
            this.num = num / Math.Max(g1, g2);
            this.denum = denum / Math.Max(g1, g2);
        }
        //пустий конструктор
        public MyFrac()
        {
        }
        //метод множення
        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.num * that.num, this.denum * that.denum);
        }
        //мтеод ділення
        public MyFrac Divide(MyFrac that)
        {
            BigInteger a;
            a = this.denum * that.num;
            if (a == 0)
            {
                //якщо знаменник = 0, вискакує ексепшн
                throw new System.DivideByZeroException();
            }
            return new MyFrac(this.num * that.denum, a);
        }
        //метод додавання
        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.num * that.denum + this.denum * that.num, this.denum * that.denum);
        }
        //метод віднімання
        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.num * that.denum - this.denum * that.num, this.num * that.num);
        }
        //перевизначений метод додавання
        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            return f1.Add(f2);
        }
        //перевизначений метод віднімання
        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            return f1.Subtract(f2);
        }
        //перевизначений метод множення
        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return f1.Multiply(f2);
        }
        //перевизначений метод ділення
        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return f1.Divide(f2);
        }
        //перевизначення методу ToString
        public override string ToString()
        {
            return num + "/" + denum;
        }
    }
}