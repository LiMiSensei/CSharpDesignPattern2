using System.Diagnostics;
using System.Reflection;

namespace 工厂方法设计模式
{
    class Program
    {
        static void Main21(string[] args)
        {
            Console.WriteLine("请输入操作数1");
            double d1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作数2");
            double d2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine();

            //根据用户的操作符来创建一个创建对象的工厂对象

            ICalFactory cFactory = null;
            cFactory = oper switch
            {
                "+" => new AddFactory(),
                "-" => new SubFactory(),
                "*" => new MulFactory(),
                "/" => new DivFactory(),
            };
            ICalculator ctx = cFactory.GetCalFactory();
            Console.WriteLine($"计算结果为{ctx.GetResult(d1, d2)}");
        }
    }

    //1,创建对象所有的逻辑，都集合到了一个方法中，风险比较高
    //2，现在是抽象依赖了细节，我们需要让细节依赖抽象
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

    //1,把创建对象的这件事，封装成抽象
    public interface ICalFactory
    {
        ICalculator GetCalFactory();
    }

    public class AddFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Add();
        }
    }

    public class SubFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Sub();
        }
    }

    public class MulFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Mul();
        }
    }

    public class DivFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Div();
        }
    }


//=======================================================================================//
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