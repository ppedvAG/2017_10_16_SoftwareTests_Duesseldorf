using System;

namespace HalloDelegates
{
    public delegate string MyDelegate(int i, double d);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate(MeineMethode);
            MyDelegate del2 = new MyDelegate(new X().Whatever);

            var del3 = del; // Valuetype

            var result = del.Invoke(5, 8.4);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static string MeineMethode(int zahl, double wert) => (zahl + wert).ToString();
    }

    internal class X
    {
        public string Whatever(int a, double b) => "";
    }
}
