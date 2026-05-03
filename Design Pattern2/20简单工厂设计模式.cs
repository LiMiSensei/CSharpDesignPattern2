using System.Diagnostics;
using System.Reflection;

namespace 简单工厂设计模式
{
    class Program
    {
        //创建型设计模式：工厂设计模式
        static void Main20(string[] args)
        {
            //写一个简单的项目，来实现计算器加减乘除的功能

            //4个对象：加减乘除

            Console.WriteLine("请输入操作数1");
            double d1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作数2");
            double d2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine();

            //根据opera的不同创建不同的计算
            ICalculator calculator = CalFactory.GetCalculator(oper);


            var 结果 = calculator?.GetResult(d1, d2);
            Console.WriteLine($"结果为：{结果}");
        }
    }

    //静态工厂方法：实际上就是把创建对象的过程，封装到静态方法中，在客户端直接调用，
    public class CalFactory
    {
        public static ICalculator GetCalculator(string oper)
        {
            return oper switch
            {
                "+" => new Add(),
                "-" => new Sub(),
                "*" => new Mul(),
                "/" => new Div(),
            };
        }
    }

    public interface ICalculator
    {
        double GetResult(double num1, double num2);
    }

    public class Add : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Sub : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Mul : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Div : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}