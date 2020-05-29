using System;
using BmiSample.Domain;

namespace BmiSample.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("身長をセンチメートル単位で入力してください。例：170");
            string strHeight = System.Console.ReadLine();
            int intHeight = int.Parse(strHeight);
            System.Console.WriteLine("体重をキログラム単位で入力してください。例：70");
            string strWeight = System.Console.ReadLine();
            int intWeight = int.Parse(strWeight);
            BmiCalculator calculator = new BmiCalculator();
            double value = calculator.Calculate(intHeight, intWeight);
            System.Console.WriteLine($"あなたのBMI指数は {value} です。");
            System.Console.ReadLine();
        }
    }
}
