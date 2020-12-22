using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1zavd
{
    class MyComplex : IMyNumber<MyComplex>
    {
        //поля класу
        double re;
        double im;
        //конструктор який ініціалізує поля
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        //також інтовий конструктор 
        public MyComplex(int re, int im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex Add(MyComplex f1)
        {
            return new MyComplex(this.re + f1.re, this.im + f1.im);
        }
        public MyComplex Subtract(MyComplex f1)
        {
            return new MyComplex(this.re - f1.re, this.im - f1.im);
        }
        public MyComplex Multiply(MyComplex f1)
        {
            return new MyComplex(this.re * f1.re - this.im * f1.im, this.re * f1.im + this.im * f1.re);
        }
        public MyComplex Divide(MyComplex f1)
        {
            return new MyComplex((this.re * f1.re + this.im * f1.im) / (Math.Sqrt(f1.re) + Math.Sqrt(f1.im)), (this.im * f1.re - this.re * f1.im) / (Math.Sqrt(f1.re) + Math.Sqrt(f1.im)));
        }
        public override string ToString()
        {
            return this.re + "+" + this.im + "i";
        }
    }
}