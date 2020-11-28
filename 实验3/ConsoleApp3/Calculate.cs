using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Calculate
    {
        int a, b, c, d;
        double e, f;
        string g, h, i, j;
        public int GetSum(int a,int b)
        {
            this.a = a;
            this.b = b;
            return this.a + this.b;
        }
        public int GetSum(int a,int b,int c,int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            return this.a + this.b + this.c + this.d;
        }
        public double GetSum(double a,double b)
        {
            this.e = a;
            this.f = b;
            return this.e + this.f;
        }
        public string GetSum(string a,string b,string c,string d)
        {
            this.g = a;
            this.h = b;
            this.i = c;
            this.j = d;
            return this.g + this.h + this.i + this.j;
        }
    }
}
